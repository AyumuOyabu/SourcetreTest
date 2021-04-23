using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace TraningTask.XML
{
    class XMLControl
    {

        public static T ReadFile<T>(string strReadpath)
        {
            T retObj = default(T);

            //ファイルの存在チェック
            if (File.Exists(strReadpath) == false)
                return retObj;

            //読み込み先のXMLストリーム作成
            FileStream fStream = new FileStream(strReadpath, FileMode.Open, FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream, Encoding.UTF8);

            //読み込み
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                retObj = (T)serializer.Deserialize(fStream);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fStream.Close();
            }
          
            return retObj;
        }

        //XML出力

    }
}
