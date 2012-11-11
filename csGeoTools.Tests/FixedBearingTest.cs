using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace csGeoTools.Tests
{
    [TestClass]
    public class FixedBearingTest
    {
        [TestMethod]
        public void Bearing_ReturnsInput_GivenDegrees()
        {
            double degrees = 90.5;
            Assert.AreEqual(degrees, Bearing.DecimalDegrees(degrees).DecimalDegrees());
        }

        [TestMethod]
        public void Conversions_ReturnSaneValues()
        {
            Assert.AreEqual(1.5707963267948966, Bearing.DecimalDegrees(90).Radians());
            Assert.AreEqual(57.29577951308232, Bearing.Radians(1).DecimalDegrees());
        }

        [TestMethod]
        public void Bearing_ReturnsValuesLE360_GivenDegreesOutOfRange()
        {
            Assert.AreEqual(10.0, Bearing.DecimalDegrees(370).DecimalDegrees());
            Assert.AreEqual(350.0, Bearing.DecimalDegrees(-10).DecimalDegrees());
            Assert.AreEqual(350.0, Bearing.DecimalDegrees(-370).DecimalDegrees());
        }
    }
}
