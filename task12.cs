using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int age = int.Parse(Console.ReadLine());
        double washingMachinePrice = double.Parse(Console.ReadLine());
        int toyPrice = int.Parse(Console.ReadLine());

        double money = 0;
        int toys = 0;

        for (int birthday = 1; birthday <= age; birthday++)
        {
            if (birthday % 2 == 0)
            {
                money = money + (birthday / 2 * 10 - 1);
            }
            else
            {
                toys++;
            }
        }

        money = money + toys * toyPrice;

        if (money >= washingMachinePrice)
        {
            Console.WriteLine("Yes! {0:F2}", money - washingMachinePrice);
        }
        else
        {
            Console.WriteLine("No! {0:F2}", washingMachinePrice - money);
        }

        Console.Read();
    }
}