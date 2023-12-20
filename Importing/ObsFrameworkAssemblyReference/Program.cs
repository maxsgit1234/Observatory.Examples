using ObservatoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsFrameworkAssemblyReference
{
    // This example shows how to make a simplest-possible .NET Framework (4.7.2+)
    // project that uses Observatory via a stand-alone assembly reference.
    //
    // Simply add references to the following files:
    //     - Observatory.Framework.Desktop.dll
    //     - Observatory.Standard.dll
    //     - OpenTK.dll
    //     - OpenTK.GLControl.dll
    //
    // All of these pre-built assemblies are provided with the Observatory
    // download, and are included in this Observatory.Examples repository.
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
