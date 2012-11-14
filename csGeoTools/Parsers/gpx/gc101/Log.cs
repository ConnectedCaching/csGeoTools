using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gc101
{
    [XmlTypeAttribute(Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    public class Log
    {
        [XmlElementAttribute("date")]
        public String Date { get; set; }
        [XmlElementAttribute("type")]
        public String Type { get; set; }
        [XmlElementAttribute("finder")]
        public User[] Finder { get; set; }
        [XmlElementAttribute("text")]
        public LogText[] Text { get; set; }
        [XmlElementAttribute("log_wpt")]
        public LogWaypoint[] LogWayPoints { get; set; }
        [XmlAttributeAttribute("id")]
        public String Id { get; set; }
    }

    [XmlTypeAttribute(Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    public class LogWaypoint
    {
        [XmlAttributeAttribute("lat")]
        public String Latitude { get; set; }
        [XmlAttributeAttribute("lon")]
        public String Longitude { get; set; }
	}

    [XmlTypeAttribute(Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    public class LogText
    {
        [XmlTextAttribute()]
        public String value { get; set; }
		[XmlAttributeAttribute("encoded")]
        public String _encoded { get; set; }
		public bool IsEncoded
        {
            get
            {
                return _encoded.Equals(true.ToString());
            }
            set
            {
                _encoded = value.ToString();
            }
        }
	}
}
