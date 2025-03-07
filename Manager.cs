using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Manager : Persoana
    {
        private string Departament;
        private double Salary;

        public Manager(string Name, int Age, int ID, string Departament, double Salary)
            : base(Name, Age, ID)
        {
            this.Departament = Departament;
            this.Salary = Salary;
        }
        public string departament
        {
            get { return Departament; }
            set { Departament = value; }
        }
        public double salary
        {
            get { return Salary; }
            set { Salary = value; }
        }
        public void DisplayManagerInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Departament: {Departament}, Salary: {Salary}");
        }
    }
}
