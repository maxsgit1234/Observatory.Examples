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
			plot.Drawing.AddPoint(1, 2, Colors.Blue);
			plot.Drawing.AddPoint(2, 3, Colors.Green);
			plot.Drawing.AddPoint(3, 4, Colors.Red);
			plot.Display();
            Platform.Run();
        }
    }
}
