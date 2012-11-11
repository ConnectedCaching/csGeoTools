using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csGeoTools.Tests
{
    [TestClass]
    public class ProjectionTest
    {
        GeoPoint geoPoint = GeoPoint.Parse(-33.636292, 151.331842);

        [TestMethod]
        public void Project_ReturnsGeoPoint()
        {
            Assert.IsInstanceOfType(geoPoint.Project(Distance.Meters(100), Bearing.DecimalDegrees(90)), typeof(GeoPoint));
        }

        [TestMethod]
        public void Project_HasToBeChainable()
        {
            GeoPoint pointTwo = geoPoint
                .Project(Distance.Meters(100), Bearing.DecimalDegrees(0))
                .Project(Distance.Meters(100), Bearing.DecimalDegrees(90))
                .Project(Distance.Meters(100), Bearing.DecimalDegrees(180))
                .Project(Distance.Meters(100), Bearing.DecimalDegrees(270));
            Assert.IsTrue(pointTwo.DistanceTo(geoPoint).In(MetricUnit.meters) < 0.0015);
        }

        [TestMethod]
        public void Project_ReturnsExpectedDistance()
        {
            GeoPoint pointTwo = geoPoint.Project(Distance.Meters(587), Bearing.DecimalDegrees(237));
            Assert.AreEqual(587, Math.Round(Distance.Between(geoPoint, pointTwo).In(MetricUnit.meters)));
        }

        [TestMethod]
        public void Project_ReturnsExpectedBearing()
        {
            GeoPoint pointTwo = geoPoint.Project(Distance.Kilometers(1), Bearing.Degrees(90));
            Assert.AreEqual(90, Math.Round(geoPoint.BearingTo(pointTwo).DecimalDegrees()));
        }

        [TestMethod]
        public void Project_ReturnsSaneValues()
        {
            GeoPoint p2 = geoPoint.Project(Distance.Meters(300), Bearing.DecimalDegrees(10));
            Assert.IsTrue(p2.DistanceTo(GeoPoint.Parse(-33.63364, 151.33240)).In(MetricUnit.meters) < 1);
        }
    }
}
