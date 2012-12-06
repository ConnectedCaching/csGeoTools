using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Travelbug
    {
        [DataMember]
        public String TravelbugId { get; set; }
        [DataMember]
        public String Name { get; set; }

        public Travelbug() { }

        internal static List<Travelbug> Parse(Parsers.gpx.gc101.Travelbug[] bugs)
        {
            List<Travelbug> travelbugs = new List<Travelbug>();
            foreach (var item in bugs)
            {
                travelbugs.Add(new Travelbug()
                {
                    Name = item.Name,
                    TravelbugId = item.Ref
                });
            }
            return travelbugs;
        }
    }
}
