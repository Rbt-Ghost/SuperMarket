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
        public int PunceiFidelitate { get; set; }

        public Client(string Name, int Age, int ID, string ListaCumparaturi, double PretTotal, int PuncteFidelitate)
            : base(Name, Age, ID)
        {
            this.ListaCumparaturi = ListaCumparaturi;
            this.PretTotal = PretTotal;
            this.PunceiFidelitate = PuncteFidelitate;
        }
        public void DisplayClientInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Lista cumparaturi: {ListaCumparaturi}, De plata: {PretTotal}, Puncte fidelitate: {PunceiFidelitate}");
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

    }
}
