using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Management_System.Supplements
{
    internal class SupplementsRepo
        
    {
        // Making file
        private string file = "Supplements.txt";

        // Constructor
        public SupplementsRepo() { }


        public void SaveinFile(SupplementsModel suppModel)
        {
            using( StreamWriter writer = new StreamWriter(file,true))
            {
                writer.WriteLine(suppModel.ToString());
            }
        }

        // Saving data from list in the file by first deleting the all data from file then adding the new data in the list from file
        public void SaveInFileFromList(List<SupplementsModel> suppModel)
        {
            File.WriteAllText(file,"");
            foreach(SupplementsModel supp in suppModel)
            {
                SaveinFile(supp);
            }
        }



 
        // Get data from file in the list
        public List<SupplementsModel> LoadFromFileinList()
        {
            List<SupplementsModel> supplements= new List<SupplementsModel>();
            using ( StreamReader reader = new StreamReader(file))
            {
                string line = "";
                while (( line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string suppName = parts[0];
                    double suppPrice = Double.Parse(parts[1]);

                    SupplementsModel supplement = new SupplementsModel(suppName, suppPrice);
                    supplements.Add(supplement);
                }
                return supplements;
            }
        }
    }

}
