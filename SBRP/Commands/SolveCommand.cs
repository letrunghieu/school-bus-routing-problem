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
            input.getBusStops();
            input.getDistanceMatrix();

        }
    }
}
