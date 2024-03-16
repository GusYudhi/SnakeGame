namespace SnakeGame
{
    internal class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Point(X, Y - 1);
                case Direction.Down:
                    return new Point(X, Y + 1);
                case Direction.Left:
                    return new Point(X - 1, Y);
                case Direction.Right:
                    return new Point(X + 1, Y);
                default:
                    return this;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            var other = (Point)obj;
            return X == other.X && Y == other.Y;
        }
    }
}
