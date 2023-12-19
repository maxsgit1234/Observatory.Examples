using ObservatoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsFrameworkAssemblyReference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Platform.Init();
            Plot2d plot = new Plot2d();
            plot.Display();
            Platform.Run();
        }
    }
}
