using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "G:\\OOP 2022\\BootingCSharp\\textfile.txt";
            StreamWriter filevariable = new StreamWriter(path, true);
            filevariable.WriteLine("hello");
            filevariable.Flush();
            filevariable.Close();
        }
    }
}