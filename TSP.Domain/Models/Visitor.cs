namespace TSP.Domain.Models
{
    public class Visitor : Entity
    {
        public Point StartPoint { get; set; }
        public int Number { get; set; }
        public Visitor(int number, Point startPoint)
        {
            StartPoint = startPoint;
            Number = number;
        }
        public override string ToString() => $"Visitor No.{Number} with starting point at {StartPoint}";
    }
}
