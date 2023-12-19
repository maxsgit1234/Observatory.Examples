using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms.Integration;


namespace Framework.Wpf
{
    public class ObsControl : UserControl
    {
        public WindowsFormsHost Host = new WindowsFormsHost();

        public System.Windows.Forms.Panel MainPanel =
            new System.Windows.Forms.Panel();

        public ObsControl()
        {
            Host.Child = MainPanel;
            Content = Host;
        }
    }
}
