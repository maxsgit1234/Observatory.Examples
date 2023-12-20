using ObservatoryLib;

namespace ObsNetAssemblyReference
{
    // This example shows how to make a simplest-possible .NET 6.0+
    // project that uses Observatory via a stand-alone assembly reference.
    // 
    // First, you must add a reference to the followinig NuGet packages:
    //     - OpenTK.WinForms
    //     - System.Drawing.Common (if targetting .NET 6.0 or 7.0)
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
            plot.Display();
            Platform.Run();
        }
    }
}
