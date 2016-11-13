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
    }
}
