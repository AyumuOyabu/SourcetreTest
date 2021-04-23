using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraningTask
{
    class SystemParam
     {
        //環境設定ファイル
        public static string CONF_FILE = "Config.xml";
        public static string strConfFilPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, CONF_FILE);
        public static XML.ConfigFile ComfigFile { get; set; }

        // 更新対象設定ファイル
        public static string TABLE_FILE = "DataTable.xml";              
        public static string strUpdTblFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, TABLE_FILE);
        public static XML.UpdTbFile UpdTblFile { get; set; }


        // 禁則文字
        public static char[] illegalChars = new char[] { '\\', '/', ':', '*', '?', '"', '\'', '<', '>', '|' };
   
    }
}
