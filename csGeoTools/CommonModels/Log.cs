using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Log
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public String Type { get; set; }
        [DataMember]
        public User Author { get; set; }
        [DataMember]
        public String Text { get; set; }
        [DataMember]
        public List<Waypoint> Waypoints { get; set; }
    }
}