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
    
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, ID: {ID}");
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
                Console.Write("Varsta: ");
                Age = int.Parse(Console.ReadLine());
            } while (0 > Age || Age > 150);

            do
            {
                Console.Write("ID: ");
                ID = int.Parse(Console.ReadLine());
            } while (Age < 99999 || Age > 999999);
        }
    }
}
