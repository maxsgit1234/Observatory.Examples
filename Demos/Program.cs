using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ObservatoryLib;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Forms;
using ObservatoryLib.Extensions;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Observatory for the current platform.
            Platform.Init();

            Console.WriteLine("Running Observatory Demos Project...");
            string info = ObsResources.LoadBuildInfoString();
            Console.WriteLine("Version info: " + info);

            new ExampleSelector().ShowDialog();
        }
    }

}
