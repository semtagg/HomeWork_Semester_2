using System;

namespace HW_5_Task_2
{
    class Algorithm
    {
		private static (int[], bool[]) InitKeyAndSet(int verticesCount)
        {
			var key = new int[verticesCount];
			var set = new bool[verticesCount];
			for (int i = 0; i < verticesCount; i++)
			{
				key[i] = int.MinValue;
				set[i] = false;
			}
			return (key, set);
		}

		private static int MaxKey(int[] key, bool[] set, int verticesCount)
		{
			var max = int.MinValue;
			int maxIndex = 0;
			for (int i = 0; i < verticesCount; ++i)
			{
				if (set[i] == false && key[i] > max)
				{
					max = key[i];
					maxIndex = i;
				}
			}
			return maxIndex;
		}

		private static int[,] CreateGraph(int[] parent, int[,] graph)
		{
			var verticesCount = graph.GetUpperBound(0) + 1;
			var result = new int[verticesCount, verticesCount];
			for (int i = 1; i < verticesCount; ++i)
            {
				result[parent[i], i] = graph[parent[i], i];
				result[i, parent[i]] = graph[parent[i], i];
			}
			return result;
		}

		public static int[,] Prim(int[,] graph)
		{
			var verticesCount = graph.GetUpperBound(0) + 1;
			var parent = new int[verticesCount];
			(var key, var set) = InitKeyAndSet(verticesCount);
			key[0] = 0;
			parent[0] = -1;
			for (int i = 0; i < verticesCount - 1; i++)
			{
				var currentMaxKey = MaxKey(key, set, verticesCount);
				set[currentMaxKey] = true;
				for (int j = 0; j < verticesCount; ++j)
				{
					if (graph[currentMaxKey, j] != int.MinValue && set[j] == false && graph[currentMaxKey, j] > key[j])
					{
						parent[j] = currentMaxKey;
						key[j] = graph[currentMaxKey, j];
					}
				}
			}
			return CreateGraph(parent, graph);
		}
	}
}
