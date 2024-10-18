using TSP.Domain.Models;

namespace TSP.Shared.Utilities
{
    public static class Tools
    {
        public static List<Customer> GetCustomers(int limit)
        {
            var customers = new List<Customer>();
            var random = new Random();
            for (int i = 0; i < limit; i++)
            {
                int x = random.Next(0, Constants.PlaneLimit);
                int y = random.Next(0, Constants.PlaneLimit);
                customers.Add(new Customer(i + 1, new Point(x, y)));
            }
            return customers;
        }

        public static List<Visitor> GetVisitors(int limit)
        {
            var visitors = new List<Visitor>();
            var random = new Random();
            for (int i = 0; i < limit; i++)
            {
                int x = random.Next(0, Constants.PlaneLimit);
                int y = random.Next(0, Constants.PlaneLimit);
                visitors.Add(new Visitor(i + 1, new Point(x, y)));
            }
            return visitors;
        }
    }
}
