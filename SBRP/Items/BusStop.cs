using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.Items
{
    class BusStop
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int NumStudent { get; set; }

        public BusStop(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
