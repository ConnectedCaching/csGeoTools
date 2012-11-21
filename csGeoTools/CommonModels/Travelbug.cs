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
    }
}
