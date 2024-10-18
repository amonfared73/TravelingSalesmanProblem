using TSP.Domain.Models;

namespace TSP.Shared.Utilities
{
    public class SolverEngine
    {
        public static (List<Customer> Tour, double pathLength) SolveTsp(Visitor visitor, List<Customer> customers)
        {
            var remaining = new List<Customer>(customers);
            var tour = new List<Customer>();

            var currentPoint = visitor.StartPoint;
            double totalDistance = 0;

            while (remaining.Count > 0)
            {
                var nearest = remaining.OrderBy(c => c.Location.DistanceTo(currentPoint)).First();
                tour.Add(nearest);

                totalDistance += currentPoint.DistanceTo(nearest.Location);

                currentPoint = nearest.Location;
                remaining.Remove(nearest);
            }

            return (tour, totalDistance);
        }
    }
}
