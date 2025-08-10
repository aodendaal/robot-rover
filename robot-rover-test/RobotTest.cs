using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;

namespace RobotRover.Test
{
    [TestClass]
    public class CoreRobotTest
    {
        [TestMethod]
        public void CanCreateRobot()
        {
            var planet = new Planet(10, 10);
            var robot = new CoreRobot(planet, 5, 5, Direction.North);

            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(5, robot.Y);
            Assert.AreEqual(Direction.North, robot.Facing);
        }
    }
}