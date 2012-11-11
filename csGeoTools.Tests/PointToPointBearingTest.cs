using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csGeoTools.Vincenty;

namespace csGeoTools.Tests
{
    [TestClass]
    public class PointToPointBearingTest
    {
        GeoPoint p1 = GeoPoint.Parse(51.129552, 1.321179);
        GeoPoint p2 = GeoPoint.Parse(50.117111, -5.477593);

        [TestMethod]
        public void Computation_Works_GivenZeroDegreesInput()
        {
            Assert.AreEqual(Bearing.Degrees(0), p1.BearingTo(p1));
        }

        [TestMethod]
        public void Computation_ReturnsCorrectResults()
        {
            Assert.AreEqual(p1.InitialBearingTo(p2), p1.BearingTo(p2));
            Assert.AreEqual(259.4343762289729, p1.BearingTo(p2).DecimalDegrees());
            Assert.AreEqual(254.17629278737843, p1.FinalBearingTo(p2).DecimalDegrees());
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Calculation_Fails_GivenGeoPointsWithDifferingReferenceEllipsoids()
        {
            GeoPoint p3 = GeoPoint.Parse(0.0, 0.0, Ellipsoid.GRS80);
            p1.BearingTo(p3);
            p3.BearingTo(p2);
        }
    }
}
