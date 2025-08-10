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
        public bool IsLost { get; private set; }

        public CoreRobot(Planet planet, int x, int y, Direction facing)
        : base()
        {
            this.planet = planet;

            if (!planet.IsValidPosition(x, y))
            {
                throw new ArgumentException($"Invalid starting position: {x}, {y} for planet {planet.Width}x{planet.Height}");
            }

            this.x = x;
            this.y = y;
            this.facing = facing;

            AddInstruction('F', Forward);
            AddInstruction('L', TurnLeft);
            AddInstruction('R', TurnRight);
        }

        private void UpdateScent(int x, int y, Direction direction)
        {
            planet.AddScent(x, y, direction);
        }

        private bool HasScentInDirection(int x, int y, Direction direction)
        {
            return planet.HasScent(x, y) && planet.GetScentDirection(x, y) == direction;
        }

        private bool AreLost(int x, int y)
        {
            return !planet.IsValidPosition(x, y);
        }

        private void LeaveScent(int x, int y, Direction direction)
        {
            UpdateScent(x, y, direction);
        }

        private Tuple<int, int> GetForwardPosition()
        {
            var newX = x;
            var newY = y;

            switch (facing)
            {
                case Direction.North:
                    newY++;
                    break;
                case Direction.East:
                    newX++;
                    break;
                case Direction.South:
                    newY--;
                    break;
                case Direction.West:
                    newX--;
                    break;
            }

            return Tuple.Create(newX, newY);
        }

        internal void Move(int newX, int newY, Direction moveDirection)
        {
            if (IsLost)
            {
                // do nothing
                return;
            }

            if (HasScentInDirection(x, y, moveDirection))
            {
                // do nothing
                return;
            }

            if (AreLost(newX, newY))
            {
                IsLost = true;
                LeaveScent(x, y, moveDirection);
            }

            x = newX;
            y = newY;
        }

        private void Forward()
        {
            var newPosition = GetForwardPosition();
            Move(newPosition.Item1, newPosition.Item2, facing);
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