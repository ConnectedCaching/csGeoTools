using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Geocache
    {
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public GeoPoint Location { get; set; }
        [DataMember]
        public User Owner { get; set; }
        [DataMember]
        public String Url { get; set; }
        [DataMember]
        public List<Waypoint> Waypoints { get; set; }
        [DataMember]
        public List<Tag> Tags { get; set; }
        [DataMember]
        public CacheSize Size { get; set; }
        [DataMember]
        public int Difficulty { get; set; }
        [DataMember]
        public int Terrain { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String EncodedHint { get; set; }
        [DataMember]
        public List<Log> Logs { get; set; }
        [DataMember]
        public List<Travelbug> Travelbugs { get; set; }
        [DataMember]
        public bool AlreadyFound { get; set; }
        [DataMember]
        public bool Archived { get; set; }
        [DataMember]
        public bool Disabled { get; set; }
    }
}
