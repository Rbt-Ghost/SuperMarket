using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SuperMarket
{
    public enum RaionType // Tema #4
    {
        Fructe = 1,
        Carne = 2,
        Lactate = 3,
        Panificatie = 4,
        Bauturi = 5,
        Textile = 6,
        Jucarii = 7
    }

    class Raion // Tema #1
    {
        public RaionType Type { get; set; } // Tema #2 Adaugarea Auto-Properties

        public Raion() { }

        public Raion(int nr, RaionType type)
        {
            this.Type = type;
        }

        public void DisplayRaionInfo()
        {
            Console.WriteLine($"Raion: {(int)Type}, Tip: {Type}");
        }

        public int CautareRaion(string srcType) // Tema #2 Cautare dupa tipul Raionului (legume, textile, jucarii...)
        {
            if (Enum.TryParse(srcType, true, out RaionType type) && type == Type)
                return (int)Type;
            else
                return 0;
        }

        public static Raion CitireFisierR(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 2 && int.TryParse(data[0], out int nr))
            {
                if (Enum.TryParse(data[1].Trim(), out RaionType type))
                {
                    return new Raion(nr, type);
                }
                else
                {
                    Console.WriteLine($"Invalid Raion Type: {data[1].Trim()}");
                }
            }
            else
            {
                Console.WriteLine("Invalid data format for Raion.");
            }
            return null;
        }

        public void InsertRaion()
        {
            Console.WriteLine("Select Raion Type:");
            foreach (var type in Enum.GetValues(typeof(RaionType)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            int choice;
            do
            {
                Console.Write("Choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(RaionType), choice));

            Type = (RaionType)choice;
        }

        public override string ToString() // Tema #4
        {
            return $"{(int)Type},{Type}";
        }
    }
}

