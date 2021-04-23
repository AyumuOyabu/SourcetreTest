using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TraningTask.XML
{
    class DBControl
    {
        //DBConnection
        private SqlConnection sqlCon = null;
        //SQLトランザクション
        private SqlTransaction sqlTran = null;
        //SQLコマンド
        private SqlCommand sqlCom =new SqlCommand();
        //SQLパラメータ
       // private SqlParameter sqlPar = null;

        private StringBuilder strSql = new StringBuilder();

        Common common = new Common();

        //テーブル名
        string tableNmae = "USER_INF";

        //コンストラクタ
       public DBControl()
        {
            sqlCon = null;

           
        }

        //DBオープン処理
        public bool Open()
       {

           bool bRet = false;
           try
           {
               sqlCon = new SqlConnection();
               sqlCon.ConnectionString = SystemParam.ComfigFile.DSN;
               sqlCon.Open();
               bRet = true;

           }
            catch(Exception)
           {
               throw;
           }
           return bRet;
       }
        //

        //DBクローズ
        public void Close()
        {
            if(sqlCon != null)
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
        //トランザクション開始
        public void BeginTransaction()
        {
            try
            {
                sqlTran = sqlCon.BeginTransaction();
            }
            catch(Exception)
            {
                throw;
            }
        }
        //コミット
        public void Commit()
        {
            try
            {
                if(sqlTran != null)
                {
                    sqlTran.Commit();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                sqlTran = null;
            }
        }
        //ロールバック
        public void RollBack()
        {
            try
            {
                if(sqlTran != null)
                {
                    sqlTran.Rollback();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                sqlTran = null;
            }
        }

        public void CreateDataTable(DataTable dt)
        {
            
           // DataRow row = new DataRow();

            //存在しないとき作成する
            var cmdStr = "CREATE TABLE " + tableNmae +"(";

       
                for (int i = 0; i < dt.Columns.Count; i++)
                  {
                    cmdStr += dt.Rows[0][i] + " varchar(100)";
                    if(dt.Columns.Count - 1 > i)
                    {
                        cmdStr += ",";
                    }

                  }
                   cmdStr += ");";

            //サーバー接続開始
            Open();
            using (SqlCommand command = new SqlCommand(cmdStr, sqlCon))
            {    
                try
                { 
                    command.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    //エラーログを出す処理をする
                }
                //finally
                //{

                //}
            
                 // 接続を閉じる
                sqlCon.Close();

            }

        }

        public string [] LoadDB(DataTable dt,string ColumnsName)
        {

            //サーバー接続開始
            Open();
            string sqlQuery = "SELECT * FROM dbo." + tableNmae + " WHERE 名前 = '" + ColumnsName + "'";

            //string sqlQuery = "SELECT * FROM dbo." + tableNmae + " WHERE 名前 = '佐藤'";
            
            string[] colName = new string[dt.Columns.Count];

            string strColu = string.Empty;
            
            // コマンドを作成する
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
 
            // コマンドを実行
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                colName[0] += reader["名前"] as string;
                colName[1] += reader["住所"] as string;
                colName[2] += reader["年齢"] as string;
                colName[3] += reader["職業"] as string;

            }

            // リーダーを閉じる
            reader.Close();

            // 接続を閉じる
            sqlCon.Close();

            return colName;
        }

        //ロウ番号を指定して呼び出す
        public void LoadDB(int RowsNum)
        {

            //サーバー接続開始
            Open();
            string sqlQuery = "SELECT * FROM " + tableNmae;
            // コマンドを作成する
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

            // コマンドを実行
            SqlDataReader reader = cmd.ExecuteReader();

            // DataTable を作成する
            DataTable dtable = new DataTable();
            // SqlDataReader からデータを DataTable に読み込む
            dtable.Load(reader);

            // リーダーを閉じる
            reader.Close();

            // 接続を閉じる
            sqlCon.Close();
        }
        //インサート処理
        public void DBInsert(DataTable dt)
        {
            
            //データベース接続
            Open();
            //トランザクション開始
            BeginTransaction();

            var cmdStrIns = string.Empty;

            cmdStrIns = "INSERT INTO dbo." + tableNmae + "(";
            //カラム名を取得する
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cmdStrIns += dt.Rows[0][i];
                if (dt.Columns.Count - 1 > i)
                {
                    cmdStrIns += ",";
                }
            }  
            
            cmdStrIns += ") VALUES";

            for (int j = 1; j < dt.Rows.Count; j++)
            {
                cmdStrIns += "(@name" + j + ", @pref" + j + ", @age" + j + ", @job" + j + ")";
                if (dt.Rows.Count - 1 > j)
                {
                    cmdStrIns += ",";
                }
            }

            // コマンドを作成する
           SqlCommand cmd = new SqlCommand(cmdStrIns, sqlCon ,sqlTran);

            //インサート処理
            for (int j = 1; j < dt.Rows.Count; j++)
            {                  
                cmd.Parameters.Add(new SqlParameter("@name"+ j, SqlDbType.VarChar, 100)).Value = dt.Rows[j][0];
                cmd.Parameters.Add(new SqlParameter("@pref" + j, SqlDbType.VarChar, 100)).Value = dt.Rows[j][1];
                cmd.Parameters.Add(new SqlParameter("@age" + j, SqlDbType.VarChar, 100)).Value = dt.Rows[j][2];
                cmd.Parameters.Add(new SqlParameter("@job" + j, SqlDbType.VarChar, 100)).Value = dt.Rows[j][3];                   
            }
       
            //接続する
            cmd.ExecuteNonQuery();

            //コミット
            sqlTran.Commit();

            //データベース接続終了
             sqlCon.Close();


        }

        //テーブル削除
        public void DeleteDT()
        {
            var delete = "DROP TABLE " + tableNmae;

             //データベース接続
            Open();

            // コマンドを作成する
            SqlCommand cmd = new SqlCommand(delete, sqlCon);
            //接続する
            try
            { 
                cmd.ExecuteNonQuery();
            }
            catch
            {
                //エラーログを出す処理をする
            }
            finally
            {

            }
        }

        public string[] GetColumsName(DataTable dt)
        {
            //サーバー接続開始
            Open();
            string sqlQuery = "SELECT * FROM dbo." + tableNmae;
            //２行目から読み込み
            string[] colName = new string[dt.Rows.Count-1];
            string strColu = string.Empty;

            int i = 0;

            // コマンドを作成する
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
 
            // コマンドを実行
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable data = new DataTable();
            //
            while (reader.Read())
            {
                colName[i] += reader["名前"] as string;
                i++;
            }

            // リーダーを閉じる
            reader.Close();

            // 接続を閉じる
            sqlCon.Close();

            return colName;
        }

        public object cmdStInsr { get; set; }
    } 



}
