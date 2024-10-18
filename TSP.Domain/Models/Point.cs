namespace TSP.Domain.Models
{
    public class Point : Entity
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));

        public override string ToString() => $"(X={X}, Y={Y})";
    }
}
