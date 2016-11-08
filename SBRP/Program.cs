using CommandLine;
using SBRP.ComandVerbs;
using SBRP.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = Parser.Default.ParseArguments<Generate>(args);
            results.WithParsed<Generate>(opts => { (new GenerateCommand(opts)).run(); });
        }
    }
}
