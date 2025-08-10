namespace RobotRover.Test
{
    [TestClass]
    public class DefaultInstructionsTest
    {
        private InstructionSet instructionSet = new InstructionSet();

        [TestMethod]
        public void CanMoveForward()
        {
            var robot = new Robot(new Planet(10, 10), 5, 5, Direction.North, instructionSet);

            DefaultInstructions.MoveForward(robot);

            Assert.AreEqual(6, robot.Y);

            var robot2 = new Robot(new Planet(5, 5), 2, 2, Direction.East, instructionSet);

            DefaultInstructions.MoveForward(robot2);

            Assert.AreEqual(3, robot2.X);
        }

        [TestMethod]
        public void CanTurnLeft()
        {
            var robot = new Robot(new Planet(10, 10), 5, 5, Direction.North, instructionSet);

            DefaultInstructions.TurnLeft(robot);

            Assert.AreEqual(Direction.West, robot.Facing);

            var robot2 = new Robot(new Planet(10, 10), 5, 5, Direction.East, instructionSet);

            DefaultInstructions.TurnLeft(robot2);

            Assert.AreEqual(Direction.North, robot2.Facing);
        }

        [TestMethod]
        public void CanTurnRight()
        {
            var robot = new Robot(new Planet(10, 10), 5, 5, Direction.North, instructionSet);

            DefaultInstructions.TurnRight(robot);

            Assert.AreEqual(Direction.East, robot.Facing);

            var robot2 = new Robot(new Planet(10, 10), 5, 5, Direction.West, instructionSet);

            DefaultInstructions.TurnRight(robot2);

            Assert.AreEqual(Direction.North, robot2.Facing);
        }   
    }
}