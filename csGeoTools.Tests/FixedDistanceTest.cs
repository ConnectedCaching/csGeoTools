using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csGeoTools.Tests
{
    [TestClass]
    public class FixedDistanceTest
    {
        [TestMethod]
        public void FixedDistance_ReturnsInput_GivenMeters()
        {
            FixedDistance distance = new FixedDistance(12367);
            Assert.AreEqual(12367, distance.In(MetricUnit.meters));
        }

        [TestMethod]
        public void Conversions_ReturnSaneValues()
        {
            FixedDistance distance = new FixedDistance(10000);
            Assert.AreEqual(10.0, distance.In(MetricUnit.kilometers));
        }

        [TestMethod]
        public void Conversion_WorksWithImperialUnits()
        {
            FixedDistance distance = new FixedDistance(10000);
            Assert.AreEqual(32808, Math.Round(distance.In(ImperialUnit.feet)));
        }
    }
}
