using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csGeoTools.Vincenty;

namespace csGeoTools.Tests
{
    [TestClass]
    public class PointToPointDistanceTest
    {
        GeoPoint p1 = GeoPoint.Parse(50.117111, -5.477593);
        GeoPoint p2 = GeoPoint.Parse(51.129552, 1.321179);

        [TestMethod]
        public void Distance_MustBeReflexive()
        {
            Distance distance = Distance.Between(p1, p2);
            Assert.AreEqual(distance, Distance.Between(p2, p1));
        }

        [TestMethod]
        public void Distance_ReturnsCorrectValues_GivenZeroDistanceInput()
        {
            Assert.AreEqual(Distance.Meters(0), p1.DistanceTo(p1));
        }

        [TestMethod]
        public void Distance_MustBeCommutative()
        {
            Assert.AreEqual(p2.DistanceTo(p1), p1.DistanceTo(p2));
        }

        [TestMethod]
        public void Calculations_ReturnsSaneValues()
        {
            Assert.AreEqual(492451, Math.Round(Distance.Between(p1, p2).In(MetricUnit.meters)));
        }

        [TestMethod]
        public void Calculations_Work_GivenDifferentMetricUnits()
        {
            double meters = Distance.Between(p1, p2).In(MetricUnit.meters);
            double kilometers = Distance.Between(p1, p2).In(MetricUnit.kilometers);
            Assert.AreEqual(meters / 1000, kilometers);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Calculation_Fails_GivenGeoPointsWithDifferingReferenceEllipsoids()
        {
            GeoPoint p3 = GeoPoint.Parse(0.0, 0.0, Ellipsoid.GRS80);
            p1.DistanceTo(p3);
            p3.DistanceTo(p2);
        }

        [TestMethod]
        public void MidpointComputation_IsCallableFromGeoPoint()
        {
            GeoPoint midpoint = p1.MidpointTo(p2);
            Assert.IsInstanceOfType(midpoint, typeof(GeoPoint));
            Assert.AreEqual(p1.ReferenceEllipsoid, midpoint.ReferenceEllipsoid);
            Assert.AreNotSame(p1, midpoint);
            Assert.AreNotSame(p2, midpoint);
        }

        [TestMethod]
        public void MidpointComputation_ReturnsCorrectResults()
        {
            // accuracy of reference point ~11.1m
            Assert.IsTrue(p1.MidpointTo(p2).DistanceTo(GeoPoint.Parse(50.6728, -2.1148)).In(MetricUnit.meters) < 10);
        }
    }
}
