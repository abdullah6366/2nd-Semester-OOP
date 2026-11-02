using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public List<PlanModel> SearchFeature(int Id, double maxPrice, double minPrice, string name, string priceRange)
        {
            List<PlanModel> plan = planRepo.LoadFromFile();
            List<PlanModel> newList = new List<PlanModel>();
            if (Id != 0 && name.ToLower() != "no" && priceRange != "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanId == Id && m.PlanName.Contains(name.ToLower()) && m.MonthlyFee <= maxPrice && m.MonthlyFee >= minPrice)
                    {
                        newList.Add(m);
                        

                    }
                   
                }
                return newList;
            }
            else if (Id != 0 && name.ToLower() != "no" && priceRange == "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanId == Id && m.PlanName.ToLower().Contains(name))
                    {
                        newList.Add(m);
                        
                    }
                }
                return newList;
            }
            else if (Id != 0 && name.ToLower() == "no" && priceRange == "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanId == Id)
                    {
                        newList.Add(m);
                       
                    }

                }
                return newList;
            }
            else if (Id != 0 && name.ToLower() == "no" && priceRange != "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanId == Id && m.MonthlyFee <= maxPrice && m.MonthlyFee >= minPrice) ;
                    {
                        newList.Add(m);
                       
                    }
                }
                return newList;
            }
            else if (Id == 0 && name != "no" && priceRange != "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanName.ToLower().Contains(name) && m.MonthlyFee <= maxPrice && m.MonthlyFee >= minPrice)
                    {
                        newList.Add(m);
                        
                    }

                }
                return newList;
            }

            else if (Id == 0 && priceRange == "no" && name != "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.PlanName.ToLower().Contains(name))
                    {
                        newList.Add(m);
                        
                    }
                }
                return newList;
            }
            else if (Id == 0 && name.ToLower() == "no" && priceRange != "no")
            {
                foreach (PlanModel m in plan)
                {
                    if (m.MonthlyFee <= maxPrice && m.MonthlyFee >= minPrice)
                    {
                        newList.Add(m);
                        
                    }
                }
                return newList;
            }
            else if (Id == 0 && name.ToLower() == "no" && priceRange == "no")
            {
                newList = plan;
                return newList;
            }
            return newList;
        }
    }
}
