using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gpx10
{
    [XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/0")]
    public class Track
    {
        [XmlElementAttribute("name")]
        public string Name { get; set; }
        [XmlElementAttribute("cmt")]
        public string Comment { get; set; }
        [XmlElementAttribute("desc")]
        public string Description { get; set; }
        [XmlElementAttribute("src")]
        public string Source { get; set; }
        [XmlElementAttribute("url")]
        public string Url { get; set; }
        [XmlElementAttribute("urlname")]
        public string Urlname { get; set; }
        [XmlElementAttribute("number")]
        public int Number { get; set; }
        [XmlArrayItemAttribute("trkpt", typeof(Trackpoint))]
        public Trackpoint[] TrackSegments { get; set; }
    }
}
