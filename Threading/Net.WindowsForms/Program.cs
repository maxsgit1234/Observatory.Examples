namespace Net.WindowsForms
{
    internal static class Program
    {
        // This project shows how to embed an Observatory figure
        // inside a System.Windows.Forms.Form by using an ObsPanel control.

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}