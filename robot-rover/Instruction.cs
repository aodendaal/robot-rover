namespace RobotRover
{
    public class Instruction
    {
        public Action<IRobot> Execute { get; set; }

        public Instruction(Action<IRobot> execute)
        {
            Execute = execute;
        }
    }
}