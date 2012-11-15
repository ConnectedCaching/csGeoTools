﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace csGeoTools.Parsers.gpx.gpx10
{
    [XmlTypeAttribute(Namespace = "http://www.topografix.com/GPX/1/0")]
    [XmlRootAttribute(ElementName="gpx", Namespace = "http://www.topografix.com/GPX/1/0")]
    public class Gpx
    {
        [XmlElementAttribute("name")]
        public String Name { get; set; }
        [XmlElementAttribute("desc")]
        public String Description { get; set; }
        [XmlElementAttribute("author")]
        public String Author { get; set; }
        [XmlElementAttribute("email")]
        public String Emailadress { get; set; }
        [XmlElementAttribute(DataType = "anyURI")]
        public String Url { get; set; }
        [XmlElementAttribute("urlname")]
        public String Urlname { get; set; }
        [XmlElementAttribute("time")]
        public String _time { get; set; }
        public DateTime Time
        {
            get
            {
                return DateTime.ParseExact(_time, "yyyy-MM-dd HH':'mm':'ss 'GMT'", CultureInfo.InvariantCulture);
            }
            set
            {
                _time = value.ToString("yyyy-MM-dd HH':'mm':'ss 'GMT'");
            }
        }
        [XmlElementAttribute("keywords")]
        public String Keywords { get; set; }
        [XmlElementAttribute("bounds")]
        public Bounds Bounds { get; set; }
        [XmlElementAttribute("wpt")]
        public Waypoint[] Waypoints { get; set; }
        [XmlElementAttribute("rte")]
        public Route[] Routes { get; set; }
        [XmlElementAttribute("trk")]
        public Track[] Tracks { get; set; }
        [XmlAttributeAttribute("version")]
        public String Version { get; set; }
        [XmlAttributeAttribute("creator")]
        public String Creator { get; set; }

        public Gpx()
        {
            this.Version = "1.0";
        }
    }
}
