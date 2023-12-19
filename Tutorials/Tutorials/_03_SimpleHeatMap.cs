using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;

namespace Examples
{
    public class SimpleHeatMap : IExample
    {
        private string _Title = "Simple Heat Map";
        public string Title { get { return _Title; } }

        private string _Description = "Make a simple Heat Map showing density in 2 dimensions.";
        public string Description { get { return _Description; } }


        /// <summary>
        /// This method shows how you can make a simple heat-map whose colors 
        /// represent the density of points in a 2D space.
        /// </summary>
        public void Run()
        {
            // For this example, let's generate some random points in 2D space:
            ObsRandom r = new ObsRandom();
            int n = 10000;
            double[] x = r.NextNormalValues(n, 5, 2);
            double[] y = r.NextNormalValues(n, 5, 2);

            // This creates a new HeatMap object, which is essentially
            // a specialized, interactive drawing:
            HeatMap h = new HeatMap(x, y);

            // Make a new 2D plot and add the HeatMap to it:
            Plot2d plot = new Plot2d();
            plot.Add(h);

            // Add a color bar so we can interpret the meaning of the colors:
            plot.AddColorBar("Density of points");

            // Display at 720p:
            plot.Display(FigureResolution.Res_16to9_720p);
        }

    }
}
