using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket 
{
    public enum DepartamentType // Tema #4
    {
        HR = 1,
        Marketing = 2,
        IT = 3,
        Fructe = 4,
        Carne = 5,
        Lactate = 6,
        Panificatie = 7,
        Bauturi = 8,
        Textile = 9,
        Jucarii = 10
    }
    class Manager : Persoana // Tema #1
    {
        public DepartamentType Departament {  get; set; } // Tema #2 Adaugarea Auto-Properties
        public double Salary { get; set; }

        public Manager() { }

        public Manager(string Name, int Age, int ID, DepartamentType Departament, double Salary)
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
                    data[0].Trim(),                                                         // Name
                    int.Parse(data[1].Trim()),                                              // Age
                    int.Parse(data[2].Trim()),                                              // ID
                    (DepartamentType)Enum.Parse(typeof(DepartamentType), data[3].Trim()),   // Departament
                    double.Parse(data[4].Trim())                                            // Salary
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

            Console.WriteLine("Departament ");
            foreach (var type in Enum.GetValues(typeof(DepartamentType)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            do
            {
                Console.Write("Choice: ");
                int departamentInput = int.Parse(Console.ReadLine());
                if (Enum.IsDefined(typeof(DepartamentType), departamentInput))
                {
                    Departament = (DepartamentType)departamentInput; // Convert to enum
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid department number. Please try again.");
                }
            } while (true);

            do
            {
                try
                {
                    Console.Write("Salariu: ");
                    Salary = int.Parse(Console.ReadLine());

                    if (Salary < 2000)
                    {
                        Console.WriteLine("Salariu invalid. Introduceti un salariu de cel putin 2000.");
                    }
                    else
                    {
                        break; // Exit the loop if the salary is valid
                    }
                }
                catch
                {
                    Console.WriteLine("Input invalid. Introduceti un numar valid.");
                }
            } while (true);


            return this;
        }

        public override string ToString() // Tema #4
        {
            return $"{base.ToString()},{Departament},{Salary}";
        }
    }
}
