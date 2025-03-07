using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Client : Persoana  // nu ai nevoie de client.cs ( bon fiscal )
    {
        private string ListaCumparaturi;
        private int PunceiFidelitate;

        public Client(string Name, int Age, int ID, string ListaCumparaturi, int PuncteFidelitate)
            : base(Name, Age, ID)
        {
            this.ListaCumparaturi = ListaCumparaturi;
            this.PunceiFidelitate = PuncteFidelitate;
        }
        public string listaCumparaturi
        {
            get { return ListaCumparaturi; }
            set { ListaCumparaturi = value; }
        }
        public int puncteFidelitate
        {
            get { return PunceiFidelitate; }
            set { PunceiFidelitate = value; }
        }
        public void DisplayClientInfo()
        {
            DisplayInfo();
            Console.WriteLine($" Lista cumparaturi: {ListaCumparaturi}, Puncte fidelitate: {PunceiFidelitate}");
        }
    }
}
