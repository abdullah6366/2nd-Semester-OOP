using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Plan;

namespace Gym_Management_System.Member
{
    internal class MemberUI
    {
        private MemberService memberservice;

        public MemberUI()
        {
            memberservice = new MemberService();
        }

        public void showAllMembers(List<PlanModel> plansList)
        {
            List<MemberModel> members = memberservice.GetAllMembers(plansList);
            DisplayMembers(members);
        }
        public void DisplayMembers(List<MemberModel> members)
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No members found ---");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-----------------------------------MemberDetails-----------------------------------------\n");
            foreach (MemberModel member in members)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"     Name             Age            Weight              Height            BodyType \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"     {member.Name}             {member.Age}               {member.Weight}                {member.Height}                {member.BodyType}\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                    Membership Plan  \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Plan Name : {member.Plan.PlanName}             Monthly Fee : {member.Plan.MonthlyFee}");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------\n");
            }
        }

        public void SearchMembers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------Search Member By Name-----------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the name of the member that you want to search : ");
            string name = Console.ReadLine().ToLower().Trim();
            MemberModel m = memberservice.SearchByName(name);
            if (m == null)
            {
                Console.WriteLine("No Member Found");
            }
            else
            {
                Console.WriteLine($"Name: {m.Name}      Age: {m.Age}     Weight: {m.Weight}     Height: {m.Height}     BodyType: {m.BodyType}   \n");
                Console.WriteLine("-------------------------- Membership Plan ------------------------------\n");
                Console.WriteLine($"PlanId: {m.Plan.PlanId}         PlanName: {m.Plan.PlanName}           MonthlyFee: {m.Plan.MonthlyFee}  ");
            }
        }
        public void AddMembers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------Adding Members -----------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the name of the member : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Age of the member : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the weight of the member : ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter the height of the member : ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Enter the body type : ");
            string bodyType = Console.ReadLine();
            Console.Write("Enter the planID for member (1 or 2) : ");
            int Planid = int.Parse(Console.ReadLine());
            bool result = memberservice.AddMember(name, age, weight, height, bodyType, Planid);
            if (result) Console.WriteLine("\nMember added successfully !!!");
            else
            {
                Console.WriteLine("A member with this name already exists");
            }
        }

        public void UpdateMembers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------------------------ Update Members -----------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter name of the member that you want to update : ");
            string searchName = Console.ReadLine().Trim().ToLower();
            Console.Write("Enter New name of the member : ");
            string name = Console.ReadLine();
            Console.Write("Enter New Age of the member : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter New weight of the member : ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter New height of the member : ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Enter New body type : ");
            string bodyType = Console.ReadLine();
            Console.Write("Enter New planID for member (1 or 2) : ");
            int Planid = int.Parse(Console.ReadLine());
            if (memberservice.UpdateMember(searchName, name, age, weight, height, bodyType, Planid))
            {
                Console.WriteLine("Record Updated Successfully !!!");
                Console.WriteLine($"Updated Record : {name}  {age}  {weight}  {height}  {bodyType}  {Planid}");
            }
            else
            {
                Console.WriteLine($"Record not Updated XXX, Member not found against the name {searchName}");
            }
        }
        public void DeleteMembers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n------------------------------ Delete Members -----------------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter name of the member that you want to delete : ");
            string searchName = Console.ReadLine().Trim().ToLower();
            if(memberservice.DeleteMember(searchName))
            {
                Console.WriteLine("Record deleted succesfully 🗑️");
            }
            else
            {
                Console.WriteLine($"No record found against the name {searchName}");
            }
        }
    }
}
