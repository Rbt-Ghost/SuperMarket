using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Raion
    {
        private int NrRaion;
        private string Type;
        public Raion(int Nr, string Name)
        {
            this.NrRaion = Nr;
            this.Type = Name;
        }
        public int nrRaion
        {
            get { return NrRaion; }
            set { NrRaion = value; }
        }
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public void DisplayRaionInfo()
        {
            Console.WriteLine($"Raion: {NrRaion}, Name: {Type}");
        }   
    }
}
