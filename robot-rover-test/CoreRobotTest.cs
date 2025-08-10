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

        [TestMethod]
        public void ThrowsExceptionIfInvalidStartingPosition()
        {
            var planet = new Planet(10, 10);
            Assert.ThrowsExactly<ArgumentException>(() => new CoreRobot(planet, 11, 11, Direction.North));
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

        [TestMethod]
        public void CanGetLost()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 9, Direction.North);

            robot.ExecuteInstructions("F");
            Assert.IsTrue(robot.IsLost);
            Assert.AreEqual(10, robot.Y);
        }

        [TestMethod]
        public void LeavesScentWhenLost()
        {
            var planet = new Planet(10, 10);
            var robot = new CoreRobot(planet, 5, 9, Direction.North);
            robot.ExecuteInstructions("F");
            Assert.IsTrue(robot.IsLost);
            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(10, robot.Y);
            Assert.IsTrue(planet.HasScent(5, 9));
            Assert.AreEqual(Direction.North, planet.GetScentDirection(5, 9));
        }

        [TestMethod]
        public void DoesntMoveIfHasScentInDirection()
        {
            var planet = new Planet(10, 10);
            planet.AddScent(5, 9, Direction.North);
            var robot = new CoreRobot(planet, 5, 9, Direction.North);

            robot.ExecuteInstructions("F");
            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(9, robot.Y);
            Assert.AreEqual(Direction.North, robot.Facing);
        }

                [TestMethod]
        public void MoveWhenScentInDifferentDirection()
        {
            var planet = new Planet(10, 10);
            planet.AddScent(5, 9, Direction.West);
            var robot = new CoreRobot(planet, 5, 9, Direction.North);

            robot.ExecuteInstructions("F");
            Assert.AreEqual(5, robot.X);
            Assert.AreEqual(10, robot.Y);
            Assert.AreEqual(Direction.North, robot.Facing);
            Assert.IsTrue(robot.IsLost);
        }

        [TestMethod]
        public void StopsMovingWhenLost()
        {
            var robot = new CoreRobot(new Planet(10, 10), 5, 9, Direction.North);
            robot.ExecuteInstructions("FF");
            Assert.IsTrue(robot.IsLost);
            Assert.AreEqual(10, robot.Y);
        }
    }
}