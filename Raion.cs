using System;

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

    class Raion
    {
        private RaionType type;

        public RaionType Type
        {
            get => type;
            set
            {
                if (!Enum.IsDefined(typeof(RaionType), value))
                    throw new ArgumentException("Tipul de raion este invalid.");
                type = value;
            }
        }

        public Raion() { }

        public Raion(RaionType type)
        {
            Type = type;
        }

        public string DisplayRaionInfo()
        {
            return $"Raion Nr: {(int)Type}, Tip: {Type}";
        }

        public bool CautareRaion(string srcType)
        {
            return Type.ToString().ToLower().Contains(srcType.ToLower());
        }

        public static Raion CitireFisierR(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 2 && Enum.TryParse(data[1].Trim(), out RaionType parsedType))
            {
                try
                {
                    return new Raion(parsedType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eroare la crearea obiectului Raion: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Date invalide pentru Raion.");
            }
            return null;
        }

        public void InsertRaion()
        {
            Console.WriteLine("Selectati tipul Raionului:");
            foreach (var t in Enum.GetValues(typeof(RaionType)))
            {
                Console.WriteLine($"{(int)t}. {t}");
            }

            while (true)
            {
                Console.Write("Alegere: ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    Enum.IsDefined(typeof(RaionType), choice))
                {
                    Type = (RaionType)choice;
                    break;
                }
                else
                {
                    Console.WriteLine("Tip invalid. Incercati din nou.");
                }
            }
        }

        public override string ToString()
        {
            return $"{(int)Type},{Type}";
        }
    }
}
