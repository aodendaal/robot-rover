namespace RobotRover
{
    public class MoveBackRobot : CoreRobot
    {
        public MoveBackRobot(Planet planet, int x, int y, Direction facing) : base(planet, x, y, facing)
        {
            AddInstruction('B', MoveBack);
        }

        private Tuple<int, int> GetBackPosition()
        {
            var newX = x;
            var newY = y;

            switch (Facing)
            {
                case Direction.North:
                    newY--;
                    break;
                case Direction.East:
                    newX--;
                    break;
                case Direction.South:
                    newY++;
                    break;
                case Direction.West:
                    newX++;
                    break;
            }

            return Tuple.Create(newX, newY);
        }

        private Direction GetBackDirection()
        {
            switch (Facing)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.East:
                    return Direction.West;
                case Direction.South:
                    return Direction.North;
                case Direction.West:
                    return Direction.East;
                default:
                    throw new ArgumentException("Invalid direction");
            }
        }

        private void MoveBack()
        {
            var newPosition = GetBackPosition();
            var backDirection = GetBackDirection();
            Move(newPosition.Item1, newPosition.Item2, backDirection);
        }
    }
}