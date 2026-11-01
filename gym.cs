using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Member;
using Gym_Management_System.Plan;
using Gym_Management_System.Supplements;


namespace Gym_Management_System
{
    internal class gym
    {
        // Driver Code 
        private MemberUI memberUI;
        private PlanUI planUI;
        private SupplementsUI supplementsUI;
        private PlanService planService;
        

        public gym()
        {
            memberUI = new MemberUI();
            planUI = new PlanUI();
            supplementsUI = new SupplementsUI();
            planService = new PlanService();
        }
        public void Start()
        {
            MainMenu();
            OptionChecker();
        }
        public void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine("|                      *      GYM Management System    *                         |");
            Console.WriteLine("|--------------------------------------------------------------------------------|\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose an option ( number )");
            Console.WriteLine("1. Manager Menu");
            Console.WriteLine("2. Member Menu");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("3. Exit");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void ManagerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine("|                             *      Manager Menu    *                           |");
            Console.WriteLine("|--------------------------------------------------------------------------------|\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose an option");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------- Members -----------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Show All Members ");
            Console.WriteLine("2. Search Member");
            Console.WriteLine("3. Add Member");
            Console.WriteLine("4. Update Member");
            Console.WriteLine("5. Delete Member");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------- Plans -------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("6. Show Plans");
            Console.WriteLine("7. Search Plan");
            Console.WriteLine("8. Update Fee Plan");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------- Supplements -------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("9. Show All Supplements ");
            Console.WriteLine("10. Add Supplements ");
            Console.WriteLine("11. Search Supplement ");
            Console.WriteLine("12. Update Supplement Price");
            Console.WriteLine("13. Delete Supplement ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("14. Back");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void MemberMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine("|                             *      Member Menu    *                            |");
            Console.WriteLine("|--------------------------------------------------------------------------------|\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Choose an option (Number)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Register ");
            Console.WriteLine("2. View my Record");
            Console.WriteLine("3. View Plans");
            Console.WriteLine("4. View Supplements");
            Console.WriteLine("5. Back");
        }

        public bool MemberOption()
        {
            Console.Write("Choose Option (number) : ");
            string choice = Console.ReadLine().Trim();
            if(choice == "5")
            {
                return true;
            }
            else if (choice == "1")
            {
                // Register
                memberUI.AddMembers();
               
            }
            else if (choice == "2")
            {
                // Search Member ( View My Record ) 
                memberUI.SearchMembers();
            }
            else if (choice == "3")
            {
                // All Plans show
                planUI.ShowAllPlans();
            }
            else if (choice == "4")
            {
                //  All Supplements Display
                supplementsUI.DisplayAllSupplements();
            }
            else
            {
                Console.WriteLine("Option Enterted is invalid");
            }
            return false;
        }
        public bool managerOption()
        {
            Console.Write("Choose Option: ");
            string choice = Console.ReadLine().Trim();

            if (choice == "14")
            {
                return true;
            }
            if (choice == "1")
            {
                // Show all members
                List<PlanModel> plans = planService.GetAllPlans();
                memberUI.showAllMembers(plans);
            }
            else if (choice == "2")
            {
                // Search member
                memberUI.SearchMembers();
            }
            else if (choice == "3")
            {
                // Add member
                memberUI.AddMembers();
            }
            else if (choice == "4")
            {
                // Update member
                memberUI.UpdateMembers();
            }
            else if (choice == "5")
            {
                // Delete member
                memberUI.DeleteMembers();
            }
            else if (choice == "6")
            {
                // Show plans
                planUI.ShowAllPlans();
            }
            else if (choice == "7")
            {
                // Search Plan
                planUI.SearchPlan();
            }
            else if (choice == "8")
            {
                // Update plan fee
                planUI.UpdatedPlan();
            }
            else if (choice == "9")
            {
                // Show supplements
                supplementsUI.DisplayAllSupplements();
            }
            else if (choice == "10")
            {
                // Add supplement
                supplementsUI.AddSupplement();
            }
            else if (choice == "11")
            {
                // Search Supplement
                supplementsUI.SearchedSupp();
            }
            else if (choice == "12")
            {
                // update supplement price 
                supplementsUI.UpdatedSupplement();
            }
            else if (choice == "13")
            {
                // Delete Supplement
                supplementsUI.DeleteSupplement();
            }
            else
            {
                // Invalid option
                Console.WriteLine("Your Option enetered is invalid ... ");
            }
            return false;
        }

        public void ManagerMenuLoop()
        {
            while (true)
            {
                Console.Clear();
                ManagerMenu();

                if (managerOption())
                {
                    return;
                }

                Pause();
            }
        }
        public void MemberMenuLoop()
        {
            while (true)
            {
                Console.Clear();
                MemberMenu();

                if (MemberOption())
                {
                    return;
                }

                Pause();
            }
        }
        public void OptionChecker()
        {
            while (true)
            {
                Console.Clear();
                MainMenu();

                Console.Write("\nYour Option: ");
                string option = Console.ReadLine().Trim();

                if (option == "1")
                {
                    ManagerMenuLoop();
                }
                else if (option == "2")
                {
                    MemberMenuLoop();
                }
                else if (option == "3")
                {
                    Console.WriteLine("Thank you for using Gym Management System!");
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option!");
                    Pause();
                }
            }
        }
    }
}

