namespace TSP.Domain.Models
{
    public class Tour : Entity
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public Tour(IEnumerable<Customer> customers)
        {
            Customers.AddRange(customers);
        }
        public override string ToString() => $"Tour with {Customers.Count} customers";
    }
}
