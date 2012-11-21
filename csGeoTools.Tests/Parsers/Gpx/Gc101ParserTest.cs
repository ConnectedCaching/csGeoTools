using csGeoTools.Parsers.gpx.gc101;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace csGeoTools.Tests.Parsers.Gpx
{
    [TestClass]
    public class Gc101ParserTest
    {
        [TestMethod]
        public void GcParsing_CorrectlyParses_GivenGcGpxFile()
        {
            Type gpxType = typeof(csGeoTools.Parsers.gpx.gpx10.Gpx);
            XmlSerializer ser = new XmlSerializer(gpxType);
            csGeoTools.Parsers.gpx.gpx10.Gpx _gpx;
            using (XmlReader reader = XmlReader.Create("..\\..\\Parsers\\Gpx\\Gc101Sample.gpx"))
            {
                _gpx = (csGeoTools.Parsers.gpx.gpx10.Gpx)ser.Deserialize(reader);
            }
            Assert.IsInstanceOfType(_gpx, gpxType);
            Assert.IsInstanceOfType(_gpx.Waypoints.First().Cache.First(), typeof(Cache));
        }
    }
}
