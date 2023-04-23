using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Project4
{
    /*
	 * Source Code
	 * https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
	 */

    class BreadthFirstTraverse
    {
        private int _V;

        LinkedList<int>[] _adj;

        public BreadthFirstTraverse(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        //grapha kenar ekleme metodu
        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

        }

        // verilen s kaynağından dolaşımı printler 
        public void BFS(int s)
        {

            // ziyaret edilmeyen köşeleri işaretler 
            bool[] visited = new bool[_V];
            for (int i = 0; i < _V; i++)
                visited[i] = false;

            LinkedList<int> queue = new LinkedList<int>();

            // düğümü gezilmiş işaretle ve kuyruktan çıkar 
            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {

                // Kuyruktan çıkar ve yazdır
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                // komşu gezilmediyse gez işaretele ve kuyruktan çıkar.
                LinkedList<int> list = _adj[s];

                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }

    }
}
