namespace RobotRover
{
    public abstract class AbstractRobot<T> where T : class,IInstructionProperties
    {
        private readonly Planet planet;
        private InstructionSet<T> instructionSet { get; set; }

        /// <summary>
        /// Creates a new robot at the given position and direction.
        /// </summary>
        /// <param name="planet">The planet the robot is on.</param>
        /// <param name="instructionSet">The instruction set for the robot.</param>
        public AbstractRobot(Planet planet, InstructionSet<T> instructionSet)
        {
            this.planet = planet;
            this.instructionSet = instructionSet;
        }

        public void ExecuteInstruction(char instructionKey)
        {
            if (!instructionSet.ContainsKey(instructionKey))
            {
                throw new InvalidOperationException($"Instruction {instructionKey} not found");
            }

            var instruction = instructionSet[instructionKey];

            var robot = this as T;
            if (robot != null)
            {
                instruction.Execute(robot);
            }
        }
    }
}