using System;
using System.Collections.Generic;
using System.Text;

namespace Project4
{
	/*
	 * Source Code
	 * https://www.programmingalgorithms.com/algorithm/prim's-algorithm/
	 */
	class PrimsMST
    {
		private int MinKey(int[] key, bool[] set, int verticesCount)
		{
			int min = int.MaxValue, minIndex = 0;

			for (int v = 0; v < verticesCount; ++v)
			{
				if (set[v] == false && key[v] < min)
				{
					min = key[v];
					minIndex = v;
				}
			}

			return minIndex;
		}

		private void Print(int[] parent, int[,] graph, int verticesCount)
		{
			Console.WriteLine("Kenar			Ağırlık\n");
			for (int i = 1; i < verticesCount; ++i)
				Console.WriteLine("{0} - {1}		{2}", Program.CityList[parent[i]], Program.CityList[i], graph[i, parent[i]]);
		}

		public void Prim(int[,] graph, int verticesCount)
		{
			int[] parent = new int[verticesCount];
			int[] key = new int[verticesCount];
			bool[] mstSet = new bool[verticesCount];

			for (int i = 0; i < verticesCount; ++i)
			{
				key[i] = int.MaxValue;
				mstSet[i] = false;
			}

			key[0] = 0;
			parent[0] = -1;

			for (int count = 0; count < verticesCount - 1; ++count)
			{
				int u = MinKey(key, mstSet, verticesCount);
				mstSet[u] = true;

				for (int v = 0; v < verticesCount; ++v)
				{
					if (Convert.ToBoolean(graph[u, v]) && mstSet[v] == false && graph[u, v] < key[v])
					{
						parent[v] = u;
						key[v] = graph[u, v];
					}
				}
			}

			Print(parent, graph, verticesCount);
		}
	}
}
