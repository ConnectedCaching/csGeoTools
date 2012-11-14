using csGeoTools.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csGeoTools.Tests.Parsers
{
    [TestClass]
    public class DecimalDegreeParserTest
    {
        GeoPointParser parser = new DecimalDegreeParser();

        [TestMethod]
        public void Parser_IsAbleToParse_GivenStandardDecimalDegreeFormats()
        {
            Assert.IsTrue(parser.CanParse("46.414167, -6.927500"));
            Assert.IsTrue(parser.CanParse("46.414167°, 6.927500°"));
            Assert.IsTrue(parser.CanParse("46.414167 6.927500"));
            Assert.IsTrue(parser.CanParse("-46.414167 , 6.927500"));
            Assert.IsTrue(parser.CanParse("38.889722°, -77.008889°"));
        }
        
        [TestMethod]
        public void Parser_IsNotAbleToParse_GivenGarbage()
        {
            Assert.IsFalse(parser.CanParse("LOL KITTENZ 1.1, 2.2"));
            Assert.IsFalse(parser.CanParse("1.0 1.0, 1.0"));
            Assert.IsFalse(parser.CanParse(""));
            Assert.IsFalse(parser.CanParse(" "));
        }
        
        [TestMethod]
        public void Parser_IsNotAbleToParse_GivenLocalizedInput()
        {
            Assert.IsFalse(parser.CanParse("38,889722°, -77,008889°"));
        }
        
        [TestMethod]
        public void Parse_ParsesCorrectly_GivenNECoordinates()
        {
            GeoPoint geoPoint = parser.Parse("46.414167°, 6.927500°", GeoConstants.DEFAULT_ELLIPSOID);
            Assert.AreEqual(46.414167, geoPoint.Latitude);
            Assert.AreEqual(6.927500, geoPoint.Longitude);
        }

        [TestMethod]
        public void Parse_ParsesCorrectly_GivenSECoordinates()
        {
            GeoPoint geoPoint = parser.Parse("-33.855270°, 151.209725°", GeoConstants.DEFAULT_ELLIPSOID);
            Assert.AreEqual(-33.855270, geoPoint.Latitude);
            Assert.AreEqual(151.209725, geoPoint.Longitude);
        }

        [TestMethod]
        public void Parse_ParsesCorrectly_GivenNWCoordinates()
        {
            GeoPoint geoPoint = parser.Parse("50.116973°, -122.945424°", GeoConstants.DEFAULT_ELLIPSOID);
            Assert.AreEqual(50.116973, geoPoint.Latitude);
            Assert.AreEqual(-122.945424, geoPoint.Longitude);
        }

        [TestMethod]
        public void Parse_ParsesCorrectly_GivenSWCoordinates()
        {
            GeoPoint geoPoint = parser.Parse("-14.170074°, -141.236336°", GeoConstants.DEFAULT_ELLIPSOID);
            Assert.AreEqual(-14.170074, geoPoint.Latitude);
            Assert.AreEqual(-141.236336, geoPoint.Longitude);
        }
        
        [TestMethod]
        public void Parse_ParsesCorrectly_GivenZeroedCoordinates()
        {
            GeoPoint geoPoint = parser.Parse("0.0°, 0.0°", GeoConstants.DEFAULT_ELLIPSOID);
            Assert.AreEqual(0.0, geoPoint.Latitude);
            Assert.AreEqual(0.0, geoPoint.Longitude);
        }
    }
}
