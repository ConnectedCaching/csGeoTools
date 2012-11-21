using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Tag
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Text { get; set; }
    }
}
