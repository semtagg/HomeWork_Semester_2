namespace HW_5_Task_2
{
    /// <summary>
    /// A class containing changed Prim's algorithm.
    /// /// </summary>
    public static class Algorithm
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
                if (!set[i] && key[i] > max)
                {
                    max = key[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private static bool CheckGraph(int[,] graph)
        {
            var size = graph.GetUpperBound(0) + 1;
            var vertices = new int[size];
            var connectivityFlag = false;
            int index = 0;
            vertices[0] = 1;
            while (!connectivityFlag)
            {
                connectivityFlag = true;
                for (int i = 0; i < size; i++)
                {
                    if (vertices[i] == 1)
                    {
                        vertices[i] = 2;
                        index = i;
                        break;
                    }
                }
                for (int j = 0; j < size; j++)
                {
                    if (graph[index, j] != int.MinValue && vertices[j] == 0)
                    {
                        vertices[j] = 1;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    if (vertices[k] == 1)
                    {
                        connectivityFlag = false;
                    }
                }
            }
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                if (vertices[i] == 0)
                {
                    result++;
                }
            }
            return result == 0;
        }

        private static int[,] InitGraph(int size)
        {
            var graph = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = int.MinValue;
                }
            }
            return graph;
        }

        private static int[,] CreateGraph(int[] parent, int[,] graph)
        {
            var verticesCount = graph.GetUpperBound(0) + 1;
            var result = InitGraph(verticesCount);
            for (int i = 1; i < verticesCount; ++i)
            {
                result[parent[i], i] = graph[parent[i], i];
                result[i, parent[i]] = graph[parent[i], i];
            }
            return result;
        }

        /// <summary>
        /// Changed Prim's algorithm.
        /// </summary>
        /// <param name="graph">Connected graph.</param>
        /// <returns>The graph that results from Prim's algorithm.</returns>
        public static int[,] ChangedPrim(int[,] graph)
        {
            if (!CheckGraph(graph))
            {
                throw new GraphIsNotConnectedException();
            }
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
