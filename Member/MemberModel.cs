using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Management_System.Plan;

namespace Gym_Management_System.Member
{
    internal class MemberModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string BodyType { get; set; }
        public PlanModel Plan { get; set; }


        public MemberModel(string name, int age, double weight, double height, string bodyType, PlanModel plan)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            BodyType = bodyType;
            Plan = plan;
        }

        public override string ToString()
        {
            return $"{Name},{Age},{Weight},{Height},{BodyType},{Plan.PlanId}";
        }
    }
}
