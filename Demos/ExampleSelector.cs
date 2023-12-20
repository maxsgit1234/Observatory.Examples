using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObservatoryLib.Extensions;

namespace Demos
{

    public class ExampleSelector : Form
    {

        TableLayoutPanel table = new TableLayoutPanel();
        private int _Row = 0;
        private void AddButton(IExample ex)
        {
            var btn = new Button { Text = ex.Title };
            btn.Click += (s, e) => this.BeginInvoke(new Action(ex.Run));
            btn.AutoSize = true;
            btn.AutoSizeMode = AutoSizeMode.GrowOnly;

            btn.MinimumSize = new Size(200, 0);
            var lbl = new Label { Text = ex.Description };
            
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(300, 1000);

            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.Controls.Add(btn, 0, _Row);
            table.Controls.Add(lbl, 1, _Row);

            _Row++;
            btn.ForeColor = ObservatoryLib.Colors.Black.ToSystem();
            btn.BackColor = ObservatoryLib.Colors.LightGray.ToSystem();
            btn.Margin = new Padding(20, 20, 20, 0);
            lbl.Margin = new Padding(0, 20, 0, 20);
        }

        public ExampleSelector()
        {
            this.Text = "Observatory Demos";
            this.Load += (_, __) => this.Size = table.Size;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

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
            
            table.Padding = new Padding(0, 0, 20, 50);
            this.Controls.Add(table);

            this.BackColor = ObservatoryLib.Colors.White.ToSystem();

            table.AutoSize = true;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
