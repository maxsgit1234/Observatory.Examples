using ObservatoryLib;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Net.Wpf
{
    // This project shows how to embed an Observatory figure
    // inside a System.Windows.Window by using an ObsControl,
    // which is a custom WPF control.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Platform.Init();
            this.Initialized += MainWindow_Initialized;
            InitializeComponent();
        }

        private void MainWindow_Initialized(object? sender, EventArgs e)
        {
            WindowsFormsHost host = this.obsControl1.Host;
            ObsPanel panel = new ObsPanel();
            host.Child = panel;
            panel.AddFigure(new Plot2d());
        }
    }
}