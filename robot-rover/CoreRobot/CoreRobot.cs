namespace RobotRover
{
    public class CoreRobot : AbstractRobot<ICoreRobot>, ICoreRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }

        public CoreRobot(Planet planet, int x, int y, Direction facing)
        : base(planet, CoreInstructions.GetInstrunctions())
        {
            this.X = x;
            this.Y = y;
            this.Facing = facing;
        }
    }
}