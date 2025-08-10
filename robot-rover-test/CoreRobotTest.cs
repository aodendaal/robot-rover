using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;

namespace RobotRover.Test
{
    [TestClass]
    public class CoreRobotTest
    {
        [TestMethod]
        public void CanAccessProperties()
        {
            var planet = new Planet(10, 10);
            var robot = new CoreRobot(planet, 5, 5, Direction.North);

            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(5, robot.Y);
            Assert.AreEqual(Direction.North, robot.Facing);
        }

        [TestMethod]
        public void CanExecuteCoreInstructions()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 5, Direction.North);

            // Circle Left
            robot.ExecuteInstructions("FLFLFLF");

            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(5, robot.Y);
            Assert.AreEqual(Direction.East, robot.Facing);

            // Circle Right
            robot.ExecuteInstructions("LFRFRF");

            Assert.AreEqual(6, robot.X);
            Assert.AreEqual(5, robot.Y);
            Assert.AreEqual(Direction.South, robot.Facing);
        }
    }
}