using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Plan;

namespace Gym_Management_System.Member
{
    internal class MemberRepo
    {
        private string file = "Member.txt";
        public MemberRepo() { }

        // Adding a new member 
        public void SaveInFileFromUser(MemberModel membermodel)
        {
            using ( StreamWriter save = new StreamWriter(file,true))
            {
                save.WriteLine(membermodel.ToString());
            }
        }

        // updating or deleting a member 
        public void SaveAllDataInFileFromList(List<MemberModel> members)
        {
            File.WriteAllText(file,"");
            foreach (MemberModel member in members)
            {
                SaveInFileFromUser(member);
            }
        }


        // This will load the data from file, store the data in the list, check the last value ( PlanId ) fron the list of members , then compare it 
        // with the PlanID in the whole plans list and if it find the matching one then it will store all the attributes of the member class and an object
        // from the plan model class into the members list.
        //return $"{Name},{Age},{Weight},{Height},{BodyType},{Plan.PlanName}";
        public List<MemberModel> LoadFromFile(List<PlanModel> plansList )
        {
            List<MemberModel> listMemberModel = new List<MemberModel>();
            using ( StreamReader reader = new StreamReader(file))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    double weight = double.Parse(parts[2]);
                    double height = double.Parse(parts[3]);
                    string bodytype = parts[4];
                    int planId = int.Parse(parts[5]);

                    PlanModel selectedPlan = null;
                    foreach(PlanModel p in plansList)
                    {
                        if ( p.PlanId == planId)
                        {
                            selectedPlan = p;
                        }
                    }
                    if ( selectedPlan != null )
                    {
                        MemberModel member = new MemberModel(name, age, weight, height, bodytype, selectedPlan);
                        selectedPlan.members.Add(member); // Add the members to their selected plan 
                        listMemberModel.Add(member);
                    }
                }
                return listMemberModel;
            }
        }
        public void LoadFromFile2()
        {

        }
    }
}
