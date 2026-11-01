using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Member;



namespace Gym_Management_System.Plan
{
    internal class PlanRepo
    {
        private string file= "Plan.txt";

        public PlanRepo() { }

        public void SaveInFile(PlanModel planmodel)
        {
            using (StreamWriter writer = new StreamWriter(file,true))
            {
                writer.WriteLine(planmodel.ToString());
            }
        }


        public void SaveAllDataInFileFromList(List<PlanModel> plans)
        {
            File.WriteAllText(file,"");
            foreach(PlanModel p in plans)
            {
                SaveInFile(p);
            }
        }

         //return $"{PlanId},{PlanName},{MonthlyFee},{members}";
        public List<PlanModel> LoadFromFile()
        {
            List<PlanModel> plansList = new List<PlanModel>();
            using ( StreamReader reader = new StreamReader(file))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int planid = int.Parse(parts[0]);
                    string planName = parts[1];
                    double monthlyFee = double.Parse(parts[2]);

                    PlanModel plan = new PlanModel(planid, planName, monthlyFee);
                    plansList.Add(plan);
                    
                }

            }
            return plansList;
        }
    }
}
