using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObservatoryLib;

namespace Examples
{
    public class TimeDrawings : IExample
    {
        private string _Title = "Time Plots";
        public string Title { get { return _Title; } }

        private string _Description = 
            "Make a plot where one or more axes represent dates and times.";
        public string Description { get { return _Description; } }

        /// <summary>
        /// This example shows how to make a 2D plot, where the X axis is specified in
        /// units of date and time, and the Y axis is specified numerically. For example,
        /// this may be a common pattern for weather plots.
        /// </summary>
        public void Run()
        {
            // Create some points, whose X coordinates are DateTimes and whose Y 
            // coordinates are numeric values:
            DateTime start = new DateTime(2014, 03, 15);
            DateTime end = new DateTime(2014, 05, 15);
            
            // These times are uniformly spaced from start to end. The "ForObs()" 
            // extension method converts DateTimes to RealTimes in this case. RealTime
            // is an Observatory type to represent time. It wraps a System.DateTime:
            DateTime[] times = ObsMath.LinspaceTimes(start, end, 100).ToArray();

            // Let's just generate some random numeric values for the Y axis:
            ObsRandom r = new ObsRandom();
            double[] yValues = r.NextNormalValues(100, 10, 3.0);

            // Note that we now use the generic base class of Drawing2, which 
            // allows us to strongly type the data expected on each axis:
            var b = new TimeDrawing2(20);
            
            // Add points to the drawing, whose types match the expected (generic) types:
            b.AddPoints(times, yValues, Colors.Blue);

            // Vertices for lines and triangles and supplied in an analogous manner:
            b.AddLinesConnected(times, yValues, Colors.Black);

            // Implicit conversion are defined from DateTime -> RealTime
            // and from double -> Real, making some calls more convenient:
            b.AddTri(
                start + TimeSpan.FromDays(6), 0,
                start + TimeSpan.FromDays(15), 2,
                start + TimeSpan.FromDays(10), 2, Colors.Red);

            // Note that we must create a plot with matching generic types for the axes
            // in order to successfully add the generic drawing:
            Plot2d<RealTime, Real> plot = new Plot2d<RealTime, Real>();
            plot.Add(b);

            // Display the plot just as before:
            plot.Display();
        }
    }
}
