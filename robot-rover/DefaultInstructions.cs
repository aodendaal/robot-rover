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

        public static void TurnLeft(IRobot robot)
        {
            switch (robot.Facing)
            {
                case Direction.North:
                    robot.Facing = Direction.West;
                    break;
                case Direction.West:
                    robot.Facing = Direction.South;
                    break;
                case Direction.South:
                    robot.Facing = Direction.East;
                    break;
                case Direction.East:
                    robot.Facing = Direction.North;
                    break;
            }
        }

        public static void TurnRight(IRobot robot)
        {
            switch (robot.Facing)
            {
                case Direction.North:
                    robot.Facing = Direction.East;
                    break;
                case Direction.East:
                    robot.Facing = Direction.South;
                    break;
                case Direction.South:
                    robot.Facing = Direction.West;
                    break;
                case Direction.West:
                    robot.Facing = Direction.North;
                    break;
            }
        }   
    }
}