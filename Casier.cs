﻿using System;
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

        public Casier() { }
        public Casier(string Name, int Age, int ID, int nrCasa, double Salary)
            : base(Name, Age, ID)
        {
            this.nrCasa = nrCasa;
            this.Salary = Salary;
        }
        //public void DisplayCasierInfo()
        //{
        //  DisplayInfo();
        //Console.WriteLine($" Casa: {nrCasa}, Salary: {Salary}");
        //}
        public string DisplayCasierInfo()
        {
            return DisplayInfo() + $", Casa: {nrCasa}, Salariu: {Salary}";
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

        public void InsertCasier() // Tema #3
        {
            InsertPers();

            do
            {
                Console.Write("NrCasa: ");
                nrCasa = int.Parse(Console.ReadLine());
            } while (0 > nrCasa);

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

        }

        public override string ToString() // Tema #4
        {
            return $"{base.ToString()},{nrCasa},{Salary}";
        }

    }
}
