using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Client : Persoana // Tema #1
    {
        public string ListaCumparaturi {  get; set; } // Tema #2 Adaugarea Auto-Properties
        public double PretTotal { get; set; }
        public int PuncteFidelitate { get; set; }

        public Client() { }

        public Client(string Name, int Age, int ID, string ListaCumparaturi, double PretTotal, int PuncteFidelitate)
            : base(Name, Age, ID)
        {
            this.ListaCumparaturi = ListaCumparaturi;
            this.PretTotal = PretTotal;
            this.PuncteFidelitate = PuncteFidelitate;
        }
        public void DisplayClientInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Lista cumparaturi: {ListaCumparaturi}, De plata: {PretTotal}, Puncte fidelitate: {PuncteFidelitate}");
        }
        public bool CautareClient(string SrcName) // Tema #2 Cautare dupa Nume
        {
            return CautarePers(SrcName);
        }
        public static Client CitireFisierC(string line)
        {
            string[] data = line.Split(',');

            if (data.Length == 6)
            {
                return new Client(
                    data[0].Trim(),                        // Name
                    int.Parse(data[1].Trim()),              // Age
                    int.Parse(data[2].Trim()),              // ID
                    data[3].Trim(),                        // Comenzi
                    double.Parse(data[4].Trim()),           // Saldo
                    int.Parse(data[5].Trim())               // PuncteFidelitate
                );
            }
            else
            {
                Console.WriteLine("Invalid data format for Client.");
                return null;
            }
        }

        public void InsertClient() // #Tema3
        {
            InsertPers();

            do
            {
                Console.Write("Lista cumparaturi: ");
                ListaCumparaturi = Console.ReadLine();
            } while (ListaCumparaturi.Length < 3);

            do
            {
                Console.Write("PretTotal: ");
                PretTotal = int.Parse(Console.ReadLine());
            } while (-0.1 > PretTotal);

            do
            {
                Console.Write("PuncteFidelitate: ");
                PuncteFidelitate = int.Parse(Console.ReadLine());
            } while (-0.1 > PuncteFidelitate);
        }
        public override string ToString() // Tema #4
        {
            return $"{base.ToString()},{ListaCumparaturi},{PretTotal},{PuncteFidelitate}";
        }
    }
}
