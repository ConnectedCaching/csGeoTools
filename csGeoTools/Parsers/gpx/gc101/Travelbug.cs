using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gc101
{
    [XmlTypeAttribute(Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    class Travelbug
    {
        public String Name { get; set; }
        [XmlAttributeAttribute("id")]
        public String Id { get; set; }
        [XmlAttributeAttribute("ref")]
        public string Ref { get; set; }
    }
}
