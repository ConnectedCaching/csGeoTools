using System;
using System.Collections.Generic;
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
        //[XmlIgnoreAttribute()]
        //public bool eleSpecified { get; set; }
        [XmlElementAttribute("time")]
        public DateTime Time { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool timeSpecified { get; set; }
        [XmlElementAttribute("magvar")]
        public decimal Magvar { get; set; }
        //[XmlIgnoreAttribute()]
        //public bool magvarSpecified { get; set; }
        [XmlElementAttribute("geoidheight")]
        public decimal GeoIdHeight { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool geoidheightSpecified { get; set; }

        [XmlElementAttribute("name")]
        public String Name { get; set; }
        [XmlElementAttribute("cmt")]
        public String Comment { get; set; }
        [XmlElementAttribute("desc")]
        public String Description { get; set; }
        [XmlElementAttribute("src")]
        public String Source { get; set; }
        [XmlElementAttribute("url")]                        // , DataType = "anyURI"
        public String Url { get; set; }
        [XmlElementAttribute("urlname")]
        public String Urlname { get; set; }
        [XmlElementAttribute("sym")]
        public String Sym { get; set; }
        [XmlElementAttribute("type")]
        public String Type { get; set; }

        [XmlElementAttribute("fix")]
        public FixType Fix { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool fixSpecified { get; set; }
        [XmlElementAttribute("sat")]                        // , DataType = "nonNegativeInteger"
        public int Satellite { get; set; }
        [XmlElementAttribute("hdop")]
        public decimal HorizontalDop { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool hdopSpecified { get; set; }
        [XmlElementAttribute("vdop")]
        public decimal VerticalDop { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool vdopSpecified { get; set; }
        [XmlElementAttribute("pdop")]
        public decimal PDop { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool pdopSpecified { get; set; }
        [XmlElementAttribute("ageofdgpsdata")]
        public decimal AgeOfDGpsData { get; set; }
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ageofdgpsdataSpecified { get; set; }
        [XmlElementAttribute("dgpsid")]                     // , DataType = "integer"
        public int DifferentialGpsId { get; set; }
        //[System.Xml.Serialization.XmlAnyElementAttribute()]
        //public System.Xml.XmlElement[] Any { get; set; }
        [XmlAttributeAttribute("lat")]
        public decimal Latitude { get; set; }
        [XmlAttributeAttribute("lon")]
        public decimal Longitude { get; set; }
    }
}
