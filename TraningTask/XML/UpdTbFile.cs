using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TraningTask.XML
{
    [XmlRoot("TABLE")]
    class UpdTbFile
    {
        [XmlElement("TABLE_NAME")]
        public string TABLE_NAME { get; set; }

        [XmlElement("NAME")]
        public string USER_NAME { get; set; }

        [XmlElement("PREF")]
        public string USER_PREF { get; set; }

        [XmlElement("AGE")]
        public string USER_AGE { get; set; }

        [XmlElement("JOB")]
        public string USER_JOB { get; set; }

        public UpdTbFile()
        {
            TABLE_NAME = null;

            USER_NAME = null;
            USER_PREF = null;
            USER_AGE = null;
            USER_JOB = null;

        }
             
    }
}
