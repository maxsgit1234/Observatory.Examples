using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ObservatoryLib;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Forms;
using ObservatoryLib.Extensions;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Platform.Init();

            //window.SizeToContent = SizeToContent.WidthAndHeight;
            //form. = "Observatory Examples";
            var form = new ExampleSelector();
            form.Dock = DockStyle.Fill;

            form.Show();

            Console.WriteLine("Running Observatory Examples Project...");

            Application.Run();
        }

        public static void AddToDoList(Viz viz, params string[] items)
        {
            PinButton button = PinButton.ToDoList(items);
            viz.Stage.PlaceChildLiteral(button, new Vector2d(0, 0));
        }
    }

    public class ExampleSelector : Form
    {
		FlowLayoutPanel panel = new FlowLayoutPanel();
        private void AddButton(IExample ex)
        {
            var btn = new Button { Text = ex.Title };
            btn.Click += (s, e) => this.BeginInvoke(new Action(ex.Run));
            btn.MinimumSize = new Size(120, 0);
            btn.Anchor = AnchorStyles.Top;
            var lbl = new Label { Text = ex.Description };
            lbl.Anchor = AnchorStyles.Left;
            lbl.MinimumSize = new Size(200, 50);

            var p = new FlowLayoutPanel();
            p.FlowDirection = FlowDirection.LeftToRight;
            p.AutoSize = true;
            p.Controls.Add(btn);
            p.Controls.Add(lbl);
            panel.Controls.Add(p);
            panel.FlowDirection = FlowDirection.TopDown;
            btn.ForeColor = ObservatoryLib.Colors.Black.ToSystem();
            btn.BackColor = ObservatoryLib.Colors.LightGray.ToSystem();
            panel.Padding = new Padding(10);
        }

        public ExampleSelector()
        {
            this.Resize += (_, __) => panel.Size = this.ClientSize;
            this.Load += (_, __) => this.Size = new Size(400, 680);
            
            AddButton(new SimplePlot3d());
            AddButton(new SimplePlot2d());
            AddButton(new SimpleHistogram());
            AddButton(new SimpleHeatMap());
            AddButton(new CoordinateSystems());
            AddButton(new TextAnnotations());
            AddButton(new Images());
            AddButton(new ColorDemo());
            AddButton(new Figures());
            AddButton(new TimeDrawings());
            AddButton(new NamedItems());
            this.Controls.Add(panel);

            this.BackColor = ObservatoryLib.Colors.White.ToSystem();
        }
    }
}
