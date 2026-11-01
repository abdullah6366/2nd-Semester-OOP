using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Member;

namespace Gym_Management_System.Plan
{
    internal class PlanModel
    {
        private MemberRepo memberRepo;
        private PlanService planService;
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public double MonthlyFee { get; set; }
        public List<MemberModel> members { get; set; }
        public PlanModel(int planId, string planName, double monthlyFee)
        {

            members = new List<MemberModel>();
            PlanName = planName;
            MonthlyFee = monthlyFee;
            PlanId = planId;
            memberRepo = new MemberRepo();
            planService = new PlanService();
        }
        public override string ToString()
        {
            return $"{PlanId},{PlanName},{MonthlyFee}";
        }
    }
}
