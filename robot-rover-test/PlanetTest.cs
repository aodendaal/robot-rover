using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;

namespace RobotRoverTest
{
    [TestClass]
    public class PlanetTest
    {
        [TestMethod]
        public void CheckWidthAndHeight()
        {
            var planet = new Planet(10, 10);
            Assert.AreEqual(10, planet.Width);
            Assert.AreEqual(10, planet.Height);
        }

        [TestMethod]
        public void TestIsValidPosition()
        {
            var planet = new Planet(10, 10);

            Assert.IsTrue(planet.IsValidPosition(0, 0));
            Assert.IsTrue(planet.IsValidPosition(10, 10));
            
            Assert.IsFalse(planet.IsValidPosition(-1, 0));
            Assert.IsFalse(planet.IsValidPosition(0, -1));
            Assert.IsFalse(planet.IsValidPosition(11, 0));
            Assert.IsFalse(planet.IsValidPosition(0, 11));
        }

        [TestMethod]
        public void CheckIfHasScent()
        {
            var planet = new Planet(10, 10);

            Assert.IsFalse(planet.HasScent(1, 1));
        }

        [TestMethod]
        public void ThrowsExceptionIfInvalidHasScentPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.HasScent(11, 11));
        }

        [TestMethod]
        public void CanAddAndGetScent()
        {
            var planet = new Planet(10, 10);

            planet.AddScent(1, 1, Direction.North);
            Assert.IsTrue(planet.HasScent(1, 1));
            Assert.AreEqual(Direction.North, planet.GetScentDirection(1, 1));
        }

        [TestMethod]
        public void ThrowsExceptionForInvalidAddScentPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.AddScent(11, 11, Direction.North));
        }

        [TestMethod]
        public void ThrowsExceptionIfNoScentDirection()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.GetScentDirection(1, 1));
        }

        [TestMethod]
        public void ThrowsExceptionForInvalidGetScentDirectionPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => planet.GetScentDirection(11, 11));
        }
    }
}