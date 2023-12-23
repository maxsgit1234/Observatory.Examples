using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;

using ObservatoryLib.Drawing;
using System.Threading;

namespace Demos
{
    public class ColorDemo : IExample
    {
        public string Title { get { return "Colors"; } }
        public string Description { get { return "Use colors to represent another dimension of numeric or categorical data."; } }

        /// <summary>
        /// This example demonstrates the various ways that colors can be specified in 
        /// your plot.
        /// </summary>
        public void Run()
        {
            // Create a drawing where some points are given colors explicitly, and
            // others are given numerical values, which are then mapped to colors
            // according to a plot-wide color-map:
            Drawing3 drawing = CreateDataSpaceColorDrawing();

            // Create a similar drawing with some explicit colors and some numeric
            // colors, which span the same range of values as the data space drawing:
            ScreenDrawing screen = CreateScreenSpaceColorDrawing();

            // Create an on-screen diagram illustrating some handy pre-made color
            // sequences, which can be used to generate appropriate colors that indicate
            // sentiment (i.e. good or bad), are distinguishable from each other, and
            // are easily accessed witout hard-coding RGB values (though you can 
            // still do that too):
            ScreenBase colorPanel = CreateColorPaletteDrawing();
            
            // Create a single-channel image whose pixel values are floating point 
            // numeric values. These values will be mapped to colors according to the 
            // same mapping function as in the drawings:
            RealImage valueIm = CreateExampleValueImage();

            // Create a new plot object, and add the content:
            Plot3d plot = new Plot3d();
            plot.Add(drawing);
            plot.Screen.PlaceChild(screen, Placement.RightMiddle());
            plot.Screen.PlaceChild(colorPanel, Placement.LowerLeft());
            plot.Images.Add3d(valueIm);

            // Adds a horizontal color bar, and give it a label:
            plot.AddColorBar("Click and drag the colored area!", horizontal: true);

            // Set other plot configuration and display:
            plot.Axes.SetScaleEquality(true);
            plot.Axes.SetLabels("X", "Y", "Z");
            plot.Display(FigureResolution.Res_4to3_1024_768);

            // This will wait 3 seconds and then change the ColorMap. The ColorMap is
            // the conversion from a numerical value to a color with RGB values. There
            // are several pre-made color maps, but you can also create your own. In 
            // general, colors are interpolated based on a set of fraction-color pairs
            // defined by the color map when they are within the range being shown on 
            // the plot, and you can specify other explicit colors to represent values
            // off the scale too-high, too-low, positive infinity, negative-infinity,
            // and NaN:
            //Thread.Sleep(3000);
            //plot.ColorRange.SetColorMap(new ColorMap(ColorMapType.Blackbody));

            // This will wait another 3 seconds and then change the range of colors
            // being shown on the plot. The color bar's labels will update to reflect 
            // the new conversion automatically. Note that colors that were specified 
            // explicitly (as RGB values) are not affected by these changes, but all the
            // numerically-speicifed colors are affected identically:
            //Thread.Sleep(3000);
            //plot.ColorRange.SetColorMinMax(0, 2000);
        }

        private static ScreenDrawing CreateScreenSpaceColorDrawing()
        {
            // Create a drawing specified in screen (pixel) space:
            ScreenDrawing ret = new ScreenDrawing();

            ObsRandom r = new ObsRandom(0);
            int n = 1000;

            // Create another 2 sets of random points, this time in 2D space:
            Vector2d[] xy1 = r.NextVector2ds(n,
                new Vector2d(0, 150), new Vector2d(100, 250));
            Vector2d[] xy2 = r.NextVector2ds(n,
                new Vector2d(0, 0), new Vector2d(100, 100));

            // Add the first set of points, with an explicit color:
            ret.AddPoints(xy1, Colors.Blue);

            // Add the second set of points, but this time specify a numeric value
            // for each point. In this case, let's use 10 times the point's X value:
            ret.AddPoints(xy2, xy2.Select(i => i.X * 10).ToArray());

            // When colors are specified for lines or triangles, the colors throughout
            // the shape are interpolated from the vertices:
            ret.AddTri(
                new Vector2d(0, 400),
                new Vector2d(0, 500),
                new Vector2d(100, 500), 0, 500, 1000);

            return ret;
        }

