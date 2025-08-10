using System.Globalization;

namespace RobotRover
{
    public abstract class AbstractRobot
    {
        private InstructionSet instructionSet { get; set; }

        /// <summary>
        /// Creates a new robot at the given position and direction.
        /// </summary>
        /// <param name="planet">The planet the robot is on.</param>
        /// <param name="instructionSet">The instruction set for the robot.</param>
        public AbstractRobot()
        {
            instructionSet = new InstructionSet();
        }

        internal void AddInstruction(char instructionKey, Action instruction)
        {
            instructionSet.Add(instructionKey, instruction);
        }

        public void ExecuteInstruction(char instructionKey)
        {
            if (!instructionSet.ContainsKey(instructionKey))
            {
                throw new ArgumentException($"Instruction {instructionKey} not found");
            }

            var instruction = instructionSet[instructionKey];

            instruction();
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (var instruction in instructions)
            {
                ExecuteInstruction(instruction);
            }
        }
    }
}