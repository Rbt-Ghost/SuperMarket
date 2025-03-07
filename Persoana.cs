using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperMarket
{
    class Persoana
    {
        private string Name;
        private int Age;
        private int ID;

        public Persoana(string Name, int Age, int ID)
        {
            this.Name = Name;
            this.Age = Age;
            this.ID = ID;
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public int age
        {
            get { return Age; }
            set { Age = value; }
        }
        public int id
        {
            get { return ID; }
            set { ID = value; }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, ID: {ID}");
        }
    }
}
