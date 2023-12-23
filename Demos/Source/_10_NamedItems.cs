using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib;
using ObservatoryLib.Drawing;

namespace Demos
{
    public class NamedItems : IExample
    {
        public string Title { get { return "Named Items"; } }
        public string Description { get { return "Give names to plot components, and handle events that reference those names."; } }

        /// <summary>
        /// This method demonstrates how to handle events raised by a plot in response to 
        /// real-time user interactions:
        /// </summary>
        public void Run()
        {
            new NamedItemPlot().Create();
        }
    }

    public class NamedItemPlot
    {

        private Dictionary<Name, string> _AllNames = new Dictionary<Name, string>();
        private ScreenString _ClickText, _HoverText;

        public void Create()
        {
            // Create a new 2D plot object:
            Plot2d plot = new Plot2d();

            // Add a series of rectangles to the plot's default DrawingBuilder:
            double d = 1.1;
            AddUnitRectangle(plot.Drawing,
                new Vector2d(0 * d, 0), Colors.Blue, "Blue");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(1 * d, 0), Colors.Green, "Green");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(2 * d, 0), Colors.Red, "Red");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(3 * d, 0), Colors.Orange, "Orange");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(0 * d, d), Colors.LightBlue, "LightBlue");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(1 * d, d), Colors.LightGreen, "LightGreen");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(2 * d, d), Colors.LightRed, "LightRed");
            AddUnitRectangle(plot.Drawing,
                new Vector2d(3 * d, d), Colors.LightOrange, "LightOrange");

            // Add a label to display a value based on the user's clicks:
            _ClickText = plot.Screen.AddTextFractional(
                "Click on a color...", 0.5, 0.03, Alignment.TopCenter, 40);

            // Add a label to display a value based on the user's mouse motion:
            _HoverText = plot.Screen.AddTextFractional(
                "Hover over a color...", 0.5, 0.13, Alignment.TopCenter, 40);

            // Register to handle events raised by the plot:
            plot.NamedItemClicked += plot_NamedItemClicked;
            plot.NamedItemMouseOver += plot_NamedItemMouseOver;

            // Adjust and display:
            plot.Axes.SetScaleEquality(true);
            plot.Display();
        }

        // Adds a unit rectangle to the specified builder with the specified location
        // and color. Also assigns a unique (Guid) name to the rectangle, and stores
        // that name for later lookup:
        private void AddUnitRectangle(Drawing2<Real, Real> b,
            Vector2d ll, Color color, string label)
        {
            Vector2d dx = new Vector2d(1, 0);
            Vector2d dy = new Vector2d(0, 1);
            Vector2d dxy = dx + dy;

            Name name = Name.NewName();
            _AllNames.Add(name, label);
            b.AddQuad(ll, ll + dx, ll + dxy, ll + dy, color, name);
        }

        // Handles the event raised by the plot when a user clicks on any named item by
        // updating the text of a label that we previously added to the plot. Note that 
        // many items in the plot other than ones you explicitly defined may have names, 
        // and may have prompted this event to be raised, so you must always check to see
        // if the name is one that you recognize. Note also that both the handling and 
        // responding actions can be done here in any thread. For convenience, this is
        // handled on the thread that raised the event.
        void plot_NamedItemMouseOver(Name id)
        {
            lock (this)
            {
                if (!_AllNames.ContainsKey(id))
                {
                    OConsole.WriteLine("Hovered over something else!");
                    return;
                }

                string color = _AllNames[id];
                _HoverText.ReplaceText("Hovered over: " + color);
            }
        }

        // Similarly, handles the event raised by the plot when a user hovers over any
        // named item. In both cases, this event is only ever fired at most once per
        // frame.
        void plot_NamedItemClicked(MouseEventActivatedArgs obj)
        {
            lock (this)
            {
                if (!_AllNames.ContainsKey(obj.Id))
                {
                    OConsole.WriteLine("Clicked on something else!");
                    return;
                }

                string color = _AllNames[obj.Id];
                _ClickText.ReplaceText("Clicked on: " + color);
            }
        }

    }
}
