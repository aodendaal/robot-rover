namespace RobotRover
{

    public class Robot: IRobot
    {
        private readonly Planet planet;
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }
        public InstructionSet InstructionSet { get; set; }

        /// <summary>
        /// Creates a new robot at the given position and direction.
        /// </summary>
        /// <param name="planet">The planet the robot is on.</param>
        /// <param name="x">The initial x position of the robot.</param>
        /// <param name="y">The initial y position of the robot.</param>
        /// <param name="facing">The initial direction of the robot.</param>
        public Robot(Planet planet, int x, int y, Direction facing, InstructionSet instructionSet)
        {
            this.planet = planet;
            this.X = x;
            this.Y = y;
            this.Facing = facing;
            this.InstructionSet = instructionSet;
        }
    }
}