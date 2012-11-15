using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using csGeoTools.Parsers.gpx.gpx10;
using System.Xml.Serialization;
using System.Xml;


namespace csGeoTools.Tests.Parsers.Gpx
{
    [TestClass]
    public class Gpx10ParserTest
    {
        [TestMethod]
        public void GpxParsing_CorrectlyParses_GivenGpxFile()
        {
            Type gpxType = typeof(csGeoTools.Parsers.gpx.gpx10.Gpx);
            XmlSerializer ser = new XmlSerializer(gpxType);
            csGeoTools.Parsers.gpx.gpx10.Gpx gpx;
            using (XmlReader reader = XmlReader.Create("..\\..\\Parsers\\Gpx\\Gpx10Sample.gpx"))
            {
                gpx = (csGeoTools.Parsers.gpx.gpx10.Gpx)ser.Deserialize(reader);
            }
            Assert.IsInstanceOfType(gpx, gpxType);
        }
    }
}
