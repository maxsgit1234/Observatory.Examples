using ObservatoryLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Framework.ConsoleApp
{
    internal class Program
    {
        public enum ExampleType
        {
            Single,
            Async,
            Forms,
            Wpf,
        }

        private static Dictionary<ExampleType, string> _Descriptions
            = new Dictionary<ExampleType, string>()
        {
            {ExampleType.Single, "Display a single figure." },
            {ExampleType.Async, "Display multiple figures, and asynchronously wait for them to display." },
            {ExampleType.Forms, "Use a button on a System.Windows.Forms.Form to display a figure." },
            {ExampleType.Wpf, "Use a button on a System.Windows.Window to display a figure." },
        };

        private static bool TryParseArgs(string[] args, out ExampleType type)
        {
            Dictionary<string, ExampleType> types = Enum.GetValues(typeof(ExampleType))
                .Cast<ExampleType>().ToDictionary(i => i.ToString().ToLower(), i => i);

            type = default;

            if (args.Length == 0)
            {
                type = ExampleType.Single;
                return true;
            }

            if (args.Length > 1)
                return false;

            string arg = args[0].ToLower();
            return types.TryGetValue(arg, out type);
        }

        private static void PrintUsage()
        {
            ConsoleColor gray = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: Could not parse your input!");
            Console.ForegroundColor = gray;

            Console.WriteLine("");
            Console.WriteLine("Please specify a single command-line argument.");
            Console.WriteLine("Choose from the following options: ");
            foreach (ExampleType t in _Descriptions.Keys.OrderBy(i => i))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(t.ToString().PadLeft(12));
                Console.ForegroundColor = gray;
                Console.WriteLine(": [" + _Descriptions[t] + "]");
            }
            Console.WriteLine("");
            
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (!TryParseArgs(args, out ExampleType type))
            {
                PrintUsage();
                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Running ExampleType: " + type);

            Platform.Init();

            switch (type)
            {
                case ExampleType.Single:
                    DisplaySingleFigure(); break;
                case ExampleType.Async:
                    DisplayFiguresAsync(); break;
                case ExampleType.Forms:
                    LaunchFromButtonFormsWindow(); break;
                case ExampleType.Wpf:
                    LaunchFromButtonOnWpfWindow(); break;
                default:
                    throw new Exception("Unrecognized TestType (somehow): " + type);

            }

            Platform.Run();
        }

        private static void DisplaySingleFigure()
        {
            Plot3d plot = new Plot3d();
            plot.Display(wait: false);
        }

        private static async void DisplayFiguresAsync()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                Plot2d plot = new Plot2d();
                tasks.Add(plot.DisplayAsync());
            }

            await Task.WhenAll(tasks.ToArray());
        }

        private static void LaunchFromButtonFormsWindow()
        {
            Form form = new Form();
            var button = new Button();
            button.Text = "Display plot!";
            button.Click += FormsButtonClicked;
            form.Controls.Add(button);
            form.ShowDialog();
        }

        private static async void FormsButtonClicked(object sender, EventArgs e)
        {
            Plot3d plot = new Plot3d();
            await plot.DisplayAsync();
        }

        private static void LaunchFromButtonOnWpfWindow()
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            var button = new System.Windows.Controls.Button();
            button.Content = "Display plot!";
            button.Click += WpfButton_Click;
            window.Content = button;
            window.ShowDialog();
        }

        private static async void WpfButton_Click(object sender, RoutedEventArgs e)
        {
            Plot3d plot = new Plot3d();
            await plot.DisplayAsync();
        }

    }
}
