namespace MaxFlowProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxFlow m = new MaxFlow();

            Console.WriteLine("--> Example 1:");
            int[,] graph1 = new int[,] {
            { 0, 24, 16, 0, 0, 0 },
            { 0, 0, 12, 15, 0, 0 },
            { 0, 0, 0, 0, 19, 0 },
            { 0, 0, 11, 0, 0, 19 },
            { 0, 0, 0, 8, 0, 5 },
            { 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + m.EdmondsKarp(graph1, t: graph1.GetLength(0) - 1));

            Console.WriteLine("\nThe maximum possible flow is: "
                              + m.FordFulkerson(graph1, t: graph1.GetLength(0) - 1));

            Console.WriteLine("\n\n--> Example 2:");
            int[,] graph2 = new int[,] {
            { 0, 1000, 1000, 0 },
            { 0, 0, 1, 1000 },
            { 0, 0, 0, 1000 },
            { 0, 0, 0, 0 }
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + m.EdmondsKarp(graph2, t: graph2.GetLength(0) - 1));


            Console.WriteLine("\nYou can write your matrix here: ");
            Console.Write("--> Insert number of vertices in graph: ");
            int V = Convert.ToInt32(Console.ReadLine());
            int[,] graph = new int[V,V];
            for (int i = 0; i < V - 1; i++)
            {
                for (int j = 1; j < V; j++)
                {
                    if (i!=j)
                    {
                        Console.Write($"The capacity of edge {i}->{j} : ");
                        graph[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            Console.WriteLine("\n--> Your matrix is: ");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Console.Write($"{graph[i,j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThe maximum possible flow is: "
                              + m.EdmondsKarp(graph, t: graph.GetLength(0) - 1));

            Console.WriteLine("\nThe maximum possible flow is: "
                              + m.FordFulkerson(graph, t: graph.GetLength(0) - 1));
        }
    }

}