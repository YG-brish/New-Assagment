using HelloPipeline.Input;
using HelloPipeline.Output;
using HelloPipeline.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPipeline
{
    class Program
    {
       static void DumpFile()
        {
            Pipeline p = new Pipeline();

            p.Add(new FileReader());
            p.Add(new ConsoleWriter());

            p.Run();
        }

        static void CountLines()
        {
           Pipeline p = new Pipeline();

            p.Add=new FileReader();
            p.Add(new LinesCounter());
            p.Add(new ConsoleWriter());

            p.Run();
        }

        static void Main(string[] args)
        {
            CountLines();

            Console.ReadLine();
        }
    }
}
