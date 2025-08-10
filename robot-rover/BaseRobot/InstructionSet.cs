namespace RobotRover
{
    public class InstructionSet<T> where T : IInstructionProperties
    {
        public Dictionary<char, Instruction<T>> Instructions { get; private set; }

        public InstructionSet()
        {
            Instructions = new Dictionary<char, Instruction<T>>();
        }

        public void AddInstruction(char commandKey, Instruction<T> instruction)
        {
            Instructions.Add(commandKey, instruction);
        }
    }
}