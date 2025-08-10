namespace RobotRover
{
    public interface ICoreRobot : IInstructionProperties
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Facing { get; set; }
    }
}