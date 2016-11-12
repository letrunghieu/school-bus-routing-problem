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
        public void assignBusToBusStop(int bus, int busStop)
        {
            this._routes[bus - 1].Add(busStop);
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
            }).Sum();
        }

        public override string ToString()
        {
            return String.Join(",", this._chromosome.Select(gen => String.Format("({0},{1})", gen[0], gen[1])));
        }
    }
}
