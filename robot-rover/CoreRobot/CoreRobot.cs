namespace RobotRover
{
    public class CoreRobot : AbstractRobot
    {
        private readonly Planet planet;

        internal int x;
        public int X => x;
        internal int y;
        public int Y => y;
        internal Direction facing;
        public Direction Facing => facing;

        public CoreRobot(Planet planet, int x, int y, Direction facing)
        : base()
        {
            this.planet = planet;

            if (!planet.IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid starting position");
            }

            this.x = x;
            this.y = y;
            this.facing = facing;

            AddInstruction('F', Forward);
            AddInstruction('L', TurnLeft);
            AddInstruction('R', TurnRight);
        }

        private void Forward()
        {

            var oldX = x;
            var oldY = y;

            switch (facing)
            {
                case Direction.North:
                    y++;
                    break;
                case Direction.East:
                    x++;
                    break;
                case Direction.South:
                    y--;
                    break;
                case Direction.West:
                    x--;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (facing)
            {
                case Direction.North:
                    facing = Direction.West;
                    break;
                case Direction.West:
                    facing = Direction.South;
                    break;
                case Direction.South:
                    facing = Direction.East;
                    break;
                case Direction.East:
                    facing = Direction.North;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (facing)
            {
                case Direction.North:
                    facing = Direction.East;
                    break;
                case Direction.East:
                    facing = Direction.South;
                    break;
                case Direction.South:
                    facing = Direction.West;
                    break;
                case Direction.West:
                    facing = Direction.North;
                    break;
            }
        }
    }
}