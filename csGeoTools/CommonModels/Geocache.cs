using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    class Geocache
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
        public CacheSize Size;
        [DataMember]
        public int Difficulty;
        [DataMember]
        public int Terrain;
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String EncodedHint { get; set; }
        [DataMember]
        public List<Log> Logs;
        [DataMember]
        public List<Travelbug> Travelbugs { get; set; }
        [DataMember]
        public bool AlreadyFound;
        [DataMember]
        public bool Archived { get; set; }
        [DataMember]
        public bool Disabled { get; set; }
    }
}
