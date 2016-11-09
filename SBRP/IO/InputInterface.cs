using SBRP.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.IO
{
    interface InputInterface
    {
        /// <summary>
        /// Get the list of bus stops data (x, y, number of student)
        /// </summary>
        /// <returns></returns>
        BusStop[] getBusStops();

        /// <summary>
        /// Get the distance matrix as a 2-dimenstional matrix of double numbers
        /// </summary>
        /// <returns></returns>
        double[,] getDistanceMatrix();
    }
}
