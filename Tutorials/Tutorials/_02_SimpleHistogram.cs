using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;

namespace Examples
{
    public class SimpleHistogram : IExample
    {
        private string _Title = "Simple Histogram";
        public string Title { get { return _Title; } }

        private string _Description = "Make a simple histogram plot.";
        public string Description { get { return _Description; } }


        /// <summary>
        /// This method shows you how to make a simple histogram visualization.
        /// </summary>
        public void Run()
        {
            // For this example, let's generate some random values:
            ObsRandom r = new ObsRandom();

            // To make this more interesting, let's generate 3 sets of values, and
            // display each in its own (superimposed) histogram:
            double[] a = r.NextNormalValues(4000, -2, 1);
            double[] b = r.NextNormalValues(5000, 0, 1);
            double[] c = r.NextNormalValues(6000, 2, 0.7);
            
            // To view the data as a histogram, create a new histogram plot object:
            Hist hist = new Hist();

            // Simply add a histogram to the plot for each set of values.
            // Note that you do NOT have to calculate the binning yourself:
            hist.AddHistogram(a, Colors.Blue);
            hist.AddHistogram(b, Colors.Green);
            hist.AddHistogram(c, Colors.Orange);

            // You can set general parameters just like in all visualizations:
            hist.Axes.X.AxisLabel = "X axis";
            
            // As always, call Display to generate the plot:
            hist.Display();
        }
    }
}
