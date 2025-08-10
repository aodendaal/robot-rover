namespace RobotRover
{
    public abstract class AbstractRobot<T> where T : IInstructionProperties
    {
        private readonly Planet planet;
        public InstructionSet<T> InstructionSet { get; set; }
        /// <summary>
        /// Creates a new robot at the given position and direction.
        /// </summary>
        /// <param name="planet">The planet the robot is on.</param>
        /// <param name="instructionSet">The instruction set for the robot.</param>
        public AbstractRobot(Planet planet, InstructionSet<T> instructionSet)
        {
            this.planet = planet;
            this.InstructionSet = instructionSet;
        }
    }
}