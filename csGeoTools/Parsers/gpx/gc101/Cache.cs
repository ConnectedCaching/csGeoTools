using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gc101
{
    [XmlTypeAttribute(Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    public class Cache
    {
        [XmlElement("name")]
        public String Name { get; set; }
        [XmlElement("placed_by")]
        public String PlacedBy { get; set; }
        [XmlElement("owner")]
        public User[] Owner;
        [XmlElement("type")]
        public String Type { get; set; }
        [XmlElement("container")]
        public String Container { get; set; }
        [XmlArrayItem("attribute")]
        public Attribute[] attributesField { get; set; }
        [XmlElement("difficulty")]
        public String Difficulty { get; set; }
        [XmlElement("terrain")]
        public String Terrain { get; set; }
        [XmlElement("country")]
        public String Country { get; set; }
        [XmlElement("state")]
        public String State { get; set; }
        [XmlElement("short_description")]
        public Description[] ShortDescription { get; set; }
        [XmlElement("long_description")]
        public Description[] LongDescription { get; set; }
        [XmlElement("encoded_hints")]
        public String EncodedHints { get; set; }
        [XmlArrayItem("log")]
        public Log[] Logs { get; set; }
        [XmlArrayItem("travelbug")]
        public Travelbug[] Travelbugs { get; set; }
        [XmlAttribute("id")]
        public String Id { get; set; }
        [XmlAttribute("available")]
        public String _available { get; set; }
        public bool Available
        {
            get
            {
                return _available.Equals(true.ToString());
            }
            set
            {
                _available = value.ToString();
            }
        }
        [XmlAttribute("archived")]
        public string _archived { get; set; }
        public bool Archived
        {
            get
            {
                return _archived.Equals(true.ToString());
            }
            set
            {
                _archived = value.ToString();
            }
        }
    }
}
