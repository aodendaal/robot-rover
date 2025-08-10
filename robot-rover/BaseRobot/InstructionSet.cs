namespace RobotRover
{
    public class InstructionSet<T> where T : IInstructionProperties
    {
        private Dictionary<char, Instruction<T>> instructions;

        public InstructionSet()
        {
            instructions = new Dictionary<char, Instruction<T>>();
        }

        public Instruction<T> this[char commandKey]
        {
            get
            {
                return instructions[commandKey];
            }
        }

        public bool ContainsKey(char commandKey)
        {
            return instructions.ContainsKey(commandKey);
        }

        public void Add(char commandKey, Instruction<T> instruction)
        {
            instructions.Add(commandKey, instruction);
        }
    }
}