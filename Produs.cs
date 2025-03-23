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

        public Produs() { }
        public Produs(int NrRaion, RaionType type, string Name, double Price, int Quantity)
            : base(NrRaion, type)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public void DisplayProdusInfo()
        {
            DisplayRaionInfo();
            Console.WriteLine($" Name: {Name}, Pret/Bucata: {Price}, Cantitate stoc: {Quantity}");
        }
        public string CautareProdus(string SrcName)
        {
            if (SrcName == Name)
                return Type.ToString();
            else return null;
        }
        public static Produs CitireFisierP(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5 &&
                int.TryParse(data[0].Trim(), out int nrRaion) &&
                Enum.TryParse(data[1].Trim(), out RaionType type) &&
                double.TryParse(data[3].Trim(), out double price) &&
                int.TryParse(data[4].Trim(), out int quantity))
            {
                return new Produs(
                    nrRaion,           // ID
                    type,              // Categoria
                    data[2].Trim(),    // Nume
                    price,             // Pret
                    quantity           // Stoc
                );
            }
            else
            {
                Console.WriteLine("Invalid data format for Produs.");
                return null;
            }
        }

        public void InsertProdus() // Tema #3
        {
            InsertRaion();

            do
            {
                Console.Write("Numele produsului: ");
                Name = Console.ReadLine();
            } while (Name.Length < 3);

            do
            {
                Console.Write("Pret/Bucata: ");
                Price = int.Parse(Console.ReadLine());
            } while (0 > Price);

            do
            {
                Console.Write("Cantitate: ");
                Quantity = int.Parse(Console.ReadLine());
            } while (0 > Quantity);
        }
        public override string ToString() // Tema #4
        {
            return $"{base.ToString()},{Name},{Price},{Quantity}";
        }

    }
}
