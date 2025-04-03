using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperMarket // Tema #1
{
    class Persoana
    {
        public string Name { get; set; } // Tema #2 Adaugarea Auto-Properties
        public int Age { get; set; }
        public int ID { get; set; }
        public Persoana() { }

        public Persoana(string Name, int Age, int ID)
        {
            this.Name = Name;
            this.Age = Age;
            this.ID = ID;
        }

        //public void DisplayInfo()
        //{
        //  Console.WriteLine($"Name: {Name}, Age: {Age}, ID: {ID}");
        //}
        public string DisplayInfo()
        {
            return $"Name: {Name}, Varsta: {Age}, ID: {ID}";
        }


        public bool CautarePers(string SrcName) // Tema #2 Cautare dupa Nume
        {
            if (SrcName == Name)
                return true;
            else return false;
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

        public void InsertPers() // Tema #3
        {
            do
            {
                Console.Write("Nume: ");
                Name = Console.ReadLine();
            } while (Name.Length < 3);

            do
            {
                try
                {
                    Console.Write("Varsta: ");
                    Age = int.Parse(Console.ReadLine());

                    if (Age < 16 || Age > 120)
                    {
                        Console.WriteLine("Varsta invalida. Introduceti o varsta intre 0 si 150.");
                    }
                    else
                    {
                        break; // Exit the loop if the age is valid
                    }
                }
                catch
                {
                    Console.WriteLine("Input invalid. Introduceti un numar valid.");
                }
            } while (true);


            do
            {
                try
                {
                    Console.Write("ID: ");
                    ID = int.Parse(Console.ReadLine());

                    if (ID < 100000 || ID > 999999)
                    {
                        Console.WriteLine("ID invalid. Introduceti un ID format din 6 cifre.");
                    }
                    else
                    {
                        break; // Exit the loop if the ID is valid
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
            return $"{Name},{Age},{ID}";
        }
    }
}
