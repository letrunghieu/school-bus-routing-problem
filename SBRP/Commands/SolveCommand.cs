using SBRP.Algorithms.GeneticKang2015;
using SBRP.ComandVerbs;
using SBRP.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.Commands
{
    class SolveCommand
    {
        private Solve _options;

        public SolveCommand(Solve options)
        {
            this._options = options;
        }

        public void run()
        {
            InputInterface input = new OriginalFileInput(this._options.BusStops, this._options.DistanceMatrix);
            SchoolBusRoutingProblem sbrp = new SchoolBusRoutingProblem(input.getBusStops(), input.getDistanceMatrix())
            {
                NumBuses = this._options.NumBuses,
                VehicleCapacity = this._options.BusCapacity,
                MaxRiddingTime = this._options.MaxRidingTime
            };

            OriginalOutput output = new OriginalOutput();

            GeneticKang2015 ga = new GeneticKang2015(sbrp, output)
            {
                CrossoverRate = this._options.CrossoverRate,
                MutationRate = this._options.MutationRate,
                ElitismNumber = this._options.ElitismNumber,
                PopulationSize = this._options.PopulationSize,
                NumberOfGenerations = this._options.NumGenerations,
                SelectionRatio = 0.25
            };

            ga.run();
        }
    }
}
