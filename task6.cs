using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float len,area;
            Console.WriteLine("Enter length: ");
            len = float.Parse(Console.ReadLine());
            area = len*len;
            Console.Write("Area of square is: ");
            Console.Write(area);
            Console.Read();
        }
    }
}