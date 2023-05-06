using MaxFlow;
using System.Text.RegularExpressions;

namespace MaxFlowProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxFlow maxFlowBy = new MaxFlow();

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
                              + maxFlowBy.EdmondsKarp(graph1, t: graph1.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph1, t: graph1.GetLength(0) - 1));

            Console.WriteLine("\n\n--> Example 2:");
            int[,] graph2 = new int[,] {
            { 0, 1000, 1000, 0 },
            { 0, 0, 1, 1000 },
            { 0, 0, 0, 1000 },
            { 0, 0, 0, 0 }
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph2, t: graph2.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph2, t: graph2.GetLength(0) - 1));

            Console.WriteLine("\n\n--> Example 3:");
            int[,] graph3 = new int[,]
            {
               // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12
                { 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //0   
                { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 }, //1
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 }, //2
                { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }, //3
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0 }, //4
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }, //5
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //6
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //7
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //8
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //9
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, //10
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, //11
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }  //12
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph3, t: graph3.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph3, t: graph3.GetLength(0) - 1));



            var maxBipartMatch = new BipartMatch();

            Console.WriteLine("\n\n--> Example of MaxBipartMatching 11:");
            // Bipartite graph
                             // 1, 2, 3, 4, 5, 6 
            int[,] graph11 = {{ 0, 1, 0, 0, 0, 1 }, //1
                              { 1, 0, 1, 0, 0, 0 }, //2
                              { 0, 1, 0, 1, 0, 0 }, //3
                              { 0, 0, 1, 0, 1, 0 }, //4
                              { 0, 0, 0, 1, 0, 1 }, //5
                              { 1, 0, 0, 0, 1, 0 }};//6

            Console.WriteLine("--> Maximum Bipartite Matching is: " +
                               maxBipartMatch.MaxBipartMatch(graph11));

            Console.WriteLine("\n\n--> Example of MaxBipartMatching 12:");
            // Non bipartite graph
                             // 1, 2, 3, 4, 5 
            int[,] graph12 = {{ 0, 1, 0, 0, 1 }, //1
                              { 1, 0, 1, 0, 0 }, //2
                              { 0, 1, 0, 1, 0 }, //3
                              { 0, 0, 1, 0, 1 }, //4
                              { 1, 0, 0, 1, 0 }};//5

            Console.WriteLine("--> Maximum Bipartite Matching is: " +
                               maxBipartMatch.MaxBipartMatch(graph12));

            Console.WriteLine("\nYou can write your matrix here: ");
            Console.Write("--> Insert number of vertices in graph: ");
            int V = Convert.ToInt32(Console.ReadLine());
            int[,] graph = new int[V, V];
            for (int i = 0; i < V - 1; i++)
            {
                for (int j = 1; j < V; j++)
                {
                    if (i != j)
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
                    Console.Write($"{graph[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph, t: graph.GetLength(0) - 1));

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph, t: graph.GetLength(0) - 1));
        }
    }

}