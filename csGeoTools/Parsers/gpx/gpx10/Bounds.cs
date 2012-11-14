using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gpx10
{
    [XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/0")]
    public class Bounds
    {
        [XmlAttributeAttribute("minlat")]
        public decimal MinLatitude { get; set; }
        [XmlAttributeAttribute("minlon")]
        public decimal MinLongitude { get; set; }
        [XmlAttributeAttribute("maxlat")]
        public decimal MaxLatitude { get; set; }
        [XmlAttributeAttribute("maxlon")]
        public decimal MaxLongitude { get; set; }
    }
}
