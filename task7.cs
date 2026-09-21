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
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            int number = int.parse(input);
            if(number>50)
            {
                Console.WriteLine("You Passed.");
            }
            else
            {
                Console.WriteLine("You Failed.");
            }
            Console.Read();
        }    
    }
}