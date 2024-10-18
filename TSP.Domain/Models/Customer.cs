namespace TSP.Domain.Models
{
    public class Customer : Entity
    {
        public Point Location { get; }
        public int Number { get; }
        public Customer(int number, Point location)
        {
            Location = location;
            Number = number;
        }
        public override string ToString() => $"Customer No.{Number} at {Location}";
    }
}
