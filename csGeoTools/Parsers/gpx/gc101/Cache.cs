using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gc101
{
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.groundspeak.com/cache/1/0/1")]
    public class Cache
    {
        [XmlElementAttribute("name")]
        public String Name { get; set; }
        [XmlElementAttribute("placed_by")]
        public String PlacedBy { get; set; }
        [XmlElementAttribute("owner")]
        public User[] Owner;
        [XmlElementAttribute("type")]
        public String Type { get; set; }
        [XmlElementAttribute("container")]
        public String Container { get; set; }
        [XmlArrayItemAttribute("attribute")]
        public Attribute[] attributesField { get; set; }
        [XmlElementAttribute("difficulty")]
        public String Difficulty { get; set; }
        [XmlElementAttribute("terrain")]
        public String Terrain { get; set; }
        [XmlElementAttribute("country")]
        public String Country { get; set; }
        [XmlElementAttribute("state")]
        public String State { get; set; }
        [XmlElementAttribute("short_description")]
        public Description[] ShortDescription { get; set; }
        [XmlElementAttribute("long_description")]
        public Description[] LongDescription { get; set; }
        [XmlElementAttribute("encoded_hints")]
        public String EncodedHints { get; set; }
        [XmlArrayItemAttribute("log")]
        public Log[][] Logs { get; set; }
        [XmlArrayItemAttribute("travelbug")]
        public Travelbug[][] Travelbugs { get; set; }
        [XmlAttributeAttribute("id")]
        public String Id { get; set; }
        [XmlAttributeAttribute("available")]
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
        [XmlAttributeAttribute("archived")]
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
