using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Produs : Raion // Tema 1
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Produs(int NrRaion, string Type, string Name, double Price, int Quantity)
            : base(NrRaion, Type)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public void DisplayProdusInfo()
        {
            DisplayRaionInfo();
            Console.WriteLine($" Name: {Name}, Price: {Price}, Quantity: {Quantity}");
        }
        public string CautareProdus(string SrcName)
        {
            if (SrcName == Name)
                return Type;
            else return null;
        }
        public static Produs CitireFisierP(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5)
            {
                return new Produs(
                    int.Parse(data[0].Trim()),          // ID
                    data[1].Trim(),                     // Categoria
                    data[2].Trim(),                     // Nume
                    double.Parse(data[3].Trim()),        // Pret
                    int.Parse(data[4].Trim())            // Stoc
                );
            }
            else
            {
                Console.WriteLine("Invalid data format for Produs.");
                return null;
            }
        }

    }
}
