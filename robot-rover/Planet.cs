namespace RobotRover
{
    public class Planet
    {
        private readonly int width;
        private readonly int height;
        private readonly bool[,] scents;

        public Planet(int width, int height)
        {
            this.width = width;
            this.height = height;

            scents = new bool[width, height];
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public bool HasScent(int x, int y)
        {
            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position");
            }

            return scents[x, y];
        }

        public void AddScent(int x, int y)
        {
            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position");
            }

            scents[x, y] = true;
        }
    }
}