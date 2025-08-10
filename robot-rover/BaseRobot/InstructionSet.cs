namespace RobotRover
{
    public class InstructionSet
    {
        private Dictionary<char, Action> instructions;

        public InstructionSet()
        {
            instructions = new Dictionary<char, Action>();
        }

        public Action this[char commandKey]
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

        public void Add(char commandKey, Action instruction)
        {
            instructions.Add(commandKey, instruction);
        }
    }
}