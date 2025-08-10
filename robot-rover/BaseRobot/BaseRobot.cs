namespace RobotRover
{
    public class BaseRobot: AbstractRobot
    {
        public bool Sitting { get; set; }
        
        public BaseRobot()
        {
            AddInstruction('S', ()=> { Sitting = !Sitting; });
        }
    }
}