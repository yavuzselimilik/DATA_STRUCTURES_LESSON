using System;
using System.Collections.Generic;

namespace Project4
{
    class Program
    {
        public const int INF = 1000;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            AVLTree agac = new AVLTree();

            for (int i = 0; i < 10; i++)    
                agac.kok = agac.ekle(agac.kok, rnd.Next(100));

            Console.WriteLine("AVL tree inOrder gezilnmesi:\n");
            agac.inOrder(agac.kok);

            Console.WriteLine("\n\n*****************************************************************************");

            //Değerler graph uygulamasında çıktı almak için oluşturuldu. Gerçek kişi, kurum ve illerle alakası yoktur.
            int[,] graph = new int[,] 
            {
                //Ankara
                { INF, 4, INF, INF, INF, INF, INF, 8, INF },
                //İstanbul
                { 4, INF, 8, INF, INF, INF, INF, 11, INF },
                //İzmir
                { INF, 8, INF, 7, INF, 4, INF, INF, 2 },
                //Eskişehir
                { INF, INF, 7, INF, 9, 14, INF, INF, INF },
                //Kütahya
                { INF, INF, INF, 9, INF, 10, INF, INF, INF },
                //Denizli
                { INF, INF, 4, 14, 10, INF, 2, INF, INF },
                //Antalya
                { INF, INF, INF, INF, INF, 2, INF, 1, 6 },
                //Bursa
                { 8, 11, INF, INF, INF, INF, 1, INF, 7 },
                //Muğla
                { INF, INF, 2, INF, INF, INF, 6, 7, INF }
            };


            DSP dsp = new DSP(); //Dijkstra’s Shortest Path 

            int SRC = 0; //kaynak Ankara
            int DEST = 2; //hedef İzmir

            Console.WriteLine("\nKaynak düğüm: " + CityList[SRC] + "\n");

            int[] previous = dsp.Distance(graph, SRC);

            Console.WriteLine("\n" + CityList[SRC] + " - " + CityList[DEST] + " arası en kısa yol:");
            dsp.printShortestPath(DEST, previous);

            Console.WriteLine("\n\n*****************************************************************************\n");

            Console.WriteLine("Prim's algoritması çıktısı:\n");

            PrimsMST primsMST = new PrimsMST(); //Prim’s Minimum Spanning Tree 


            primsMST.Prim(graph, graph.GetLength(0));

            Console.WriteLine("\n\n*****************************************************************************\n");

            Console.WriteLine("Breadth-First Traverse:\n");

            BreadthFirstTraverse bft = new BreadthFirstTraverse(5); // Düğüm sayısını parametre olarak girdim.

            //Soru beşteki graph referans alındı.
            bft.AddEdge(0, 1);
            bft.AddEdge(0, 4);
            bft.AddEdge(0, 2);
            bft.AddEdge(1, 2);
            bft.AddEdge(1, 3);
            bft.AddEdge(2, 1);
            bft.AddEdge(2, 3);
            bft.AddEdge(4, 1);
            bft.AddEdge(4, 2);
            bft.AddEdge(4, 3);

            bft.BFS(0); // Gezinme 0. düğümden başlatıldı.

            Console.WriteLine("\n\n*****************************************************************************\n");

        }

        static public Dictionary<int, string> GetCityList()
        {
            Dictionary<int, string> cities = new Dictionary<int, string>();

            cities.Add(0, "Ankara");
            cities.Add(1, "İstanbul");
            cities.Add(2, "İzmir");
            cities.Add(3, "Eskişehir");
            cities.Add(4, "Kütahya");
            cities.Add(5, "Denizli");
            cities.Add(6, "Antalya");
            cities.Add(7, "Bursa");
            cities.Add(8, "Muğla");

            return cities;
        }

        static public Dictionary<int, string> CityList = GetCityList();
    }
}
