using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace TraningTask
{
    public partial class Form1 : Form
    {

        //ファイルパス
        public string failepath = string.Empty;

        public Form1()
        {
            InitializeComponent();          
        }

 
  

        int iResult = SystemConst.ResultCode_Success;

        //string DBName = "EDU";
        string strErrKey = string.Empty;
        string strExpMessage = string.Empty;
        string strLogMesage = string.Empty;

        private string sDefPath = @"C:\";

        string[] userdata;

        //クラス宣言

        //コモンクラス
        Common Commmon = new Common();
        //データテーブル
        DataTable dt = new DataTable();

        //CSV関係クラス
        CsvFileEdits csvFileEdites = new CsvFileEdits();

        XML.DBControl dbCon = new XML.DBControl();

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] commands = System.Environment.GetCommandLineArgs();

            // 処理状況ファイルを作成する際のDB名を取得
            SystemParam.CONF_FILE = "Config.xml";
            SystemParam.strConfFilPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, SystemParam.CONF_FILE);
            SystemParam.TABLE_FILE = "DataTable.xml";
            SystemParam.strUpdTblFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, SystemParam.TABLE_FILE);


            iResult = Commmon.ReadConfigFile(ref strErrKey, ref strExpMessage);
        }
        
        private void tbCsvFilePath_TextChanged(object sender, EventArgs e)
        {

        }



        //ドラック＆ドロップ
        private void tbFilepath_DragDrop(object sender, DragEventArgs e)
        {         
            TextBox tb = new TextBox();
       
            // ファイルじゃなければ、ドロップを許可しない
            if (System.IO.File.Exists(failepath) == false)
            {
                return;
            }

            //CSVファイルか判定
            if(csvCheck(failepath)==true)
            {
             //ファイルパスをテキストへセット
                tbCsvFilePath.Text = System.IO.Path.GetDirectoryName(failepath);
             //フォルダをテキストへセット
                tbCsvFolderPath.Text = System.IO.Path.GetFileName(failepath);

            }


        }

        private void tbFilepath_DragEnter(object sender, DragEventArgs e)
        {

            string[] dragFilePathArr = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            failepath = dragFilePathArr[0];

            //CSVファイルか判定
             if(csvCheck(failepath)==true)
            {

                 if (e.Data.GetDataPresent(DataFormats.FileDrop) == true)
                  {
                      e.Effect = DragDropEffects.All;
                  }
                  else
                  {
                      e.Effect = DragDropEffects.None;
                  }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Csvチェッカー
        private bool csvCheck(string failePath)
        {
            if (".csv" == Path.GetExtension(failePath))
            {
                return true;
            }
            return false;
        }
        //データ表示
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //グリッドに書き込みを禁止する
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            //ファイルを読み込む
            if (csvFileEdites.RenderCSV(false, failepath, ",", false) == true)
            {
                ////列のデータテーブルを表示する
                cbSelectTable.Items.AddRange(csvFileEdites.GetColumsName());
                //追加されたらCBが自動的に開く
                cbSelectTable.DroppedDown = true;
            }
            

        }
        //コンボボックス
        private void cbSelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            //コンボボックス内の名前を取得する
            int index = cbSelectTable.SelectedIndex;
            string text = cbSelectTable.Items[index].ToString();

            //指定した名前のデータを読み込む
            userdata = dbCon.LoadDB(csvFileEdites.GetDataTable(), text);

        }

        private void btFileDialog_Click(object sender, EventArgs e)
        {
             Button bt = (Button)sender;

            //タイルの設定
            string sDialogTitle = string.Empty;
            string sInitialDirectory = string.Empty;
            string sOutputFilename = string.Empty;
            string sBackUpFileName = string.Empty;
            int iDaialogClass = 0;


            TextBox tbSelectPath = tbCsvFolderPath;
            TextBox tbSelectName = tbCsvFilePath;
            TextBox tbSavePath = tbCsvFolderPath;
            TextBox tbSaveName = tbCsvFilePath;


          if(bt.Name == "btFileDialog")
          {
              sDialogTitle = gbCsvFile.Text;
              tbSelectPath = tbCsvFolderPath;
              tbSelectName = tbCsvFilePath;
          }

            //ファイル選択ダイアログ表示
            if(iDaialogClass == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();

               //表示拡張子の設定
                ofd.Filter = SystemConst.sLSFileFilter;
                ofd.FilterIndex = 1;
                if(string.IsNullOrEmpty(sInitialDirectory) == false)
                {
                    if(System.IO.Directory.Exists(sInitialDirectory)==true)
                    {
                        ofd.InitialDirectory = sInitialDirectory;
                    }
                    else
                    {
                        ofd.InitialDirectory = sDefPath;
                    }
                }
                ofd.Title = sDialogTitle.Trim()+"の選択";

                    
                // ダイアログボックスを閉じる前に現在のディレクトリを復元
                ofd.RestoreDirectory = true;

                // 存在しないファイルの名前が指定されたとき警告を表示
                ofd.CheckFileExists = true;

                //  存在しないパスが指定されたとき警告を表示
                ofd.CheckPathExists = true;

                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    //同一ファイルなら何もしない
                    if(string.Compare(System.IO.Path.Combine(tbSelectPath.Text,tbSelectName.Text),ofd.FileName) != 0)
                    {
                        //ファイルとフォルダパスに表示する
                        tbCsvFilePath.Text = System.IO.Path.GetFileName(ofd.FileName);
                        tbCsvFolderPath.Text = System.IO.Path.GetDirectoryName(ofd.FileName);

                        //読み込むファイルパスを代入
                        failepath = tbCsvFolderPath.Text + "\\"+ tbCsvFilePath.Text;
                    }
                }
            }
            //ファイル選択のダイアログ表示
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                //最初のファイルの指定
                sfd.FileName = tbSaveName.Text;

                //表示拡張子の設定
                sfd.Filter = SystemConst.sLSFileFilter;
                sfd.FilterIndex = 1;

                //初期化されるフォルダのパス
                if(string.IsNullOrEmpty(sInitialDirectory)==false)
                {
                    if(System.IO.Directory.Exists(sInitialDirectory)==true)
                    {
                        sfd.InitialDirectory = sInitialDirectory;
                    }
                    else
                    {
                        sfd.InitialDirectory = sDefPath;
                    }
                }
                //タイトルの設定
                sfd.Title = sDialogTitle.Trim() + "の保存";
                //すでに存在するファイル名を指定したとき警告しない
                sfd.OverwritePrompt = false;
                //存在しないパスが指定したとき警告を表示
                sfd.CheckPathExists = true;

                //ダイアログ表示
                if(sfd.ShowDialog(this) == DialogResult.OK)
                {
                    tbSavePath.Text = System.IO.Path.GetFileName(sfd.FileName);
                    tbSaveName.Text = System.IO.Path.GetDirectoryName(sfd.FileName);
                }
            }

        }

        private void gbCsvFolder_Enter(object sender, EventArgs e)
        {

        }
        //読み込んだデータを表示する
        private void btViewTable_Click(object sender, EventArgs e)
        {

            if (csvFileEdites.GetDataTable() != null)
            {
                //カラム数指定
                dataGridView.ColumnCount = csvFileEdites.GetDataTable().Columns.Count;

                //カラムを登録してお
                for (int i = 0; i < csvFileEdites.GetDataTable().Columns.Count; i++)
                {
                    dataGridView.Columns[i].HeaderText = csvFileEdites.GetDataTable().Rows[0][i].ToString();

                }
                //ユーザーデータを表示する
                dataGridView.Rows.Add(userdata);
            }
            else
            {
                MessageBox.Show("データを読み込んでください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        

        }

        private void btDeleteGridData_Click(object sender, EventArgs e)
        {
            //グリッド内の選択したデータを削除
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                if(!item.IsNewRow)
                {
                    dataGridView.Rows.Remove(item);
                }
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

            
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            OpenFileDialog ofd = new OpenFileDialog();

            //初めに表示されるファイルを指定
            sfd.InitialDirectory = @"C:\";
            //指定しないの時、現愛のディレクトリが表示される
            sfd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            //2番目のファイルが選択される用にする
            sfd.FilterIndex = 2;
            //タイトルを設定する
            sfd.Title = "保存策のファイルを指定してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元する用にする
            sfd.RestoreDirectory = true;
            //存在するファイルを指定したとき警告を表示する
            sfd.OverwritePrompt = true;
            //存在しないパスが指定された時警告を表示する
            sfd.CheckPathExists = true;

            

            //ダイアログを表示する
            if(sfd.ShowDialog() == DialogResult.OK)
            {
               csvFileEdites.SavetoCSV(sfd.FileName,dataGridView);
            }

        }

        //終了ボタン
        private void btEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
