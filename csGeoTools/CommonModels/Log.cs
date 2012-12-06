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

        public Log() { }

        internal static List<Log> Parse(Parsers.gpx.gc101.Log[] logs)
        {
            List<Log> parsedLogs = new List<Log>();
            foreach (var item in logs)
            {
                parsedLogs.Add(new Log()
                {
                    Author = new User()
                    {
                        Name = item.Finder.First().Name,
                        Id = int.Parse(item.Finder.First().Id)
                    },
                    Date = item.Date,
                    Id = int.Parse(item.Id),
                    Text = item.Text.First().value,
                    Type = item.Type,
                    Waypoints = Waypoint.Parse(item.LogWayPoints)
                });
            }
            return parsedLogs;
        }
    }
}