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
        static Manager[] manager = new Manager[0];
        static Casier[] casier = new Casier[0];
        static Client[] client = new Client[0];
        static Raion[] raion = new Raion[0];
        static Produs[] produs = new Produs[0];

        static int ManagerCount = 0;
        static int CasierCount = 0;
        static int ProdusCount = 0;
        static int ClientCount = 0;
        static int RaionCount = 0;

        static string fManager = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Manager.txt";
        static string fCasier = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Casier.txt";
        static string fClient = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Client.txt";
        static string fRaion = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Raion.txt";
        static string fProdus = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Produs.txt";

        static void Main(string[] args)
        {
            LoadData();
            int choice;
            do // Tema #3 adaugare meniu, mai trebuie lucrat la inserts
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
            if (File.Exists(fManager))
            {
                string[] managerData = File.ReadAllLines(fManager);
                manager = new Manager[managerData.Length];
                for (int i = 0; i < managerData.Length; i++)
                {
                    ManagerCount++;
                    manager[i] = Manager.CitireFisierM(managerData[i]);
                }
            }

            if (File.Exists(fCasier))
            {
                string[] casierData = File.ReadAllLines(fCasier);
                casier = new Casier[casierData.Length];
                for (int i = 0; i < casierData.Length; i++)
                {
                    CasierCount++;
                    casier[i] = Casier.CitireFisierC(casierData[i]);
                }
            }

            if (File.Exists(fClient))
            {
                string[] clientData = File.ReadAllLines(fClient);
                client = new Client[clientData.Length];
                for (int i = 0; i < clientData.Length; i++)
                {
                    ClientCount++;
                    client[i] = Client.CitireFisierC(clientData[i]);
                }
            }

            if (File.Exists(fRaion))
            {
                string[] raionData = File.ReadAllLines(fRaion);
                raion = new Raion[raionData.Length];
                for (int i = 0; i < raionData.Length; i++)
                {
                    RaionCount++;
                    raion[i] = Raion.CitireFisierR(raionData[i]);
                }
            }

            if (File.Exists(fProdus))
            {
                string[] produsData = File.ReadAllLines(fProdus);
                produs = new Produs[produsData.Length];
                ProdusCount = produsData.Length;
                for (int i = 0; i < ProdusCount; i++)
                {
                    produs[i] = Produs.CitireFisierP(produsData[i]);
                }
            }
            Console.WriteLine("Data loaded successfully.");
        }

        static void DisplayData()
        {
            Console.WriteLine("\n--- Manageri ---");
            foreach (var m in manager) m?.DisplayManagerInfo();

            Console.WriteLine("\n--- Casieri ---");
            foreach (var c in casier) c?.DisplayCasierInfo();

            Console.WriteLine("\n--- Clienti ---");
            foreach (var cl in client) cl?.DisplayClientInfo();

            Console.WriteLine("\n--- Raioane ---");
            foreach (var r in raion) r?.DisplayRaionInfo();

            Console.WriteLine("\n--- Produse ---");
            foreach (var p in produs) p?.DisplayProdusInfo();
        }

        static void InsertData()
        {
            Console.WriteLine("\nInsert Data:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Cashier");
            Console.WriteLine("3. Client");
            Console.WriteLine("4. Department");
            Console.WriteLine("5. Product");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Manager newManager = new Manager();
                    newManager.InsertManager();
                    File.AppendAllText(fManager, newManager.ToString() + Environment.NewLine);
                    break;
                case 2:
                    Casier newCasier = new Casier();
                    newCasier.InsertCasier();
                    File.AppendAllText(fCasier, newCasier.ToString() + Environment.NewLine);
                    break;
                case 3:
                    Client newClient = new Client();
                    newClient.InsertClient();
                    File.AppendAllText(fClient, newClient.ToString() + Environment.NewLine);
                    break;
                case 4:
                    Raion newRaion = new Raion();
                    newRaion.InsertRaion();
                    File.AppendAllText(fRaion, newRaion.ToString() + Environment.NewLine);
                    break;
                case 5:
                    Produs newProdus = new Produs();
                    ProdusCount++;
                    newProdus.InsertProdus();
                    File.AppendAllText(fProdus, newProdus.ToString() + Environment.NewLine);
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
            LoadData(); // Reload after insert
        }

        static void SearchData()
        {
            Console.WriteLine("\nSearch Data:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Cashier");
            Console.WriteLine("3. Client");
            Console.WriteLine("4. Department");
            Console.WriteLine("5. Product");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Search Term: ");
            string search = Console.ReadLine();

            switch (choice)
            {
                case 1:
                    foreach (var m in manager)
                        if (m != null && m.CautareManager(search)) m.DisplayManagerInfo();
                    break;
                case 2:
                    foreach (var c in casier)
                        if (c != null && c.CautareCasier(search)) c.DisplayCasierInfo();
                    break;
                case 3:
                    foreach (var cl in client)
                        if (cl != null && cl.CautareClient(search)) cl.DisplayClientInfo();
                    break;
                case 4:
                    foreach (var r in raion)
                        if (r != null && r.CautareRaion(search) != 0) r.DisplayRaionInfo();
                    break;
                case 5:
                    foreach (var p in produs)
                        if (p != null && p.CautareProdus(search) != null) p.DisplayProdusInfo();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}