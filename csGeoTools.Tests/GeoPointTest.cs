using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using csGeoTools.Vincenty;

namespace csGeoTools.Tests
{
    [TestClass]
    public class GeoPointTest
    {
        CultureInfo defaultCulture = CultureInfo.InvariantCulture;

        [TestMethod]
        public void Parse_DoesNotAlter_GivenInput()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual("46.414167, 6.9275", geoPoint.AsDd());
		}

        [TestMethod]
        public void Parse_ReturnsGeoPoint_GivenDecimalDegreeInput()
        {
            Assert.IsInstanceOfType(GeoPoint.Parse("-33.855270°, 151.209725°"), typeof(GeoPoint));
            Assert.IsInstanceOfType(GeoPoint.Parse("-33.855270 151.209725"), typeof(GeoPoint));
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Parse_ThrowsException_GivenGarbageInput()
        {
            GeoPoint.Parse("Foobaz");
        }

        [TestMethod]
        public void Parse_TruncatesTrailingZeros()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.41400, 6.927500);
            Assert.AreEqual("46.414, 6.9275", geoPoint.AsDd());
		}

        [TestMethod]
        public void GeoPoint_HasMaximumPrecisionOf6DecimalPlaces_GivenAnyInput()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167123, 6.927500123);
            Assert.AreEqual("46.414167, 6.9275", geoPoint.AsDd());
        }

        [TestMethod]
        public void GeoPoint_IsAbleToProduceLocalizedOutput()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-33.855270, 151.209725);
            Assert.AreEqual("-33,85527, 151,209725", geoPoint.AsDd(CultureInfo.GetCultureInfo("de")));
        }

        [TestMethod]
        public void As_IsAbleToProduceCorrectOutput_GivenParameter()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual(geoPoint.As(GeoPointFormat.DD), geoPoint.AsDd());
            Assert.AreEqual(geoPoint.As(GeoPointFormat.DD), geoPoint.As(GeoPointFormat.DecimalDegrees));
        }

        [TestMethod]
        public void As_IsAbleToProduceCorrectOutput_GivenParameterAndLocalization()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-14.170074, -141.236336);
            Assert.AreEqual(geoPoint.As(GeoPointFormat.DD), geoPoint.AsDd());
            Assert.AreEqual("-14,170074, -141,236336", geoPoint.As(GeoPointFormat.DecimalDegrees, CultureInfo.GetCultureInfo("de")));
        }

        [TestMethod]
        public void AsDm_ConvertsCoordinatesCorrectly_GivenNECoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual("N46° 24.850 E006° 55.650", geoPoint.AsDm());
        }

        [TestMethod]
        public void AsDm_ConvertsCoordinatesCorrectly_GivenSECoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-33.855270, 151.209725);
            Assert.AreEqual("S33° 51.316 E151° 12.583", geoPoint.AsDm());
        }

        [TestMethod]
        public void AsDm_ConvertsCoordinatesCorrectly_GivenNWCoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(50.116973, -122.945424);
            Assert.AreEqual("N50° 07.018 W122° 56.725", geoPoint.AsDm());
        }

        [TestMethod]
        public void AsDm_ConvertsCoordinatesCorrectly_GivenSWCoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-14.170074, -141.236336);
            Assert.AreEqual("S14° 10.204 W141° 14.180", geoPoint.AsDm());
        }

        [TestMethod]
        public void AsDms_ConvertsCoordinatesCorrectly_GivenNECoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual("N46° 24' 51.001\" E6° 55' 39\"", geoPoint.AsDms());
        }

        [TestMethod]
        public void AsDms_ConvertsCoordinatesCorrectly_GivenSECoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-33.855270, 151.209725);
            Assert.AreEqual("S33° 51' 18.972\" E151° 12' 35.01\"", geoPoint.AsDms());
        }

        [TestMethod]
        public void AsDms_ConvertsCoordinatesCorrectly_GivenNWCoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(50.116973, -122.945424);
            Assert.AreEqual("N50° 7' 1.103\" W122° 56' 43.526\"", geoPoint.AsDms());
        }

        [TestMethod]
        public void AsDms_ConvertsCoordinatesCorrectly_GivenSWCoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-14.170074, -141.236336);
            Assert.AreEqual("S14° 10' 12.266\" W141° 14' 10.81\"", geoPoint.AsDms());
        }

        [TestMethod]
        public void AsDms_ConvertsCoordinatesCorrectly_GivenZeroedCoordinates()
        {
            GeoPoint geoPoint = GeoPoint.Parse(0, 0);
            Assert.AreEqual("0° 0' 0\" 0° 0' 0\"", geoPoint.AsDms());
        }

        [TestMethod]
        public void AsDms_IsAbleToProduceLocalizedOutput()
        {
            GeoPoint geoPoint = GeoPoint.Parse(-33.855270, 151.209725);
            Assert.AreEqual("S33° 51' 18,972\" E151° 12' 35,01\"", geoPoint.AsDms(CultureInfo.GetCultureInfo("de")));
        }

        [TestMethod]
        public void AsDms_IsAbleToProduceCorrectOutput_GivenParameterizedAs()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual(geoPoint.AsDms(), geoPoint.As(GeoPointFormat.DMS));
            Assert.AreEqual(geoPoint.As(GeoPointFormat.DMS), geoPoint.As(GeoPointFormat.DegreesMinutesSeconds));
        }

        [TestMethod]
        public void AsDms_IsAbleToProduceCorrectOutput_GivenParameterizedAsAndLocalization()
        {
            GeoPoint geoPoint = GeoPoint.Parse(46.414167, 6.927500);
            Assert.AreEqual(geoPoint.AsDms(CultureInfo.GetCultureInfo("de")), 
                geoPoint.As(GeoPointFormat.DegreesMinutesSeconds, CultureInfo.GetCultureInfo("de")));
        }

        [TestMethod]
        public void Project_ReturnsNewGeoPointInstance()
        {
            GeoPoint geoPoint = GeoPoint.Parse(0.0, 0.0);
            GeoPoint pointTwo = geoPoint.Project(Distance.Kilometers(5), Bearing.DecimalDegrees(90));
            Assert.IsInstanceOfType(pointTwo, typeof(GeoPoint));
            Assert.AreNotSame(geoPoint, pointTwo);
        }

        [TestMethod]
        public void Convert_WorksIfNoConversionHasToBeDone()
        {
            GeoPoint geoPoint = GeoPoint.Parse(0.0, 0.0, Ellipsoid.WGS84);
            Assert.IsInstanceOfType(geoPoint.ConvertTo(GeoConstants.DEFAULT_ELLIPSOID), typeof(GeoPoint));
            Assert.AreEqual(geoPoint.ConvertTo(GeoConstants.DEFAULT_ELLIPSOID).ReferenceEllipsoid, GeoConstants.DEFAULT_ELLIPSOID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Convert_ThrowsAnException_GivenUnsupportedInputs()
        {
            GeoPoint.Parse(0.0, 0.0).ConvertTo(Ellipsoid.GRS80);
        }
    }
}
