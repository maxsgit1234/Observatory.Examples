using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NET.ConsoleApp
{
    internal class ScratchPad
    {
        private static Stopwatch _Watch = new Stopwatch();

        /// <summary>
        /// Shorthand for Console.WriteLine();
        /// </summary>
        /// <param name="s"></param>
        public static void W(string s)
        {
            s = "[Thread=" + Environment.CurrentManagedThreadId + "] " + s;

            lock (_Watch)
            {
                long ms = _Watch.ElapsedMilliseconds;
                _Watch.Restart();

                DateTime now = DateTime.Now;
                string ss = now.ToString("HH:mm:ss.fff")
                    + " | " + ms.ToString().PadLeft(5) + " | " + s;
                Console.WriteLine(ss);
            }
        }
    }
}
