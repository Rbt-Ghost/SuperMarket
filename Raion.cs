using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Raion // Tema #1
    {
        public int NrRaion {  get; set; } // Tema #2 Adaugarea Auto-Properties
        public string Type { get; set; }

        public Raion() { }
        public Raion(int Nr, string Name)
        {
            this.NrRaion = Nr;
            this.Type = Name;
        }
        public void DisplayRaionInfo()
        {
            Console.WriteLine($"Raion: {NrRaion}, Name: {Type}");
        }   
        public int CautareRaion(string SrcType) // Tema #2 Cautare dupa tipul Raionului (legume, textile, jucarii...)
        {
            if (SrcType == Type)
                return NrRaion;
            else return 0;
        }
        public static Raion CitireFisierR(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 2)
            {
                return new Raion(
                    int.Parse(data[0].Trim()),       // ID
                    data[1].Trim()                   // Nume
                );
            }
            else
            {
                Console.WriteLine("Invalid data format for Raion.");
                return null;
            }
        }

        public void InsertRaion()
        {
            do
            {
                Console.Write("NrRaion: ");
                NrRaion = int.Parse(Console.ReadLine());
            } while (0 > NrRaion);

            do
            {
                Console.Write("Tipul Raionului: ");
                Type = Console.ReadLine();
            } while (Type.Length < 3);
        }

    }
}
