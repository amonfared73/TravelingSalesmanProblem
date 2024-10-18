using TSP.Domain.Models;

namespace TSP.Shared.Utilities
{
    public class KMeans
    {
        public static List<List<Customer>> ClusterCustomers(List<Customer> customers, List<Visitor> visitors)
        {
            int visitorsCount = visitors.Count;
            var customerClusters = new List<List<Customer>>(visitorsCount);

            for (int i = 0; i < visitorsCount; i++)
            {
                customerClusters.Add(new List<Customer>());
            }

            bool hasChanged;
            do
            {
                hasChanged = false;


                for (int i = 0; i < visitorsCount; i++)
                {
                    customerClusters[i].Clear();
                }


                foreach (var customer in customers)
                {
                    double minDistance = double.MaxValue;
                    int nearestVisitorIndex = 0;

                    for (int i = 0; i < visitorsCount; i++)
                    {
                        double distance = customer.Location.DistanceTo(visitors[i].StartPoint);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestVisitorIndex = i;
                        }
                    }

                    customerClusters[nearestVisitorIndex].Add(customer);
                }


                for (int i = 0; i < visitorsCount; i++)
                {
                    if (customerClusters[i].Count > 0)
                    {
                        int avgX = (int)customerClusters[i].Average(c => c.Location.X);
                        int avgY = (int)customerClusters[i].Average(c => c.Location.Y);

                        var newPoint = new Point(avgX, avgY);
                        if (newPoint.X != visitors[i].StartPoint.X || newPoint.Y != visitors[i].StartPoint.Y)
                        {
                            visitors[i].StartPoint = newPoint;
                            hasChanged = true;
                        }
                    }
                }

            } while (hasChanged);

            return customerClusters;
        }
    }
}
