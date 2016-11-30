using SBRP.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP
{
    class SchoolBusRoutingProblem
    {
        public BusStop[] BusStops { get; private set; }
        public double[,] DistanceMatrix { get; private set; }
        public int NumBusStops { get; private set; }
        public int VehicleCapacity { get; set; }
        public double MaxRiddingTime { get; set; }
        public int NumBuses { get; set; }

        public SchoolBusRoutingProblem(BusStop[] bs, double[,] dmat)
        {
            this.BusStops = bs;
            this.DistanceMatrix = dmat;

            // the first "bus stop" is the school
            this.NumBusStops = bs.Length - 1;
        }
    }
}
