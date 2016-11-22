using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.IO
{
    class OriginalOutput : OutputInterface
    {
        public void log(string s)
        {
            throw new NotImplementedException();
        }

        public void print(string s)
        {
            Console.Write(s);
        }

        public void printLine(string s)
        {
            Console.WriteLine(s);
        }

        public void saveSolution(SchoolBusRoutingProblem sbrp, List<int>[] routes)
        {
            int i = 0;
            string outputFile = "output.txt";
            using(var sw = new System.IO.StreamWriter(outputFile))
            {
                var csv = new CsvWriter(sw);
                csv.Configuration.Delimiter = "\t";
                csv.Configuration.Encoding = Encoding.UTF8;
                csv.WriteField("RouteId");
                csv.WriteField("Lat");
                csv.WriteField("Lng");
                csv.WriteField("Nb");
                csv.NextRecord();
                foreach (List<int> route in routes)
                {
                    i++;
                    foreach(int busStop in route)
                    {
                        csv.WriteField(i);
                        csv.WriteField(sbrp.BusStops[busStop - 1].X);
                        csv.WriteField(sbrp.BusStops[busStop - 1].Y);
                        csv.WriteField(sbrp.BusStops[busStop - 1].NumStudent);
                        csv.NextRecord();
                    }
                    // add the school
                    // TODO: save the school location
                    csv.WriteField(i);
                    csv.WriteField(10.895213);
                    csv.WriteField(106.651882);
                    csv.WriteField("");
                    csv.NextRecord();
                    csv.WriteField("*");
                    csv.WriteField("");
                    csv.WriteField("");
                    csv.WriteField("");
                    csv.NextRecord();
                }
            }
            
        }
    }
}
