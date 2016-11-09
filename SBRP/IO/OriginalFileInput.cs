using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBRP.Items;
using CsvHelper;
using CsvHelper.Configuration;

namespace SBRP.IO
{
    class OriginalFileInput : InputInterface
    {
        private string _busStopsFile;
        private string _distanceMatrixFile;
        private int _nBusStops;

        public OriginalFileInput(string busStops, string dMat)
        {
            this._busStopsFile = busStops;
            this._distanceMatrixFile = dMat;
        }

        public BusStop[] getBusStops()
        {
            BusStop[] busStops;

            using (var sr = new System.IO.StreamReader(this._busStopsFile))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<BusStopMap>();
                csv.Configuration.Delimiter = "\t";

                busStops = csv.GetRecords<BusStop>().ToArray();
            }

            this._nBusStops = busStops.Length;

            return busStops;
        }

        public double[,] getDistanceMatrix()
        {
            double[,] dMat = new double[this._nBusStops + 1,this._nBusStops + 1];

            using (var sr = new System.IO.StreamReader(this._distanceMatrixFile))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.Delimiter = "\t";

                while(csv.Read())
                {
                    dMat[csv.GetField<int>(0), csv.GetField<int>(1)] = csv.GetField<double>(3) / 60; // convert seconds to minutes
                }
            }

            return dMat;
        }
    }

    sealed class BusStopMap : CsvClassMap<BusStop>
    {
        public BusStopMap()
        {
            Map(m => m.X).Index(1);
            Map(m => m.Y).Index(2);
            Map(m => m.NumStudent).Index(3);
        }
    }
}
