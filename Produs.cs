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
        //public void DisplayProdusInfo()
        //{
        //  DisplayRaionInfo();
        //Console.WriteLine($" Name: {Name}, Pret/Bucata: {Price}, Cantitate stoc: {Quantity}");
        //}
        public string DisplayProdusInfo()
        {
            return $"Raion Nr: { (int)Type}, Tip: { Type}, NumeProd: {Name}, Pret: {Price}, Cantitate: {Quantity}";
        }

        public bool CautareProdus(string searchTerm)
        {
            return Name.ToLower().Contains(searchTerm.ToLower());
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

            // For Price
            do
            {
                try
                {
                    Console.Write("Pret/Bucata: ");
                    Price = int.Parse(Console.ReadLine());

                    if (Price <= 0)
                    {
                        Console.WriteLine("Pretul trebuie sa fie un numar pozitiv.");
                    }
                    else
                    {
                        break; // Exit the loop if the price is valid
                    }
                }
                catch
                {
                    Console.WriteLine("Input invalid. Introduceti un numar valid pentru pret.");
                }
            } while (true);

            // For Quantity
            do
            {
                try
                {
                    Console.Write("Cantitate: ");
                    Quantity = int.Parse(Console.ReadLine());

                    if (Quantity <= 0)
                    {
                        Console.WriteLine("Cantitatea trebuie sa fie un numar pozitiv.");
                    }
                    else
                    {
                        break; // Exit the loop if the quantity is valid
                    }
                }
                catch
                {
                    Console.WriteLine("Input invalid. Introduceti un numar valid pentru cantitate.");
                }
            } while (true);

        }
        public override string ToString() // Tema #4
        {
            return $"{base.ToString()},{Name},{Price},{Quantity}";
        }

    }
}
