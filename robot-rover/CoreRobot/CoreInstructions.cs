namespace RobotRover
{
    public static class CoreInstructions
    {
        public static InstructionSet<ICoreRobot> GetInstrunctions()
        {
            var instructionSet = new InstructionSet<ICoreRobot>();

            instructionSet.AddInstruction('F', new Instruction<ICoreRobot>(MoveForward));
            instructionSet.AddInstruction('L', new Instruction<ICoreRobot>(TurnLeft));
            instructionSet.AddInstruction('R', new Instruction<ICoreRobot>(TurnRight));

            return instructionSet;
        }

        public static void MoveForward(ICoreRobot robot)
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

        public static void TurnLeft(ICoreRobot robot)
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

        public static void TurnRight(ICoreRobot robot)
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