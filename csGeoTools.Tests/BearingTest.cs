using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csGeoTools.Tests
{
    [TestClass]
    public class BearingTest
    {
        public GeoPoint p1 = GeoPoint.Parse(0, 0);
        public GeoPoint p2 = GeoPoint.Parse(1, 1);

        [TestMethod]
        public void Between_ReturnsPointToPointBearing_GivenTwoGeoPoints()
        {
            Assert.IsInstanceOfType(Bearing.Between(p1, p2), typeof(PointToPointBearing));
        }

        [TestMethod]
        public void DegreesAndRadians_ReturnFixedBearing()
        {
            Assert.IsInstanceOfType(Bearing.DecimalDegrees(90), typeof(FixedBearing));
            Assert.IsInstanceOfType(Bearing.Radians(90), typeof(FixedBearing));
        }
    }
}
