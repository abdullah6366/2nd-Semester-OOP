using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System.Supplements
{
    internal class SupplementsService
    {
        public SupplementsRepo supplementsRepo;

        public SupplementsService()
        {
            supplementsRepo = new SupplementsRepo();
        }

        public List<SupplementsModel> getAllSupplements()
        {
            List<SupplementsModel> supplements = supplementsRepo.LoadFromFileinList();
            return supplements;
        }

        public bool AddSupplement(string supplementName, double suppPrice)
        {
            if ( suppPrice <= 0 )
            {
                return false;
            }
            List<SupplementsModel> supplements = supplementsRepo.LoadFromFileinList();
            foreach ( SupplementsModel s in supplements )
            {
                if (s.SupplementName == supplementName)
                {
                    return false;
                }
            }
                SupplementsModel supplement = new SupplementsModel(supplementName, suppPrice);
            supplements.Add(supplement);
            supplementsRepo.SaveInFileFromList(supplements);
            return true;
        }

        public SupplementsModel SearchSupplements(string name)
        {
            List<SupplementsModel> supplements = supplementsRepo.LoadFromFileinList();
            foreach( SupplementsModel s in supplements )
            {
                if ( s.SupplementName.ToLower().Trim() == name )
                {
                    return s;
                }
            }
            return null;
        }

        public bool UpdateSupplementPrice(string name, double price)
        {
            if (price <= 0)
            {
                return false;
            }
            List<SupplementsModel> supplements = supplementsRepo.LoadFromFileinList();
            foreach (SupplementsModel s in supplements)
            {
                if (s.SupplementName.ToLower().Trim() == name)
                {
                    s.SupplementPrice= price;
                    supplementsRepo.SaveInFileFromList(supplements);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteSupplement(string name)
        {
            List<SupplementsModel> supplements = supplementsRepo.LoadFromFileinList();
            foreach (SupplementsModel s in supplements)
            {       
                if (s.SupplementName.ToLower().Trim() == name)
                {
                    supplements.Remove(s);
                    supplementsRepo.SaveInFileFromList(supplements);
                    return true;
                }    
            }
            return false;
        }

    }
}
