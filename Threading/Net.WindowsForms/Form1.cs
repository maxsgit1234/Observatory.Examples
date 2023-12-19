using ObservatoryLib;

namespace Net.WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Platform.Init();
            InitializeComponent();
            this.obsPanel1.HandleCreated += ObsPanel1_HandleCreated;
        }

        private void ObsPanel1_HandleCreated(object? sender, EventArgs e)
        {
            obsPanel1.AddFigure(new Plot3d());
        }
    }
}
