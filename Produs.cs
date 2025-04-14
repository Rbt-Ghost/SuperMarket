using System;

namespace SuperMarket
{
    class Produs : Raion // Tema #1
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Produs() { }

        public Produs(RaionType type, string name, double price, int quantity)
            : base(type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string DisplayProdusInfo()
        {
            return $"Raion Nr: {(int)Type}, Tip: {Type}, Nume Produs: {Name}, Pret: {Price}, Cantitate: {Quantity}";
        }

        public bool CautareProdus(string searchTerm)
        {
            return Name?.ToLower().Contains(searchTerm.ToLower()) ?? false;
        }

        public static Produs CitireFisierP(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 5 &&
                Enum.TryParse(data[1].Trim(), out RaionType type) &&
                double.TryParse(data[3].Trim(), out double price) &&
                int.TryParse(data[4].Trim(), out int quantity))
            {
                return new Produs(
                    type,
                    data[2].Trim(),
                    price,
                    quantity
                );
            }

            Console.WriteLine("Date invalide pentru Produs.");
            return null;
        }

        public void InsertProdus()
        {
            InsertRaion();

            do
            {
                Console.Write("Numele produsului: ");
                Name = Console.ReadLine();
                if (Name.Length < 3)
                    Console.WriteLine("Numele trebuie sa aiba cel putin 3 caractere.");
            } while (Name.Length < 3);

            while (true)
            {
                Console.Write("Pret/Bucata: ");
                if (double.TryParse(Console.ReadLine(), out double price) && price > 0)
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Pret invalid. Introduceti un numar pozitiv.");
            }

            while (true)
            {
                Console.Write("Cantitate: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    Quantity = quantity;
                    break;
                }
                Console.WriteLine("Cantitate invalida. Introduceti un numar pozitiv.");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()},{Name},{Price},{Quantity}";
        }
    }
}
