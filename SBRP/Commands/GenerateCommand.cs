using SBRP.ComandVerbs;
using SBRP.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.Commands
{
    class GenerateCommand
    {
        private Generate _options;

        public GenerateCommand(Generate opts)
        {
            this._options = opts;
        }

        public void run()
        {
            BusStop[] busStops = new BusStop[this._options.NumBusStops];

            double r, theta, x, y;
            Random randomR = new Random();

            double meanStudentPerStop = ((double)this._options.NumStudents) / this._options.NumBusStops;
            int maxStudentPerStop = Convert.ToInt32(Math.Round(meanStudentPerStop * 2));

            for (var i = 0; i < this._options.NumBusStops; i++)
            {
                r = randomR.NextDouble() * (this._options.MaxRiddingTime - this._options.MaxWalkingTime) + this._options.MaxWalkingTime;
                theta = randomR.NextDouble() * Math.PI * 2;
                x = r * Math.Cos(theta);
                y = r * Math.Sin(theta);

                busStops[i] = new BusStop(x, y);
                busStops[i].NumStudent = randomR.Next(1, maxStudentPerStop);
            }

            using (StreamWriter file = new StreamWriter(@"bus-stops.txt", false, Encoding.UTF8))
            {
                file.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}", "i", "x", "y", "students"));
                for (var i = 0; i < this._options.NumBusStops; i++)
                {
                    BusStop bs = busStops[i];
                    file.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}", i + 1, bs.X, bs.Y, bs.NumStudent));
                }
            }
        }
    }
}
