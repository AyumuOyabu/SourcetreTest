using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace TraningTask
{
    class CsvFileEdits
    {

            string[] name = null;

            DataTable dt;

         //CSVファイルからデータテーブルオブジェクトを作成
        public bool RenderCSV(bool hasHeader, string fileName, string separator, bool quote)
        {
            XML.DBControl dbCon = new XML.DBControl();

            StringBuilder strSql = new StringBuilder();

            TextFieldParser parser;
            
            dt = new DataTable();

            DataRow row = dt.NewRow();


            if (fileName != string.Empty)
            {
                //CSVを読み込む
                parser = new TextFieldParser(fileName, Encoding.GetEncoding("shift_jis"));

                //可変長
                parser.TextFieldType = FieldType.Delimited;

                //parser.FieldWidths 
                //区切り文字を設定
                parser.SetDelimiters(separator);
                //ダブルクォーテーションの有無
                parser.HasFieldsEnclosedInQuotes = quote;
                string[] data = new string[0];


                if (!parser.EndOfData)
                {
                    //CSVから一行読み取る
                    data = parser.ReadFields();
                    //カラム数の取得
                    int cols = data.Length;
                    if (hasHeader)
                    {
                        for (int i = 0; i < cols; i++)
                        {
                            dt.Columns.Add(new DataColumn(data[i]));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < cols; i++)
                        {
                            dt.Columns.Add(new DataColumn());
                        }
                        //データテーブルに追加するための新規行を取得します
                        row = dt.NewRow();
                        for (int i = 0; i < cols; i++)
                        {
                            //カラム数だけデータを移す
                            row[i] = data[i];
                        }
                        //データテーブルに追加
                        dt.Rows.Add(row);
                    }
                    while (!parser.EndOfData)
                    {
                        data = parser.ReadFields();


                        row = dt.NewRow();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            row[i] = data[i];
                        }
                        dt.Rows.Add(row);
                    }




                    //データがあったら削除
                    dbCon.DeleteDT();
                    //テーブルを作成する
                    dbCon.CreateDataTable(dt);

                    //テーブルをサーバーに書き込む
                    dbCon.DBInsert(dt);
                    //カラム名を取得する
                    name = dbCon.GetColumsName(dt);

                }     

            }
            else
            {
                //エラーメッセージ表示
                MessageBox.Show("ファイルが選択されてません。","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return false;
            }

            return true;


              
           
        }

        public void  SavetoCSV(string FileName,DataGridView dgv)
        {

            //新規ファイルcsvを作成する
            using (StreamWriter writer = new StreamWriter(FileName + ".csv", false, Encoding.GetEncoding("shift_jis")))
            {
                int row = dgv.Rows.Count;

                string[] strArray = new string[dgv.ColumnCount + dgv.RowCount * dgv.ColumnCount];

                string strCsvData = string.Empty;

                //リスト初期化                   
                List<string> strColumnList = new List<string>();

                //カラム名代入
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    //カラム名をリストに代入
                    strColumnList.Add(dgv.Columns[i].HeaderText.ToString());

                    //配列に変換
                    strArray = strColumnList.ToArray();

                    //CSVに変換
                    strCsvData = string.Join(",", strArray);
                }
                //書き込み
                writer.WriteLine(strCsvData);

                //行
                for (int i = 0; i < row; i++)
                {    
                    //リスト初期化                   
                   List<string> strList = new List<string>();

　                  //列
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        strList.Add(dgv[j, i].Value.ToString());

                        //配列に変換
                        strArray = strList.ToArray();

                        //CSVに変換
                        strCsvData = string.Join(",", strArray);
                    }
                    //書き込み
                    writer.WriteLine(strCsvData);
                }


                //書き込み終了
                writer.Close();
            }

        }

        public string[] GetColumsName()
        {
            return name;
        }

        public DataTable GetDataTable()
        {
            return dt;
        }
    }
}
