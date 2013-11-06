using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace csGeoTools.CommonModels
{
    [DataContract]
    public class Tag : IComparable<Tag>
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual String Text { get; set; }
        [DataMember]
        public virtual TagType Type { get; set; }

        public Tag() { }

        public virtual int CompareTo(Tag other)
        {
            if (this.Type == other.Type && this.Text.Equals(other.Text))
                return 0;
            return -1;
        }
    }
}
