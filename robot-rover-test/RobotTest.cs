using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;

namespace RobotRover.Test
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void CanCreateRobot()
        {
            var planet = new Planet(10, 10);
            var instructionSet = new InstructionSet();
            var robot = new Robot(planet, 5, 5, Direction.North, instructionSet);

            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(5, robot.Y);
            Assert.AreEqual(Direction.North, robot.Facing);
        }
    }
}