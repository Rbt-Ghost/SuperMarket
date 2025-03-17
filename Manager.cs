using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket 
{
    class Manager : Persoana // Tema #1
    {
        public string Departament {  get; set; } // Tema #2 Adaugarea Auto-Properties
        public double Salary { get; set; }

        public Manager() { }

        public Manager(string Name, int Age, int ID, string Departament, double Salary)
            : base(Name, Age, ID)
        {
            this.Departament = Departament;
            this.Salary = Salary;
        }
        public void DisplayManagerInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Departament: {Departament}, Salary: {Salary}");
        }
        public bool CautareManager( string SrcName) // Tema #2 Cautare dupa Nume
        {
            return (CautarePers(SrcName));
        }
        public static Manager CitireFisierM(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5)
            {
                return new Manager(
                    data[0].Trim(),                     // Name
                    int.Parse(data[1].Trim()),           // Age
                    int.Parse(data[2].Trim()),           // ID
                    data[3].Trim(),                     // Departament
                    double.Parse(data[4].Trim())         // Salary
                );
            }
            else
            {
                Console.WriteLine("Invalid data format.");
                return null;
            }
        }
        public Manager InsertManager() // Tema #3
        {
            InsertPers();

            do
            {
                Console.Write("Departament: ");
                Departament = Console.ReadLine();
            } while (Departament.Length < 3);

            do
            {
                Console.Write("Salariu: ");
                Salary = int.Parse(Console.ReadLine());
            } while (2000 > Salary);

            return this;
        }

    }
}
