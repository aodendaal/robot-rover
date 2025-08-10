namespace RobotRover
{
    public class Instruction<T> where T : IInstructionProperties
    {
        public Action<T> Execute { get; set; }

        public Instruction(Action<T> execute)
        {
            Execute = execute;
        }
    }
}