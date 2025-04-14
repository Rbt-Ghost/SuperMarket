using System;

namespace SuperMarket
{
    class Casier : Persoana
    {
        private int nrCasa;
        private double salary;

        public int NrCasa
        {
            get => nrCasa;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Numarul casei nu poate fi negativ.");
                nrCasa = value;
            }
        }

        public double Salary
        {
            get => salary;
            set
            {
                if (value < 2000)
                    throw new ArgumentOutOfRangeException("Salariul trebuie sa fie cel putin 2000.");
                salary = value;
            }
        }

        public Casier() { }

        public Casier(string name, int age, int id, int nrCasa, double salary)
            : base(name, age, id)
        {
            NrCasa = nrCasa;
            Salary = salary;
        }

        public string DisplayCasierInfo()
        {
            return DisplayInfo() + $", Casa: {NrCasa}, Salariu: {Salary}";
        }

        public bool CautareCasier(string SrcName)
        {
            return CautarePers(SrcName);
        }

        public static Casier CitireFisierC(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5)
            {
                try
                {
                    return new Casier(
                        data[0].Trim(),                  // Name
                        int.Parse(data[1].Trim()),       // Age
                        int.Parse(data[2].Trim()),       // ID
                        int.Parse(data[3].Trim()),       // NrCasa
                        double.Parse(data[4].Trim())     // Salary
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare la citirea casierului: " + ex.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Format invalid al datelor pentru Casier.");
                return null;
            }
        }

        public void InsertCasier()
        {
            InsertPers();

            while (true)
            {
                try
                {
                    Console.Write("NrCasa: ");
                    NrCasa = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare: " + ex.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Salariu: ");
                    Salary = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare: " + ex.Message);
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()},{NrCasa},{Salary}";
        }
    }
}
