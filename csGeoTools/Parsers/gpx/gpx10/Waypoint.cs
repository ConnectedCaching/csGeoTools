using csGeoTools.Parsers.gpx.gc101;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gpx10
{
    [XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/0")]
    public class Waypoint
    {
        [XmlElementAttribute("ele")]
        public decimal Elevation { get; set; }
        [XmlElementAttribute("time")]
        public String _time { get; set; }
        public DateTime Time
        {
            get
            {
                return DateTime.ParseExact(_time, "yyyy-MM-dd HH':'mm':'ss 'GMT'", CultureInfo.InvariantCulture);
            }
            set
            {
                _time = value.ToString("yyyy-MM-dd HH':'mm':'ss 'GMT'");
            }
        }
        [XmlElementAttribute("magvar")]
        public decimal Magvar { get; set; }
        [XmlElementAttribute("geoidheight")]
        public decimal GeoIdHeight { get; set; }
        [XmlElementAttribute("name")]
        public String Name { get; set; }
        [XmlElementAttribute("cmt")]
        public String Comment { get; set; }
        [XmlElementAttribute("desc")]
        public String Description { get; set; }
        [XmlElementAttribute("src")]
        public String Source { get; set; }
        [XmlElementAttribute("url")]
        public String Url { get; set; }
        [XmlElementAttribute("urlname")]
        public String Urlname { get; set; }
        [XmlElementAttribute("sym")]
        public String Sym { get; set; }
        [XmlElementAttribute("type")]
        public String Type { get; set; }
        [XmlElementAttribute("fix")]
        public FixType Fix { get; set; }
        [XmlElementAttribute("sat")]
        public int Satellite { get; set; }
        [XmlElementAttribute("hdop")]
        public decimal HorizontalDop { get; set; }
        [XmlElementAttribute("vdop")]
        public decimal VerticalDop { get; set; }
        [XmlElementAttribute("pdop")]
        public decimal PDop { get; set; }
        [XmlElementAttribute("ageofdgpsdata")]
        public decimal AgeOfDGpsData { get; set; }
        [XmlElementAttribute("dgpsid")]
        public int DifferentialGpsId { get; set; }
        [XmlElementAttribute("cache")]
        public Cache Cache { get; set; }
        [XmlAttributeAttribute("lat")]
        public decimal Latitude { get; set; }
        [XmlAttributeAttribute("lon")]
        public decimal Longitude { get; set; }
    }
}
