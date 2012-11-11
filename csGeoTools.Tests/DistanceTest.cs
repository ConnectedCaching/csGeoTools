using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csGeoTools.Tests
{
    [TestClass]
    public class DistanceTest
    {
        GeoPoint p1 = GeoPoint.Parse(0, 0);
        GeoPoint p2 = GeoPoint.Parse(1, 1);

        [TestMethod]
        public void Between_ReturnsPointToPointDistance_GivenTwoGeoPoints()
        {
            Assert.IsInstanceOfType(Distance.Between(p1, p2), typeof(PointToPointDistance));
        }

        [TestMethod]
        public void MetersAndKilometers_ReturnFixedDistance()
        {
            Assert.IsInstanceOfType(Distance.Meters(5), typeof(FixedDistance));
            Assert.IsInstanceOfType(Distance.Kilometers(42), typeof(FixedDistance));
        }

        [TestMethod]
        public void Calculations_ReturnFixedDistances()
        {
            Assert.IsInstanceOfType(Distance.Between(p1, p2).AddDistance(Distance.Meters(100)), typeof(FixedDistance));
            Assert.IsInstanceOfType(Distance.Between(p1, p2).SubtractDistance(Distance.Meters(100)), typeof(FixedDistance));
        }

        [TestMethod]
        public void Calculations_ReturnSaneValues()
        {
            Assert.AreEqual<Distance>(Distance.Meters(50).AddDistance(Distance.Kilometers(1)), Distance.Kilometers(1.05));
            Assert.AreEqual<Distance>(Distance.Meters(500).SubtractDistance(Distance.Meters(250)), Distance.Meters(250));
        }

        [TestMethod]
        public void Calculations_SupportMetricAndImperialUnits()
        {
            Assert.AreEqual(Math.Round(Distance.Meters(100).AddDistance(Distance.Yards(50)).In(MetricUnit.meters)), 146);
        }
    }
}
