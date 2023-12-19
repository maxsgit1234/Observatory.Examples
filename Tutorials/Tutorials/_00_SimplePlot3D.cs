using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using System.Threading;

namespace Examples
{
    public class SimplePlot3d : IExample
    {
        private string _Title = "Simple Plot 3D";
        public string Title { get { return _Title; } }

        private string _Description = "Make a simple scatter plot in 3D.";
        public string Description { get { return _Description; } }

        /// <summary>
        /// This method shows how you can make a simple scatter plot in 3D.
        /// </summary>
        public void Run()
        {
            // For this example, let's generate some random points in 3D space:
            ObsRandom r = new ObsRandom();
            int n = 10000;
            double[] x = r.NextNormalValues(n, 0, 2);
            double[] y = r.NextNormalValues(n, 1, 3);
            double[] z = r.NextNormalValues(n, 2, 4);
            
            // Add the points to a new drawing.
            Drawing3 drawing = new Drawing3();

            // Add the points to the plot's default drawing builder:
            drawing.AddPoints(x, y, z, Colors.Blue);

            // Create a new "plot" object:
            Plot3d plot = new Plot3d();
            plot.Add(drawing);

            // The Plot3D class has many accessors that allow you
            // to customize your visualization. For example, you can label the axes 
            // however you like:
            plot.Axes.SetLabels("X axis", "Y axis", "Z axis");

            // Every Visualization can be displayed in its own window
            // with a call to the Display() method:
            plot.Display();

            // Note that you can modify your visualization in real-time while it is
            // being displayed in any thread:
            //Thread.Sleep(3000);
            //plot.Axes.Y.AxisLabel = "Y axis :-)";

        }

    }
}
