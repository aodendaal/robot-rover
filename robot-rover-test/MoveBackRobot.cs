namespace RobotRover.Test
{
    [TestClass]
    public class MoveBackRobotTest
    {
        [TestMethod]
        public void CanMoveBack()
        {
            var robot = new MoveBackRobot(new Planet(10, 10), 5, 5, Direction.North);
            robot.ExecuteInstruction('B');

            Assert.AreEqual(4, robot.Y);
            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(Direction.North, robot.Facing);
        }
    }
}