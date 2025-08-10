namespace RobotRover
{
    public class Planet
    {
        private readonly int width;

        public int Width => width;

        private readonly int height;
        public int Height => height;

        private readonly bool[,] hasScents;
        private readonly Direction[,] scentDirection;

        public Planet(int width, int height)
        {
            this.width = width;
            this.height = height;

            hasScents = new bool[this.width + 1, this.height + 1];
            scentDirection = new Direction[this.width + 1, this.height + 1];
        }

        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x <= width && y >= 0 && y <= height;
        }

        public bool HasScent(int x, int y)
        {
            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position for scent");
            }

            return hasScents[x, y];
        }

        public Direction GetScentDirection(int x, int y)
        {
            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position");
            }
            
            if (!hasScents[x, y])
            {
                throw new ArgumentException("No scent at position");
            }

            return scentDirection[x, y];
        }

        public void AddScent(int x, int y, Direction direction)
        {
            if (!IsValidPosition(x, y))
            {
                throw new ArgumentException("Invalid position");
            }

            hasScents[x, y] = true;
            scentDirection[x, y] = direction;
        }
    }
}