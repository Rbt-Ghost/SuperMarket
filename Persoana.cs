using System;
using System.IO;

namespace SuperMarket
{
    class Persoana
    {
        private string name;
        private int age;
        private int id;

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Numele trebuie sa aiba cel putin 3 caractere.");
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 16 || value > 120)
                    throw new ArgumentOutOfRangeException("Varsta trebuie sa fie intre 16 si 120.");
                age = value;
            }
        }

        public int ID
        {
            get => id;
            set
            {
                if (value < 100000 || value > 999999)
                    throw new ArgumentOutOfRangeException("ID-ul trebuie sa fie format din 6 cifre.");
                id = value;
            }
        }

        public Persoana() { }

        public Persoana(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string DisplayInfo()
        {
            return $"Name: {Name}, Varsta: {Age}, ID: {ID}";
        }

        public bool CautarePers(string SrcName)
        {
            return SrcName == Name;
        }

        public static Persoana CitireFisier(string file)
        {
            Persoana pers = null;

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = sr.ReadLine();

                    if (line != null)
                    {
                        string[] data = line.Split(',');

                        if (data.Length == 3)
                        {
                            string name = data[0];
                            int age = int.Parse(data[1]);
                            int id = int.Parse(data[2]);

                            pers = new Persoana(name, age, id);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Fisierul {file} nu a fost gasit!");
            }
            return pers;
        }

        public void InsertPers()
        {
            while (true)
            {
                try
                {
                    Console.Write("Nume: ");
                    Name = Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare: {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Varsta: ");
                    Age = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare: {ex.Message}");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("ID: ");
                    ID = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare: {ex.Message}");
                }
            }
        }

        public override string ToString()
        {
            return $"{Name},{Age},{ID}";
        }
    }
}
