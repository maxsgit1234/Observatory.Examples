using ObservatoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsNugetTest
{
    // This example shows how to make a simplest-possible .NET Framework (4.7.2+)
    // project that uses Observatory as a NuGet package.
    //
    // Simply add a reference to the Observatory.Framework.Desktop NuGet package!
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
