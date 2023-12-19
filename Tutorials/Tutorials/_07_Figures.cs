using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;

namespace Examples
{
    public class Figures : IExample
    {
        private string _Title = "Figures";
        public string Title { get { return _Title; } }

        private string _Description = "Display multiple plots in a single window, "
            + "and customize the window layout.";

        public string Description { get { return _Description; } }

        /// <summary>
        /// This example demonstrates how to launch a window with multiple plots using
        /// each of 2 different techniques.
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

            // A SplitFigure recursively subdivides its window area into a tree of 
            // rectangles, the leaves of which are all the individual plots.
            Viz plotA = MakeSimplePlot(Colors.Blue);
            Viz plotB = MakeSimplePlot(Colors.Green);

            // To create a SplitFigure, specify one or more plots to be initially 
            // assigned the entire window area:
            SplitFigure split = new SplitFigure(plotA);
            
            // This splits the area assigned to plotA horizontally so that it will be 
            // shared equally between plotA and plotB:
            split.SplitChild(true, plotA, plotB);

            // This further splits the area assigned to plotB (vertically) so that it
            // will be shared equally among plotB and two other new plots. The area
            // assigned to plotA is not affected:
            split.SplitChild(false, plotB, 
                MakeSimplePlot(Colors.Red), MakeSimplePlot(Colors.Orange));

            // The fractional area assigned to each plot within a shared group can be 
            // adjusted interactively during display, and via code:
            split.SetFractionalSizeOnBranch(plotB, 0.5);

            // Display the figure by specifying a desired *total* resolution. 
            split.Display(FigureResolution.Res_16to9_720p);
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
