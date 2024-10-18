using TSP.Domain.Models;

namespace TSP.Shared.Utilities
{
    public static class Extensions
    {
        public static void PrintCustomers(this List<Customer> customers)
        {
            Console.WriteLine("These are the following customers: ");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void PrintVisitors(this List<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                Console.WriteLine(visitor);
            }
        }
    }
}
