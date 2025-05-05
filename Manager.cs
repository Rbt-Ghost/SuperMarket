using System;

namespace SuperMarket
{
    public enum DepartamentType
    {
        HR = 1,
        Marketing,
        IT,
        Fructe,
        Carne,
        Lactate,
        Panificatie,
        Bauturi,
        Textile,
        Jucarii
    }

    class Manager : Persoana
    {
        private DepartamentType departament;
        private double salary;

        public DepartamentType Departament
        {
            get => departament;
            set
            {
                if (!Enum.IsDefined(typeof(DepartamentType), value))
                    throw new ArgumentException("Departament invalid.");
                departament = value;
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

        public Manager() { }

        public Manager(string name, int age, int id, DepartamentType departament, double salary)
            : base(name, age, id)
        {
            Departament = departament;
            Salary = salary;
        }

        public string DisplayManagerInfo()
        {
            return DisplayInfo() + $" Departament: {Departament}, Salariu: {Salary}";
        }

        public bool CautareManager(string SrcName)
        {
            return CautarePers(SrcName);
        }

        public static Manager CitireFisierM(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5)
            {
                try
                {
                    return new Manager(
                        data[0].Trim(),
                        int.Parse(data[1].Trim()),
                        int.Parse(data[2].Trim()),
                        (DepartamentType)Enum.Parse(typeof(DepartamentType), data[3].Trim()),
                        double.Parse(data[4].Trim())
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare la parsare: " + ex.Message);
                    return null;
                }
            }
            else
            {
                //Console.WriteLine("Format invalid al datelor.");
                return null;
            }
        }

        public Manager InsertManager()
        {
            InsertPers();

            while (true)
            {
                try
                {
                    Console.WriteLine("Departament: ");
                    foreach (var type in Enum.GetValues(typeof(DepartamentType)))
                    {
                        Console.WriteLine($"{(int)type}. {type}");
                    }

                    Console.Write("Alege departamentul (numar): ");
                    int input = int.Parse(Console.ReadLine());

                    Departament = (DepartamentType)input;
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

            return this;
        }

        public override string ToString()
        {
            return $"{base.ToString()},{Departament},{Salary}";
        }
    }
}
