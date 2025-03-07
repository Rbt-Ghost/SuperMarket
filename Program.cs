using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HElloo");

            Persoana p = new Persoana("Ion Ionescu", 25, 129054);

            Manager m = new Manager("Gheorghe Popescu", 35, 129055, "HR", 5000);

            Casier c = new Casier("Maria Pop", 20, 129056, 1, 2000);

            Client cl = new Client("Ana Maria", 30, 129057, "Lapte, oua, paine", 100);

            Raion r = new Raion(1, "Fructe");

            Produs pr = new Produs(1, "Fructe", "Mere", 2, 5);

            p.DisplayInfo();
            m.DisplayManagerInfo();
            c.DisplayCasierInfo();
            cl.DisplayClientInfo();
            r.DisplayRaionInfo();
            pr.DisplayProdusInfo();
        }
    }
}
