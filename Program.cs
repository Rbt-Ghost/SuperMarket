using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket
{
    class Program // Tema #1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************");

            Manager[] manager; // Tema #2 citirea datelor din fisier; salvarea datelor într-un vector de obiecte; afișarea datelor dintr-un vector de obiecte;
            Casier[] casier;
            Client[] client;
            Raion[] raion;
            Produs[] produs;

            // Citirea managerilor
            Console.WriteLine();
            string fManager = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Manager.txt";
            if (File.Exists(fManager))
            {
                string[] managerData = File.ReadAllLines(fManager);
                manager = new Manager[managerData.Length];

                for (int i = 0; i < managerData.Length; i++)
                {
                    manager[i] = Manager.CitireFisierM(managerData[i]);  // Citim un singur Manager pe rând
                    if (manager[i] != null)
                    {
                        manager[i].DisplayManagerInfo();  // Afișăm informațiile managerului
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul nu a fost găsit!");
            }


            // Citirea casierilor
            Console.WriteLine();
            string fCasier = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Casier.txt";
            if (File.Exists(fCasier))
            {
                string[] casierData = File.ReadAllLines(fCasier);
                casier = new Casier[casierData.Length];
                for (int i = 0; i < casierData.Length; i++)
                {
                    casier[i] = Casier.CitireFisierC(casierData[i]);  // Citim un singur Casier pe rând
                    if (casier[i] != null)
                    {
                        casier[i].DisplayCasierInfo();  // Afișăm informațiile casierului
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul Casier.txt nu a fost găsit!");
            }


            // Citirea clientilor
            Console.WriteLine();
            string fClient = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Client.txt";
            if (File.Exists(fClient))
            {
                string[] clientData = File.ReadAllLines(fClient);
                client = new Client[clientData.Length];
                for (int i = 0; i < clientData.Length; i++)
                {
                    client[i] = Client.CitireFisierC(clientData[i]);  // Citim un singur Client pe rând
                    if (client[i] != null)
                    {
                        client[i].DisplayClientInfo();  // Afișăm informațiile clientului
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul Client.txt nu a fost găsit!");
            }

            // Citirea raioanelor
            Console.WriteLine();
            string fRaion = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Raion.txt";
            if (File.Exists(fRaion))
            {
                string[] raionData = File.ReadAllLines(fRaion);
                raion = new Raion[raionData.Length];
                for (int i = 0; i < raionData.Length; i++)
                {
                    raion[i] = Raion.CitireFisierR(raionData[i]);  // Citim un singur Raion pe rând
                    if (raion[i] != null)
                    {
                        raion[i].DisplayRaionInfo();  // Afișăm informațiile raioanelor
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul Raion.txt nu a fost găsit!");
            }

            // Citirea produselor
            Console.WriteLine();
            string fProdus = "C:/Users/Robert/MyCode/Univ/PIU/PIU_Project_SuperMarket/SuperMarket/Produs.txt";
            if (File.Exists(fProdus))
            {
                string[] produsData = File.ReadAllLines(fProdus);
                produs = new Produs[produsData.Length];
                for (int i = 0; i < produsData.Length; i++)
                {
                    produs[i] = Produs.CitireFisierP(produsData[i]);  // Citim un singur Produs pe rând
                    if (produs[i] != null)
                    {
                        produs[i].DisplayProdusInfo();  // Afișăm informațiile produselor
                    }
                }
            }
            else
            {
                Console.WriteLine("Fișierul Produs.txt nu a fost găsit!");
            }

        }
    }
}
