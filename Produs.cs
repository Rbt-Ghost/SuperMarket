using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Produs : Raion
    {
        private string Name;
        private double Price;
        private int Quantity;
        public Produs(int NrRaion, string Type, string Name, double Price, int Quantity)
            : base(NrRaion, Type)
        {
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public double price
        {
            get { return Price; }
            set { Price = value; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public void DisplayProdusInfo()
        {
            DisplayRaionInfo();
            Console.WriteLine($" Name: {Name}, Price: {Price}, Quantity: {Quantity}");
        }
    }
}
