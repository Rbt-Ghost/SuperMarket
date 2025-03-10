using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket // Tema #1
{
    class Casier : Persoana
    {
        public int nrCasa {  get; set; } // Tema #2 Adaugarea Auto-Properties
        public double Salary { get; set; }
        public Casier(string Name, int Age, int ID, int nrCasa, double Salary)
            : base(Name, Age, ID)
        {
            this.nrCasa = nrCasa;
            this.Salary = Salary;
        }
        public void DisplayCasierInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Casa: {nrCasa}, Salary: {Salary}");
        }
        public bool CautareCasier (string SrcName) // Tema #2 Cautare dupa Nume
        {
            return CautarePers(SrcName);
        }
        public static Casier CitireFisierC(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5)
            {
                return new Casier(
                    data[0].Trim(),                  // Name
                    int.Parse(data[1].Trim()),        // Age
                    int.Parse(data[2].Trim()),        // ID
                    int.Parse(data[3].Trim()),        // RaionID
                    double.Parse(data[4].Trim())      // Salary
                );
            }
            else
            {
                Console.WriteLine("Invalid data format for Casier.");
                return null;
            }
        }

    }
}
