namespace RobotRover
{
    public interface IRobot
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
    }
}