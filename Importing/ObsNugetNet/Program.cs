using ObservatoryLib;
using System;
using System.Threading.Tasks;

namespace ObsNugetNet
{
    internal class Program
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
