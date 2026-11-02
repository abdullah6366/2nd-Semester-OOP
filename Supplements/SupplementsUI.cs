using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Plan;

namespace Gym_Management_System.Supplements
{
    internal class SupplementsUI
    {
        public SupplementsService suppService;

        public SupplementsUI()
        {
            suppService = new SupplementsService();
        }

        public void DisplayAllSupplements()
        {
            List<SupplementsModel> supplements = suppService.getAllSupplements();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ----------------------------------------------- All Supplements -----------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"           Supplement Name                                          Supplement Price ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (SupplementsModel supplement in supplements)
            {
              
                Console.WriteLine($"               {supplement.SupplementName}                                                  {supplement.SupplementPrice}");
            }
        }

        public void AddSupplement()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------------- Adding Supplement -------------------------------------\n");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Enter the name of the supplement that you want to add : ");
            string name = Console.ReadLine();
            Console.Write("Enter the price of added supplement : ");
            double price = double.Parse(Console.ReadLine());
            if (suppService.AddSupplement(name, price) == false)
            {
                Console.WriteLine("This supplement already exists or the price enterted is invalid."); 
            }
            else
            {
                Console.WriteLine("Supplement Added in the supplements !!!");
            }
        }

      public void SearchedSupp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----------------------------- Searching Supplement -------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the supplement name that you want to search : ");
            string name = Console.ReadLine().Trim().ToLower();
            if(suppService.SearchSupplements(name) != null)
            {
                SupplementsModel supp = suppService.SearchSupplements(name);
                Console.WriteLine($"\n     Supplement Name : {supp.SupplementName}              Supplement Price : {supp.SupplementPrice}");
            }
        }


        public void UpdatedSupplement()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----------------------------- Updating Supplement -------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the supplement name that you want to update : ");
            string name = Console.ReadLine().Trim().ToLower();
            Console.Write("Enter the supplement updated price : ");
            double price = Double.Parse(Console.ReadLine());
            if (suppService.UpdateSupplementPrice(name,price))
            {
                Console.WriteLine("Price Updated Successful!!!");
            }
            else
            {
                Console.WriteLine("Error Occured");
            }
        }
        public void DeleteSupplement()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n----------------------------- Deleting Supplement ---------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the supplement name that you want to Delete : ");
            string name = Console.ReadLine().Trim().ToLower();
            if (suppService.DeleteSupplement(name))
            {
                Console.WriteLine("Supplement Deleted Successfully !!!");
            }
            else
            {
                Console.WriteLine($"No Supplement againt the name : {name}");
            }
        }
    }
}
