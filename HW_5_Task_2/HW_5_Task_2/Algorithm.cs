using System;
using System.Collections.Generic;
using System.Text;

namespace HW_5_Task_2
{
    class Algorithm
    {
		private static int MinKey(int[] key, bool[] set, int verticesCount)
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

		private static int[,] CreateGraph(int[] parent, int[,] graph, int verticesCount)
		{
			var result = new int[graph.GetUpperBound(0) + 1, graph.GetUpperBound(0) + 1];
			for (int i = 1; i < verticesCount; ++i)
            {
				result[parent[i], i] = graph[parent[i], i];
				result[i, parent[i]] = graph[parent[i], i];
			}
			return result;
		}

		public static int[,] Prim(int[,] graph) // тут мы ищем мин - нужно макс
		{
			int verticesCount = graph.GetUpperBound(0) + 1;
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

			return CreateGraph(parent, graph, verticesCount);
		}
	}
}
