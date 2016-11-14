using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.Algorithms.GeneticKang2015
{
    class Entity
    {
        private List<int>[] _routes;
        private int[][] _chromosome;

        public double Fitness { get; set; }
        public bool IsElite { get; set; }

        public Entity(int numBuses, int numBusStops)
        {
            this._routes = new List<int>[numBuses];
            this._chromosome = new int[numBusStops][];
            for (var i = 0; i < numBuses; i++)
            {
                this._routes[i] = new List<int>();
            }
            for (var i = 0; i < numBusStops; i++)
            {
                this._chromosome[i] = new int[2] { 0, 0 };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bus">1-index</param>
        /// <param name="busStop">0-index, 0 is the school</param>
        public bool assignBusToBusStop(int bus, int busStop, int[] busStopStudents, double[,] distanceMatrix, int busCapacity, double mrt)
        {
            List<int> busStops = this._routes[bus - 1];
            int capacity = busStops.Select(bs => busStopStudents[bs - 1]).Sum();

            // do not add this bus stop to the current route if the bus is almost full
            if (capacity + busStopStudents[busStop - 1] > busCapacity)
            {
                return false;
            }

            List<int> newBusStops = new List<int>(busStops);
            newBusStops.Add(busStop);

            List<int> sortedRoute = new List<int>(newBusStops.Count);

            // reorder the new list of bus stop to calculate the route length
            int k = 0, k1 = 0;
            double currentDist = -1;

            // find the bus stop that is furthest away from the school
            foreach(int bs in newBusStops)
            {
                if (distanceMatrix[0, bs] > currentDist)
                {
                    k = bs;
                    currentDist = distanceMatrix[0, bs];
                }
            }

            double totalDist = 0;

            sortedRoute.Add(k);
            newBusStops.Remove(k);
            while(newBusStops.Count > 0)
            {
                // choose the next bus stop to be the nearest one to k
                currentDist = -1;
                foreach(int bs in newBusStops)
                {
                    if (distanceMatrix[k, bs] > currentDist)
                    {
                        k1 = bs;
                        currentDist = distanceMatrix[k, bs];
                    }
                }
                sortedRoute.Add(k1);
                newBusStops.Remove(k1);
                totalDist += distanceMatrix[k, k1];
                k = k1;

                if (sortedRoute.Count > busStops.Count + 1)
                {
                    Console.WriteLine("Error");
                }
            }

            // if the route length is greater than the max value, return false
            if (totalDist + distanceMatrix[k, 0] > mrt)
            {
                return false;
            }

            this._routes[bus - 1] = sortedRoute;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">1-index</param>
        /// <returns></returns>
        public List<int> getRoute(int i)
        {
            return this._routes[i - 1];
        }

        /// <summary>
        /// Encode the current information into chromosome
        /// </summary>
        /// <returns></returns>
        public Entity encode()
        {
            for (var bus = 0; bus < this._routes.Length; bus++)
            {
                for (var i = 0; i < this._routes[bus].Count; i++)
                {
                    int busStop = this._routes[bus][i];

                    // the bus stop is 1-index
                    // the bus is 0-index while the representation is 1-index
                    this._chromosome[busStop - 1][0] = bus + 1;
                    this._chromosome[busStop - 1][1] = i;
                }
            }
            return this;
        }

        /// <summary>
        /// Sort the bus stations in a route with the furthest bus top first
        /// </summary>
        /// <param name="distanceMatrix"></param>
        public void sortBusStopsInRoutes(double[,] distanceMatrix)
        {
            for (var i = 0; i < this._routes.Length; i++)
            {
                this._routes[i].Sort((g1, g2) =>
                {
                    if (distanceMatrix[0, g1] < distanceMatrix[0, g2])
                    {
                        return 1;
                    }
                    else if (distanceMatrix[0, g1] > distanceMatrix[0, g2])
                    {
                        return -1;
                    }
                    return 0;
                });
            }
        }

        /// <summary>
        /// Get the total distance of the current route
        /// </summary>
        /// <param name="distanceMatrix"></param>
        /// <returns></returns>
        public double getTotalDistance(double[,] distanceMatrix)
        {
            return this.getRouteLengths(distanceMatrix).Sum();
        }

        public List<double> getRouteLengths(double[,] distanceMatrix)
        {
            return this._routes.Select(route =>
            {
                double dist = 0;
                for (var i = 0; i < route.Count; i++)
                {
                    // Get the distance of the two bus stops, if the current bus stop is the last one,
                    // get the distance from it to the school. Then, sum up the distance with the current
                    // total distance.
                    if (i + 1 >= route.Count)
                    {
                        dist += distanceMatrix[route[i], 0];
                    }
                    else
                    {
                        dist += distanceMatrix[route[i], route[i + 1]];
                    }
                }

                return dist;
            }).ToList();
        }

        public bool isValid(double max, double[,] distanceMatrix)
        {
            foreach(List<int> route in this._routes)
            {
                double dist = 0;
                for (var i = 0; i < route.Count; i++)
                {
                    // Get the distance of the two bus stops, if the current bus stop is the last one,
                    // get the distance from it to the school. Then, sum up the distance with the current
                    // total distance.
                    if (i + 1 >= route.Count)
                    {
                        dist += distanceMatrix[route[i], 0];
                    }
                    else
                    {
                        dist += distanceMatrix[route[i], route[i + 1]];
                    }
                }

                if (dist > max)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return String.Join(",", this._chromosome.Select(gen => String.Format("({0},{1})", gen[0], gen[1])));
        }
    }
}