        private Drawing3 CreateDataSpaceColorDrawing()
        {
            // Create a new drawing builder:
            Drawing3 ret = new Drawing3(20);

            // Create 2 sets of random points in 3D space:
            ObsRandom r = new ObsRandom(0);
            int n = 1000;
            Vector3d[] xyz1 = r.NextVector3ds(n,
                new Vector3d(0, 150, 50), new Vector3d(100, 250, -50));
            Vector3d[] xyz2 = r.NextVector3ds(n,
                new Vector3d(0, 300, 50), new Vector3d(100, 400, -50));

            // Add the first set to the drawing, giving them all an explicit color:
            ret.AddPoints(xyz1, Colors.Blue);

            // Add the second set to the drawing, but this time, specify a numeric value
            // as the color for each point. In this case, 10 times the point's X value:
            ret.AddPoints(xyz2, xyz2.Select(i => i.X * 10).ToArray());

            return ret;
        }

        // Helper method to show the few different pre-made color palette sequences
        // as a series of groupings of rectangles on the screen:
        private ScreenBase CreateColorPaletteDrawing()
        {
            // This is a convenience class which produces a few sequences of colors,  
            // each of which is often appropriate in its own scenario, 
            // i.e. "good" colors, neutral colors, warning colors, alert colors, 
            // as well as a standard color set. We have already used colors from the
            // standard color set frequently, e.g. Colors.Blue. These such colors form
            // a more aesthetically pleasing and [perceptively] coherent set compared to
            // their raw System.Drawing.Color static counterparts, 
            // e.g. System.Drawing.Color.Blue.
            var ch = new CategoricalColorHelper();

            ScreenStackPanel stdPanel = MakePaletteDisplay("Standard", ch.NextStandardColor);
            ScreenStackPanel goodPanel = MakePaletteDisplay("Good", ch.NextGoodColor);
            ScreenStackPanel neutPanel = MakePaletteDisplay("Neutral", ch.NextNeutralColor);
            ScreenStackPanel warnPanel = MakePaletteDisplay("Warning", ch.NextWarningColor);
            ScreenStackPanel alertPanel = MakePaletteDisplay("Alert", ch.NextAlertColor);

            ScreenStackPanel panel = new ScreenStackPanel();
            panel.AddToStack(stdPanel);
            panel.AddToStack(ScreenSpacer.Vertical(5));
            panel.AddToStack(goodPanel);
            panel.AddToStack(ScreenSpacer.Vertical(5));
            panel.AddToStack(neutPanel);
            panel.AddToStack(ScreenSpacer.Vertical(5));
            panel.AddToStack(warnPanel);
            panel.AddToStack(ScreenSpacer.Vertical(5));
            panel.AddToStack(alertPanel);

            ScreenCanvas canvas = new ScreenCanvas(panel);
            return canvas;
        }

        // Helper method that makes a grouping of rectangles illustrating 
        // the colors available in a single palette sequence.
        private ScreenStackPanel MakePaletteDisplay(string name, Func<Color> next)
        {
            Vector2d sz = new Vector2d(30, 20);

            var panel = new ScreenStackPanel();
            var label = new ScreenLabel(name);
            label.SetMinWidth(60);
            panel.AddToStack(label);

            ScreenStackPanel row = new ScreenStackPanel();
            row.IsHorizontal = true;

            for (int i = 0; i < 12; i++)
            {
                row.AddToStack(new Screen1Quad(sz, next()));
                row.AddToStack(ScreenSpacer.Horizontal(5));

                if (i % 4 == 3)
                {
                    panel.AddToStack(row);
                    panel.AddToStack(ScreenSpacer.Vertical(5));
                    row = new ScreenStackPanel();
                    row.IsHorizontal = true;
                }
            }

            return panel;
        }


        /// <summary>
        /// Creates an example image whose pixel values are specified by a numeric value
        /// that, for convenience, is generated from a simple mathematical function.
        /// </summary>
        /// <returns></returns>
        private static RealImage CreateExampleValueImage(int W = 100, int H = 100)
        {
            double[] vals = new double[W * H];
            for (int h = 0; h < H; h++)
                for (int w = 0; w < W; w++)
                {
                    double t = Math.Cos(w * 0.08) * h / H;
                    vals[w + W * h] = t * 1000;
                }

            RealImage im = new RealImage(vals, W, H);
            return im;
        }
    }
}
