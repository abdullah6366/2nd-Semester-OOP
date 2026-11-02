using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Plan;

namespace Gym_Management_System.Member
{
    internal class MemberService
    {
        private MemberRepo memberRepo;
        private PlanService planService;

        public MemberService()
        {
            memberRepo = new MemberRepo();
            planService = new PlanService();
        }

        public List<MemberModel> GetAllMembers(List<PlanModel> plansList)
        {
          return memberRepo.LoadFromFile(plansList);
        }

        public MemberModel SearchByName(string name)
        {           
            List<PlanModel> list = planService.GetAllPlans();
            foreach (MemberModel m in memberRepo.LoadFromFile(list))
            {
                if ( m.Name.ToLower() == name)
                    return m;
            }
           return null;
        }

        public bool AddMember(string name, int age, double weight, double height, string bodyType, int Planid )
        {
            List<PlanModel> planslist = planService.GetAllPlans();
            List<MemberModel> members = memberRepo.LoadFromFile(planslist);
            foreach (MemberModel m in members)
            {
                if (m.Name.ToLower() == name)
                {
                    return false;
                }      
            }
            PlanModel selectedPlan = null;
            foreach (PlanModel plan in planslist)
            {
                if (plan.PlanId == Planid)
                {
                    selectedPlan = plan;
                    break;
                }
            }
            if (selectedPlan == null)
            {
                return false;
            }
            MemberModel member = new MemberModel(name, age, weight, height, bodyType, selectedPlan);
            members.Add(member);
            selectedPlan.members.Add(member);
            memberRepo.SaveAllDataInFileFromList(members);
            return true;    
        }

        public bool UpdateMember(string name,string newname, int age, double weight, double height, string bodyType, int newPlanId)
        {
            List<PlanModel> list = planService.GetAllPlans();
            List<MemberModel> members = memberRepo.LoadFromFile(list);
            PlanModel SelectedPlan = null;
            foreach(PlanModel l in list)
            {
                if ( l.PlanId == newPlanId)
                {
                    SelectedPlan = l;
                    break;
                }
            }
            if ( SelectedPlan == null)
            {
                return false;
            }
            foreach (MemberModel m in members)
            {
                if (m.Name.ToLower().Trim() == name)
                {
                    m.Name = newname;
                    m.Age = age;
                    m.Weight = weight;
                    m.Height = height;
                    m.BodyType = bodyType;
                    m.Plan = SelectedPlan;
                    memberRepo.SaveAllDataInFileFromList(members);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteMember(string name)
        {
            List <PlanModel> plans = planService.GetAllPlans();
            List<MemberModel> list = memberRepo.LoadFromFile(plans);
            foreach( MemberModel l in list)
            {
                if ( l.Name.ToLower().Trim() == name)
                {
                    list.Remove(l);
                    memberRepo.SaveAllDataInFileFromList(list);
                    return true;
                }
            }
            return false;
        }
    }
}
