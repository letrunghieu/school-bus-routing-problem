using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.ComandVerbs
{
    [Verb("generate", HelpText = "Generate a posible input")]
    class Generate
    {
        [Option('k', "bus-stops", HelpText = "Number of bus stops", Required = true)]
        public int NumBusStops { get; set; }

        [Option('s', "students", HelpText = "Number of students", Required = true)]
        public int NumStudents { get; set; }

        [Option("mrt", HelpText = "Maximum ridding time in minutes", Required = false, Default = 30.0)]
        public double MaxRiddingTime { get; set; }

        [Option("min", HelpText = "Minimum ridding time in minutes", Required = false, Default = 5.0)]
        public double MaxWalkingTime { get; set; }
    }
}
