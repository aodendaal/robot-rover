namespace RobotRover
{
    public class InstructionSet
    {
        public Dictionary<char, Instruction> Instructions { get; private set; }

        public InstructionSet()
        {
            Instructions = new Dictionary<char, Instruction>();
        }

        public void AddInstruction(char commandKey, Instruction instruction)
        {
            Instructions.Add(commandKey, instruction);
        }
    }
}