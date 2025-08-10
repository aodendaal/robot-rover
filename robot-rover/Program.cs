namespace RobotRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputProcessor = new InputProcessor();

            try
            {
                //args = ["../../../../input-example.txt"];
                if (args.Length == 0)
                {
                    throw new ArgumentException("Please provide the input file path as an argument.");
                }

                var input = inputProcessor.GetInputFile(args[0]);

                var lines = input.Replace("\r", "").Split('\n');

                var planet = inputProcessor.GeneratePlanet(lines[0]);

                var robot = inputProcessor.GenerateRobot(planet, lines);

                inputProcessor.ExecuteRobotInstructions(robot);

                inputProcessor.OutputRobotPositions(robot);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}