using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;

namespace Examples
{
    public class CoordinateSystems : IExample
    {
        private string _Title = "Coordinate Systems";
        public string Title { get { return _Title; } }

        private string _Description = 
            "Specify points, lines, and polygons in data (a.k.a. 'world') space or "
            + "screen (a.k.a. 'pixel') space.";
        public string Description { get { return _Description; } }

        /// <summary>
        /// This method shows how you can build drawings of points, lines, and polygons
        /// in either of 2 coordinate systems: 1) the data space or 2) screen space.
        /// </summary>
        public void Run()
        {
            // Create a DrawingBuilder, which is always drawn in data space. 
            Drawing2 drawing = new Drawing2(15);

            // Add some points, lines, and polygons:
            AddItems(drawing, Colors.LightPurple);

            // Create a ScreenDrawing, which is just like the DrawingBuilder, except 
            // that it always renders in screen space. That is, the positions appear 
            // at a fixed position on the screen always, regardless of panning/zooming.
            // NOTE: The origin of the screen coordinate system is the upper-left of the
            // plot, and Y increases downward.
            ScreenDrawing screen = new ScreenDrawing(15);

            // The ScreenDrawing and Drawing2 objects implement a shared interface,
            // simplifying your interactions with them:
            AddItems(screen, Colors.LightOrange);

            // Create a new 2D plot, and add the DrawingBuilder:
            Plot2d plot = new Plot2d();
            plot.Add(drawing);

            // When adding the ScreenDrawing, we can specify where on the screen we want
            // it to appear. The actual pixel locations of all vertices in the drawing
            // will be calculated relative to the drawing's placement:
            plot.Screen.PlaceLiteral(screen, new Vector2d(100, 100));

            // For clarity, let's also add a legend:
            ScreenLegend legend = plot.AddLegend();
            legend.AddItem("Data (a.k.a. 'World') Coordinates", Colors.LightPurple);
            legend.AddItem("Screen (a.k.a. 'Pixel') Coordinates", Colors.LightOrange);

            // Display the plot, which has both data space and screen space drawings:
            plot.Display();
        }

        private static void AddItems(
            IDrawingBuilder<Point2<Real, Real>, V2<Real, Real>> b, Color color)
        {
            // Just some points that make up part of a parabola:
            Vector2d[] xyPoints = Enumerable.Range(0, 10)
                .Select(i => new Vector2d(i * 10, i * i * 2)).ToArray();

            b.AddPoints(xyPoints, color);

            // We can re-use the same array of points freely:
            b.AddLinesConnected(xyPoints, Colors.Black);


            b.AddTri(new Vector2d(100, 100), new Vector2d(200, 100), 
                new Vector2d(100, 200), color);
        }
    }
}
