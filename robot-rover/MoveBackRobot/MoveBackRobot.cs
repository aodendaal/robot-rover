namespace RobotRover
{
    public class MoveBackRobot : CoreRobot
    {
        public MoveBackRobot(Planet planet, int x, int y, Direction facing) : base(planet, x, y, facing)
        {
            AddInstruction('B', MoveBack);
        }

        private void MoveBack()
        {
            switch (Facing)
            {
                case Direction.North:
                    this.y--;
                    break;
                case Direction.East:
                    this.x--;
                    break;
                case Direction.South:
                    this.y++;
                    break;
                case Direction.West:
                    this.x++;
                    break;
            }
        }
    }
}