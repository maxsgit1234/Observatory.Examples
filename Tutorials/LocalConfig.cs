using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservatoryLib.IO;

namespace Examples
{
    public static class LocalConfig
    {
        private static string _ExampleDataDir = null;
        public static string ExampleDataDir
        {
            get
            {
                if (_ExampleDataDir == null)
                {
                    _ExampleDataDir = "";
                    if (File.Exists("ExamplesConfig.txt"))
                    {
                        string[] lines = File.ReadAllLines("ExamplesConfig.txt");
                        foreach (string line in lines)
                        {
                            string[] words = line.Split('=').Select(i => i.Trim()).ToArray();
                            if (words.Length > 1 && words[0] == "PathName")
                                _ExampleDataDir = words[1];
                        }
                    }
                }
                return _ExampleDataDir;
            }
        }

        public static string GetFilename(string name)
        {
            return Path.Combine(ExampleDataDir, name);
        }

    }
}
