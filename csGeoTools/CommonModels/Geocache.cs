using csGeoTools.Parsers.gpx.gpx10;
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
        public Double Difficulty { get; set; }
        [DataMember]
        public Double Terrain { get; set; }
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

        public Geocache() { }

        public static List<Geocache> Parse(Gpx gpx)
        {
            List<Geocache> caches = new List<Geocache>();

            foreach (var item in gpx.Waypoints)
            {
                foreach (var singleCache in item.Cache)
                {
                    Geocache cache = new Geocache();
                    cache.Id = item.Name;
                    cache.Description = item.Description;
                    cache.Difficulty = singleCache.Difficulty;
                    cache.Terrain = singleCache.Terrain;
                    cache.AlreadyFound = false;
                    cache.Archived = singleCache.Archived;
                    cache.Disabled = singleCache.Available;
                    cache.EncodedHint = singleCache.EncodedHints;
                    cache.Location = GeoPoint.Parse((double)item.Latitude, (double)item.Longitude);
                    cache.Logs = Log.Parse(singleCache.Logs);
                    cache.Name = singleCache.Name;
                    cache.Owner = new User()
                    {
                        Name = singleCache.Owner.First().Name,
                        Id = int.Parse(singleCache.Owner.First().Id)
                    };
                    cache.Size = (CacheSize)Enum.Parse(typeof(CacheSize), singleCache.Container, true);
                    cache.Travelbugs = Travelbug.Parse(singleCache.Travelbugs);
                    cache.Url = item.Url;
                    foreach (var attribute in singleCache.attributesField)
                    {
                        cache.Tags.Add(new Tag()
                        {
                            Type = TagType.Attribute,
                            Text = (attribute.Inc == 1) ? attribute.Value : "not " + attribute.Value
                        });
                    }
                    cache.Tags.Add(new Tag() { Type = TagType.System, Text = singleCache.Type });
                }
            }
            return caches;
        }
    }
}
