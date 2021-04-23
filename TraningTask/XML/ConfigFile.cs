using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraningTask.XML
{
    //環境設定ファイル
    [System.Xml.Serialization.XmlRoot("Config")]
    public class ConfigFile
    {
        [System.Xml.Serialization.XmlElement("DSN")]
        public string DSN { get; set; }

        //コンストラクタ
        public ConfigFile()
        {
            DSN = null;
        }

    }
}
