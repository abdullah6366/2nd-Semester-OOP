using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Member;

namespace Gym_Management_System.Plan
{
    internal class PlanUI
    {
        private PlanService planService;
        public PlanUI() 
        {
        planService = new PlanService();
        }

        public void ShowAllPlans()
        {
            List<PlanModel> plans = planService.GetAllPlans();
            DisplayPlans(plans);
        }
        public void DisplayPlans(List<PlanModel> plans)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\n---------------------------------------- All Membership Plans ----------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (PlanModel plan in plans)
            {
                Console.WriteLine($"Plan ID : {plan.PlanId}                Plan Name : {plan.PlanName}              Monthly Fee : {plan.MonthlyFee} \n"); 
            }
        }
        public void SearchPlan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n ------------------------------------------------ Searching plan by name ------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the name of the plan that you wanna search : ");
            string name = Console.ReadLine().Trim().ToLower();
            Console.WriteLine("");
            PlanModel searchplan = planService.SearchPlanByName(name);
            if (searchplan == null)
            {
                Console.WriteLine($"No plan against this name {name}");
            }
            else
            {
                Console.WriteLine("---------------------------------------------------- Plan Details --------------------------------------------------------\n");
                Console.WriteLine($"Plan ID : {searchplan.PlanId}            Plan Name : {searchplan.PlanName}          | MonthlyFee : {searchplan.MonthlyFee} ");
            }
        }

        public void UpdatedPlan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n ------------------------------------------------ Updating a Plan Fee ------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the name of the plan that you want to update : ");
            string name = (Console.ReadLine().Trim().ToLower());
            PlanModel searchplan = planService.SearchPlanByName(name);
            if (searchplan == null)
            {
                Console.WriteLine($"No plan against this name {name}");
            }
            else
            {
                Console.Write("Enter the new price that you want to update against this Plan :");
                double price = double.Parse( Console.ReadLine() );
                if (planService.UpdatePlanPrice(name, price))
                {
                    Console.WriteLine("Your fee is updated !!!");
                    Console.WriteLine("----------------------------\n");
                    Console.WriteLine("-------------------------- The updated Plan ---------------------------");
                    PlanModel plan = planService.SearchPlanByName(name);
                    Console.WriteLine($"Plan Name : {plan.PlanName}             Monthly Fee : {plan.MonthlyFee}");
                }
                else 
                {
                    Console.WriteLine("Error Occured");
                }
            }
        }
        public void SearchFilter()
        {
            Console.WriteLine("--------------------- Search Filter ----------------------------");
            Console.WriteLine("Do You want to apply search by Plan Id ? ");
            Console.WriteLine("If Yes Then give the PLAN ID TO Search ( 1 or 2 ) if NO then type ( 0 ) ");
            int planId = int.Parse( Console.ReadLine() );
            Console.WriteLine("Do you want to search by something that occurs in plan Name ?");
            Console.WriteLine("If YES then give the name , if NO then type no");
            string option = Console.ReadLine().ToLower();
            Console.WriteLine("Do you want to search by price range ? ( Yes OR NO ) ");
            string priceRangeCheck = Console.ReadLine().ToLower();
            
            if ( priceRangeCheck != "no")
            {
                Console.WriteLine("Enter the max price :");
                double maxPrice = double.Parse( Console.ReadLine());
                Console.WriteLine("Enter the min price : ");
                double minPrice = double.Parse( Console.ReadLine());
                List<PlanModel> searchplan = planService.SearchFeature(planId,maxPrice, minPrice, option, priceRangeCheck);
                foreach(PlanModel plan in searchplan)
                {
                    Console.WriteLine($"Plan Id = {plan.PlanId}   Plan Name = {plan.PlanName}   Fee = {plan.MonthlyFee}"  );
                }
            }
            else if ( priceRangeCheck != "no")
            {
                List<PlanModel> searchplan = planService.SearchFeature(planId,100,100,option, priceRangeCheck);
                foreach (PlanModel plan in searchplan)
                {
                    Console.WriteLine($"Plan Id = {plan.PlanId}   Plan Name = {plan.PlanName}   Fee = {plan.MonthlyFee}");
                }
                ;

            }
           
            
           

        }
    }
}
