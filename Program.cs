using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Program
    {
        static List<Manager> manager = new List<Manager>();
        static List<Casier> casier = new List<Casier>();
        static List<Client> client = new List<Client>();
        static List<Raion> raion = new List<Raion>();
        static List<Produs> produs = new List<Produs>();

        static string fManager = "Manager.txt"; //Am mutat fisierul txt in bin/debug ( nu mai trebuie sa includ tot path-ul )
        static string fCasier = "Casier.txt";
        static string fClient = "Client.txt";
        static string fRaion = "Raion.txt";
        static string fProdus = "Produs.txt";

        static void Main(string[] args)
        {
            LoadData();

            int choice;
            do  // Tema #3 adaugare meniu
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Read Files");
                Console.WriteLine("2. Display Data");
                Console.WriteLine("3. Insert Data");
                Console.WriteLine("4. Search Data");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        LoadData();
                        break;
                    case 2:
                        DisplayData();
                        break;
                    case 3:
                        InsertData();
                        break;
                    case 4:
                        SearchData();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 0);
        }

        static void LoadData()
        {
            manager.Clear();
            casier.Clear();
            client.Clear();
            raion.Clear();
            produs.Clear();

            if (File.Exists(fManager))
            {
                string[] managerData = File.ReadAllLines(fManager);
                foreach (string line in managerData)
                {
                    var m = Manager.CitireFisierM(line);
                    if (m != null) manager.Add(m);
                }
            }

            if (File.Exists(fCasier))
            {
                string[] casierData = File.ReadAllLines(fCasier);
                foreach (string line in casierData)
                {
                    var c = Casier.CitireFisierC(line);
                    if (c != null) casier.Add(c);
                }
            }

            if (File.Exists(fClient))
            {
                string[] clientData = File.ReadAllLines(fClient);
                foreach (string line in clientData)
                {
                    var cl = Client.CitireFisierC(line);
                    if (cl != null) client.Add(cl);
                }
            }

            if (File.Exists(fRaion))
            {
                string[] raionData = File.ReadAllLines(fRaion);
                foreach (string line in raionData)
                {
                    var r = Raion.CitireFisierR(line);
                    if (r != null) raion.Add(r);
                }
            }

            if (File.Exists(fProdus))
            {
                string[] produsData = File.ReadAllLines(fProdus);
                foreach (string line in produsData)
                {
                    var p = Produs.CitireFisierP(line);
                    if (p != null) produs.Add(p);
                }
            }

            Console.WriteLine("Data loaded successfully.");
        }

        static void DisplayData()
        {
            Console.WriteLine("\n--- Manageri ---");
            manager.ForEach(m => m.DisplayManagerInfo());

            Console.WriteLine("\n--- Casieri ---");
            casier.ForEach(c => c.DisplayCasierInfo());

            Console.WriteLine("\n--- Clienti ---");
            client.ForEach(cl => cl.DisplayClientInfo());

            Console.WriteLine("\n--- Raioane ---");
            raion.ForEach(r => r.DisplayRaionInfo());

            Console.WriteLine("\n--- Produse ---");
            produs.ForEach(p => p.DisplayProdusInfo());
        }

        static void InsertData()
        {
            Console.WriteLine("\nInsert Data:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Casier");
            Console.WriteLine("3. Client");
            Console.WriteLine("4. Raion");
            Console.WriteLine("5. Product");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Manager newManager = new Manager();
                    newManager.InsertManager();
                    manager.Add(newManager);
                    File.AppendAllText(fManager, newManager.ToString() + Environment.NewLine);
                    break;
                case 2:
                    Casier newCasier = new Casier();
                    newCasier.InsertCasier();
                    casier.Add(newCasier);
                    File.AppendAllText(fCasier, newCasier.ToString() + Environment.NewLine);
                    break;
                case 3:
                    Client newClient = new Client();
                    newClient.InsertClient();
                    client.Add(newClient);
                    File.AppendAllText(fClient, newClient.ToString() + Environment.NewLine);
                    break;
                case 4:
                    Raion newRaion = new Raion();
                    newRaion.InsertRaion();
                    raion.Add(newRaion);
                    File.AppendAllText(fRaion, newRaion.ToString() + Environment.NewLine);
                    break;
                case 5:
                    Produs newProdus = new Produs();
                    newProdus.InsertProdus();
                    produs.Add(newProdus);
                    File.AppendAllText(fProdus, newProdus.ToString() + Environment.NewLine);
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        static void SearchData()
        {
            Console.WriteLine("\nSearch Data:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Casier");
            Console.WriteLine("3. Client");
            Console.WriteLine("4. Raion");
            Console.WriteLine("5. Product");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Search Term: ");
            string search = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    manager.ForEach(m => {
                        if (m.CautareManager(search))
                            m.DisplayManagerInfo();
                    });
                    break;
                case 2:
                    casier.ForEach(c => { if (c.CautareCasier(search)) c.DisplayCasierInfo(); });
                    break;
                case 3:
                    client.ForEach(cl => { if (cl.CautareClient(search)) cl.DisplayClientInfo(); });
                    break;
                case 4:
                    if (Enum.TryParse(search, out RaionType searchType))
                    {
                        raion.ForEach(r => { if (r.Type == searchType) r.DisplayRaionInfo(); });
                    }
                    else
                    {
                        Console.WriteLine("Invalid Raion Type.");
                    }
                    break;
                case 5:
                    produs.ForEach(p => { if (p.CautareProdus(search) != null) p.DisplayProdusInfo(); });
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}