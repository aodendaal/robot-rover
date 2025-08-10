using System.IO;

namespace RobotRover
{
    public class InputProcessor
    {
        public string GetInputFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Input file not found: " + filePath);
            }

            return File.ReadAllText(filePath);
        }

        public Planet GeneratePlanet(string line)
        {
            var maxSize = 50;

            var planetSize = line.Split(' ');
            if (!int.TryParse(planetSize[0], out int width))
            {
                throw new InvalidCastException("Invalid planet width");
            }
            if (width <= 0 || width > maxSize - 1)
            {
                throw new InvalidCastException("Planet width is out of bounds");
            }

            if (!int.TryParse(planetSize[1], out int height))
            {
                throw new InvalidCastException("Invalid planet height");
            }
            if (height <= 0 || height > maxSize - 1)
            {
                throw new InvalidCastException("Planet height is out of bounds");
            }
            var planet = new Planet(width, height);

            Console.WriteLine($"Planet created: {planet.Width}x{planet.Height}");

            return planet;
        }

        private CoreRobot InstantiateRobot(Planet planet, string line)
        {
            var robotLine = line.Split(' ');
            if (!int.TryParse(robotLine[0], out int x))
            {
                throw new InvalidCastException("Invalid robot x coordinate");
            }
            if (x < 0 || x > planet.Width || x > 50)
            {
                throw new InvalidCastException("Robot x coordinate is out of bounds");
            }

            if (!int.TryParse(robotLine[1], out int y))
            {
                throw new InvalidCastException("Invalid robot y coordinate");
            }
            if (y < 0 || y > planet.Height || y > 50)
            {
                throw new InvalidCastException("Robot y coordinate is out of bounds");
            }

            Direction direction;

            switch (robotLine[2])
            {
                case "N":
                    direction = Direction.North;
                    break;
                case "E":
                    direction = Direction.East;
                    break;
                case "S":
                    direction = Direction.South;
                    break;
                case "W":
                    direction = Direction.West;
                    break;
                default:
                    throw new InvalidCastException("Invalid robot direction");
            }

            var robot = new CoreRobot(planet, x, y, direction);
            Console.WriteLine($"Robot created: {robot.X} {robot.Y} {robot.Facing}");

            return robot;
        }

        private void CheckInstructionsAreValid(string instructions)
        {
            if (string.IsNullOrEmpty(instructions))
            {
                throw new InvalidCastException("Robot instructions not found");
            }

            if (instructions.Length > 100)
            {
                throw new InvalidCastException("Robot nstructions are too long");
            }

            foreach (var instruction in instructions)
            {
                if (instruction != 'F' && instruction != 'L' && instruction != 'R')
                {
                    throw new InvalidCastException("Invalid instruction found: " + instruction);
                }
            }

            Console.WriteLine($"Instructions are valid: {instructions}");
        }

        public Dictionary<CoreRobot, string> GenerateRobot(Planet planet, string[] lines)
        {
            var robots = new Dictionary<CoreRobot, string>();

            for (int i = 1; i < lines.Length; i += 3)
            {
                var robot = InstantiateRobot(planet, lines[i]);
                var instructions = lines[i + 1];
                CheckInstructionsAreValid(instructions);
                robots.Add(robot, instructions);
                if (i + 2 < lines.Length && !string.IsNullOrEmpty(lines[i + 2]))
                {
                    throw new InvalidCastException("Missing blank line between robots");
                }
            }

            return robots;
        }

        public void ExecuteRobotInstructions(Dictionary<CoreRobot, string> robots)
        {
            foreach (var robot in robots)
            {
                robot.Key.ExecuteInstructions(robot.Value);
            }
        }

        public void OutputRobotPositions(Dictionary<CoreRobot, string> robots)
        {
            var results = new List<string>();
            foreach (var robot in robots.Keys)
            {
                string facing;

                switch (robot.Facing)
                {
                    case Direction.North:
                        facing = "N";
                        break;
                    case Direction.East:
                        facing = "E";
                        break;
                    case Direction.South:
                        facing = "S";
                        break;
                    case Direction.West:
                        facing = "W";
                        break;
                    default:
                        throw new InvalidCastException("Invalid robot direction");
                }

                var result = $"{robot.X} {robot.Y} {facing} {(robot.IsLost ? "LOST" : "")}";
                Console.WriteLine(result);
                results.Add(result);
            }

            File.WriteAllLines("output.txt", results);
        }
    }
}