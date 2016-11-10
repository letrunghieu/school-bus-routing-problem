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

        public Entity(int numBuses)
        {
            this._routes = new List<int>[numBuses];
            for(var i = 0; i < numBuses; i++)
            {
                this._routes[i] = new List<int>();
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
    }
}
