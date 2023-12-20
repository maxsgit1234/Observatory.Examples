using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;

namespace Demos
{
    public class Figures : IExample
    {
        public string Title { get { return "Figures"; } }
        public string Description { get { return "Display multiple plots in a single window, and customize the window layout."; } }

        /// <summary>
        /// This example demonstrates how to launch a figure containing multiple plots.
        /// </summary>
        public void Run()
        {
            // When you display a single plot (as we have done every time up until now),
            // a figure is created to host just that one plot. However, figures 
            // themselves can be created to host multiple plots each. 

            // For example, the TileFigure subdivides its window area among one or more 
            // child plots according to a tile-based system. Its area is first subdivided
            // into a regular grid of dimensions (X and Y) are specified at construction 
            // time. Individual plots are then allocated to subregions within the figure
            // based on the index of the upper-left tile and a size (in tiles). This
            // creates a TileFigure with a 2x2 grid of tiles:
            TileFigure tiles = new TileFigure(2, 2);

            // This assigns a plot to the take up the left two rectangles in the grid:
            tiles.Add(MakeSimplePlot(Colors.Blue), 0, 0, 1, 2);

            // This assigns a plot to the upper right rectangle:
            tiles.Add(MakeSimplePlot(Colors.Red), 1, 0, 1, 1);

            // This assigns a plot to the lower right rectangle:
            tiles.Add(MakeSimplePlot(Colors.Green), 1, 1, 1, 1);

            // Display the plot by specifying the desired *total* size, and the tile
            // sizes are calculated as fractions thereof:
            tiles.Display(FigureResolution.Res_16to9_720p);
        }

        private static Viz MakeSimplePlot(Color color)
        {
            Plot2d plot = new Plot2d();
            ObsRandom r = new ObsRandom();

            plot.Drawing.AddPoints(r.NextMultiVarNormal2ds(
                1000, new Vector2d(0,0), new Vector2d(1,1)), color);

            return plot;
        }

    }
}
