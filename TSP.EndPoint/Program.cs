using TSP.Shared.Utilities;

namespace TSP.EndPoint
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // App introduction
            await ConsoleHelper.TypeWriter("Hello");
            await ConsoleHelper.TypeWriter("100 customers will appear on the XY axis with random locations");
            await ConsoleHelper.TypeWriter("4 random visitors will appear on some other random points");
            await ConsoleHelper.TypeWriter("Visitors will reach 25 customers each");
            await ConsoleHelper.TypeWriter("This application will try to find the optimal path for all visitors to reach each customer");

            // Main loop
            var shouldRun = true;
            var count = 1;
            var answer = "Y";
            do
            {
                await ConsoleHelper.TypeWriter($"Round {count}");

                // Customers
                await ConsoleHelper.TypeWriter("Please press enter to generate 100 customers with C(X, Y) location on XY plane: ");
                Console.ReadLine();
                var customers = Tools.GetCustomers(Shared.Utilities.Constants.NumebrOfCustomers);
                customers.PrintCustomers();


                // Visitors
                await ConsoleHelper.TypeWriter("Please press enter to generate 4 visitors with V(X, Y) location on XY plane: ");
                Console.ReadLine();
                var visitors = Tools.GetVisitors(Shared.Utilities.Constants.NumebrOfVisitors);
                visitors.PrintVisitors();

                // Cluserting Customers
                await ConsoleHelper.TypeWriter("Please press Enter to cluster customers based on the locations of visitors: ");
                Console.ReadLine();
                await ConsoleHelper.TypeWriter("Clustering customers based on visitors locations: ");
                var clusters = KMeans.ClusterCustomers(customers, visitors);

                // Solve TSP for each visitor
                for (int i = 0; i < visitors.Count; i++)
                {
                    var (tour, pathLength) = SolverEngine.SolveTsp(visitors[i], clusters[i]);
                    await ConsoleHelper.TypeWriter($"Total path length for Visitor {i + 1}: {pathLength:F2} au");
                    await ConsoleHelper.TypeWriter($"\nVisitor {i + 1} will visit the following customers:");

                    foreach (var (item, index) in tour.Select((item, index) => (item, index)))
                    {
                        Console.WriteLine($"{index} {item}");
                    }
                }

                count++;
                await ConsoleHelper.TypeWriter("Do you want to retry?: (Y/N)");
                answer = Console.ReadLine();
                shouldRun = answer.ToUpper() == "Y" ? true : false;
            }
            while (shouldRun);

            await ConsoleHelper.TypeWriter("GoodBye!");

        }
    }
}
