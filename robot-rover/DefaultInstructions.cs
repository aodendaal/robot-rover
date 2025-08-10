namespace RobotRover
{
    public static class DefaultInstructions
    {
        public static void MoveForward(IRobot robot)
        {
            switch (robot.Facing)
            {
                case Direction.North:
                    robot.Y++;
                    break;
                case Direction.East:
                    robot.X++;
                    break;
                case Direction.South:
                    robot.Y--;
                    break;
                case Direction.West:
                    robot.X--;
                    break;
            }
        }
    }
}