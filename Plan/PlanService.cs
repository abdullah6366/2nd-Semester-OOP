using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Member;

namespace Gym_Management_System.Plan
{
    internal class PlanService
    {
        private PlanRepo planRepo;

        public PlanService()
        {
            planRepo = new PlanRepo();
        }

        public List<PlanModel> GetAllPlans()
        {
            return planRepo.LoadFromFile();
        }

        public PlanModel SearchPlanByName(string name)
        {
            foreach (PlanModel m in planRepo.LoadFromFile())
            {
                if (m.PlanName.ToLower() == name) return m;
            }
            return null;
        }

        public bool UpdatePlanPrice(string name, double newPrice)
        {
            if (newPrice <= 0)
            {
                return false;
            }

            List<PlanModel> plans = planRepo.LoadFromFile();

            foreach (PlanModel m in plans)
            {
                if (m.PlanName.ToLower() == name)
                {
                    m.MonthlyFee = newPrice;
                    planRepo.SaveAllDataInFileFromList(plans);
                    return true;
                }
            }

            return false;
        }
    }
}
