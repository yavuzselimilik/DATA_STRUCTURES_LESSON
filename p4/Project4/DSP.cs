using System;
using System.Collections.Generic;
using System.Text;

namespace Project4
{
    class DSP
    {
        public int[] Distance(int[,] cost, int src)
        {
            int N = cost.GetLength(0);
            int w, v, min;

            int[] D = new int[cost.GetLength(0)];

            bool[] visited = new bool[N];

            int[] previous = new int[N]; //for tracking shortest paths (güzergah)

            //initialization of D[], visited[] and previous[] arrays according to src node
            for (v = 0; v < N; v++)
            {
                if (v != src)
                {
                    visited[v] = false;
                    D[v] = cost[src, v];
                    if (D[v] != Program.INF) //there is a connection between src and v
                    {
                        previous[v] = src;
                    }
                    else //no path from source
                    {
                        previous[v] = -1;
                    }
                }
                else
                {
                    visited[v] = true;
                    D[v] = 0;
                    previous[v] = -1;
                }

            }

            // Searching for shortest paths
            for (int i = 0; i < N; ++i)
            {
                min = Program.INF;
                for (w = 0; w < N; w++)
                    if (!visited[w])
                        if (D[w] < min)
                        {
                            v = w;
                            min = D[w];
                        }

                visited[v] = true;

                for (w = 0; w < N; w++)
                    if (!visited[w])
                        if (min + cost[v, w] < D[w])
                        {
                            D[w] = min + cost[v, w];
                            previous[w] = v; //update the path info
                        }
            }
            
            printSolution(D);
            return previous;
        }

        public void printSolution(int[] dist)
        {
            Console.WriteLine("Düğüm      Kaynağa Olan Uzaklık\n");
            for (int i = 0; i < dist.Length; i++)
                Console.WriteLine(Program.CityList[i] + "            " + dist[i]);
        }
        public void printShortestPath(int dest, int[] previous)
        {
            Stack<int> pathStack = new Stack<int>();

            int current = dest;
            pathStack.Push(current);

            while (previous[current] != -1)
            {
                current = previous[current];
                pathStack.Push(current);
            }

            if (pathStack.Count == 1)
            {
                Console.Write(" NO PATH");
                return;
            }
            
            while (pathStack.Count > 0)
            {
                Console.Write("-> " + Program.CityList[pathStack.Pop()]);
            }
        }

    }
}
