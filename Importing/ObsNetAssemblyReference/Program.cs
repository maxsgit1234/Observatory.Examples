using ObservatoryLib;

namespace ObsNetAssemblyReference
{
    // This example shows how to make a simplest-possible .NET 8.0+
    // project that uses Observatory via a stand-alone assembly reference.
    // 
    // First, you must add a reference to the followinig NuGet packages:
    //     - OpenTK
    //     - OpenTK.GLControl
    //     - System.Drawing.Common
    //
    // Then, add a project reference to the following files:
    //     - Observatory.NET.Desktop.dll
    //     - Observatory.Standard.dll
    //
    // Both of these pre-built assemblies are provided with the Observatory
    // download, and are included in this Observatory.Examples repository.

    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Platform.Init();
            Plot2d plot = new Plot2d();
            plot.Screen.AddTitle("Welcome to Observatory!");
            plot.Display();
            Platform.Run();
        }
    }
}
