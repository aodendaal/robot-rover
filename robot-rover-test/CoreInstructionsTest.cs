namespace RobotRover.Test
{
    [TestClass]
    public class CoreInstructionsTest
    {
        [TestMethod]
        public void CanMoveForward()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 5, Direction.North);

            CoreInstructions.MoveForward(robot);

            Assert.AreEqual(6, robot.Y);

            var robot2 = new CoreRobot(new Planet(5, 5), 2, 2, Direction.East);

            CoreInstructions.MoveForward(robot2);

            Assert.AreEqual(3, robot2.X);
        }

        [TestMethod]
        public void CanTurnLeft()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 5, Direction.North);

            CoreInstructions.TurnLeft(robot);

            Assert.AreEqual(Direction.West, robot.Facing);

            var robot2 = new CoreRobot(new Planet(10, 10), 5, 5, Direction.East);

            CoreInstructions.TurnLeft(robot2);

            Assert.AreEqual(Direction.North, robot2.Facing);
        }

        [TestMethod]
        public void CanTurnRight()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 5, Direction.North);

            CoreInstructions.TurnRight(robot);

            Assert.AreEqual(Direction.East, robot.Facing);

            var robot2 = new CoreRobot(new Planet(10, 10), 5, 5, Direction.West);

            CoreInstructions.TurnRight(robot2);

            Assert.AreEqual(Direction.North, robot2.Facing);
        }   
    }
}