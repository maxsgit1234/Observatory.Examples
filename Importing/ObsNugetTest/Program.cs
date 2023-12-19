using ObservatoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsNugetTest
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Platform.Init();
            Plot2d plot = new Plot2d();
            plot.Display();
            Platform.Run();
        }
    }
}
