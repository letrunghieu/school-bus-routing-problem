using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.IO
{
    interface OutputInterface
    {
        void log(string s);
        void print(string s);
        void printLine(string s);
    }
}
