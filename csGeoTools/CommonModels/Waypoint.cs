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
        public int Id { get; set; }
        [DataMember]
        public GeoPoint Location { get; set; }
        [DataMember]
        public List<Tag> Tags { get; set; }
        [DataMember]
        public WaypointType Type { get; set; }

        public Waypoint() { }

        internal static List<Waypoint> Parse(Parsers.gpx.gc101.LogWaypoint[] logWaypoint)
        {
            List<Waypoint> waypoints = new List<Waypoint>();
            foreach (var item in logWaypoint)
            {
                waypoints.Add(new Waypoint()
                {
                    Location = GeoPoint.Parse(Double.Parse(item.Latitude), Double.Parse(item.Longitude)),
                    Tags = new List<Tag>()
                    {
                        new Tag() { Text = "LogWaypoint", Type = TagType.System }
                    }
                });
            }
            return waypoints;
        }
    }
}
