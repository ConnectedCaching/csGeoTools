using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Waypoint
    {
        [DataMember]
        public int WaypointId { get; set; }
        [DataMember]
        public GeoPoint Location { get; set; }
        [DataMember]
        public List<Tag> Tags { get; set; }
        [DataMember]
        public WaypointType Type { get; set; }
    }
}
