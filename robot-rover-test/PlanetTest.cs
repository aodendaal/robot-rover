using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;

namespace RobotRoverTest
{
    [TestClass]
    public class PlanetTest
    {
        [TestMethod]
        public void TestIsValidPosition()
        {
            var planet = new Planet(10, 10);

            Assert.IsTrue(planet.IsValidPosition(0, 0));
            Assert.IsTrue(planet.IsValidPosition(9, 9));
            
            Assert.IsFalse(planet.IsValidPosition(-1, 0));
            Assert.IsFalse(planet.IsValidPosition(0, -1));
            Assert.IsFalse(planet.IsValidPosition(10, 0));
            Assert.IsFalse(planet.IsValidPosition(0, 10));
        }

        [TestMethod]
        public void TestHasScent()
        {
            var planet = new Planet(10, 10);

            Assert.IsFalse(planet.HasScent(1, 1));
        }

        [TestMethod]
        public void TestHasScentInvalidPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.HasScent(11, 11));
        }

        [TestMethod]
        public void TestAddScent()
        {
            var planet = new Planet(10, 10);

            planet.AddScent(1, 1);
            Assert.IsTrue(planet.HasScent(1, 1));
        }

        [TestMethod]
        public void TestAddScentInvalidPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.AddScent(11, 11));
        }
    }
}