using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System.Supplements
{
    internal class SupplementsModel
    {

        public string SupplementName { get; set; }
        public double SupplementPrice { get; set; }

        public SupplementsModel(string name, double price)
        {
            SupplementName = name;
            SupplementPrice = price;
        }

        public override string ToString()
        {
            return $"{SupplementName},{SupplementPrice}";
        }
    }
}
