using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Casier : Persoana
    {
        private int nrCasa;
        private double Salary;
        public Casier(string Name, int Age, int ID, int nrCasa, double Salary)
            : base(Name, Age, ID)
        {
            this.nrCasa = nrCasa;
            this.Salary = Salary;
        }
        public int nrCasa1
        {
            get { return nrCasa; }
            set { nrCasa = value; }
        }
        public double salary
        {
            get { return Salary; }
            set { Salary = value; }
        }
        public void DisplayCasierInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Casa: {nrCasa}, Salary: {Salary}");
        }
    }
}
