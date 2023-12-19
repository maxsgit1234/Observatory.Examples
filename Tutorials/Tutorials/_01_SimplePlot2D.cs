using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;
using System.Threading;

namespace Examples
{
    public class SimplePlot2d : IExample
    {
        private string _Title = "Simple Plot 2D";
        public string Title { get { return _Title; } }

        private string _Description = "Make a simple scatter plot in 2D.";
        public string Description { get { return _Description; } }

        /// <summary>
        /// This method shows how you can make a simple scatter plot in 2D.
        /// </summary>
        public void Run()
        {
            // For this example, let's generate some random points in 2D space:
            ObsRandom r = new ObsRandom();
            int n = 10000;
            double[] x = r.NextNormalValues(n, 5, 10);
            double[] y = r.NextNormalValues(n, 2, 3);
            
            // Create a new plot object:
            Plot2d plot = new Plot2d();

            // Instead of making a new Drawing2, this time let's just add the 
            // points to the plot's default drawing builder:
            plot.Drawing.AddPoints(x, y, Colors.Blue);

            // The Plot2D class has many accessors that allow you
            // to customize your visualization. For example, you can set the axis
            // labels however you like:
            plot.Axes.X.AxisLabel = "This is my X Axis";

            // Every Visualization can be displayed in its own window
            // with a call to the Display() method. This time, let's specify the
            // resolution (size in pixels) of the window to be the standard 480p:
            plot.Display(FigureResolution.Res_16to9_480p);

            // Note that you can modify your visualization in real-time while it is
            // being displayed in any thread:
            //Thread.Sleep(3000);
            //plot.Axes.Y.AxisLabel = "Y axis";
        }
    }
}
