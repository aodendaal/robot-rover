namespace RobotRover.Test
{
    [TestClass]
    public class BaseRobotTest
    {
        [TestMethod]
        public void CanExecuteInstruction()
        {
            var robot = new BaseRobot();

            Assert.IsFalse(robot.Sitting);
            robot.ExecuteInstruction('S');
            Assert.IsTrue(robot.Sitting);
            robot.ExecuteInstruction('S');
            Assert.IsFalse(robot.Sitting);
        }

        [TestMethod]
        public void CanExecuteInstructions()
        {
            var robot = new BaseRobot();
            robot.ExecuteInstructions("SSS");
            Assert.IsTrue(robot.Sitting);
        }

        [TestMethod]
        public void ThrowsExceptionIfInstructionNotFound()
        {
            var robot = new BaseRobot();

            Assert.ThrowsExactly<ArgumentException>(() => robot.ExecuteInstruction('Q'));
        }

        [TestMethod]
        public void ThrowsExceptionIfInstructionNotFoundInInstructions()
        {
            var robot = new BaseRobot();

            Assert.ThrowsExactly<ArgumentException>(() => robot.ExecuteInstructions("SQ"));
        }
    }
}