using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;

namespace Demos
{
    public class TextAnnotations : IExample
    {
        public string Title { get { return "Text Annotations"; } }
        public string Description { get { return "Add text labels to a plot, and specify size, color, position, and alignment."; } }


        /// <summary>
        /// This method shows the various ways you can add text annotations 
        /// to your plots. 
        /// </summary>
        public void Run()
        {
            // Let's make a 2D plot, and add some content, just for context:
            Plot2d plot = new Plot2d();
            plot.Drawing.AddPoint(0, 0, Colors.Blue);
            plot.Drawing.AddLine(1, 1, -1, 1, Colors.Red);
            plot.Drawing.AddTri(3, -2, 3, 3, 4, 3, 
                Colors.Green, Colors.LightGreen, Colors.LightBlue);

            // We can label the axes, for example, like this:
            plot.Axes.SetLabels("East-West", "North-South");

            // We can give the plot a conveniently-formatted title like this:
            plot.Screen.AddTitle("My title");

            // We can add text to a specified pixel location on the plot 
            // where (0,0) is the upper-left:
            plot.Screen.AddTextLiteral("Text at pixel (250, 100)", 250, 100);

            // We can also specify the alignment of the text:
            plot.Screen.AddTextLiteral("Aligned Bottom-Right", 
                250, 100, Alignment.BottomRight);

            // We can also optionally specify the color and size of the text as well:
            plot.Screen.AddTextLiteral("Big Blue Text", 100, 150,
                Alignment.TopLeft, 40.0, Colors.Blue, Colors.LightBlue);

            // By specifying a layer, we can determine which appears on top of the
            // other in cases of overlap.
            plot.Screen.AddTextLiteral("Drag me! I'm in layer 2", 250, 450, 
                foreColor: Colors.Red, backColor: Colors.LightRed, layerOffset: 1);

            // By default, all screen items are draggable, but that can be disabled:
            plot.Screen.AddTextLiteral("I'm hiding in layer 0",
                250, 450, enableDragging: false);

            // Text can also be placed in a fractional-position on the screen. To see
            // the difference, try resizing the window. Text at literal positions
            // maintain their relative position to the upper left, whereas text specified
            // fractionally maintains its fractional position within the plot window:
            plot.Screen.AddTextFractional("Text Centered at (0.5,0.5)", 0.5, 0.5);

            // For specialized cases, you can even specify text fractionally
            // with a pixel-wise offset:
            plot.Screen.AddTextWithOffset("50 pixels below center", 0.5, 0.5, 0, 50);

            // Text can also be placed at a point in data space. You can specify the
            // relative alignment as well as a constant pixel offset from that point:
            plot.Text.AddToPlot("Text at (0,0) in data space",
                0, 0, Alignment.BottomCenter, pixelOffset: new Vector2d(0, -10));

            // Displays the plot:
            plot.Display();
        }

    }
}
