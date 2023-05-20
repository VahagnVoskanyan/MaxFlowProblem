namespace MaxFlowProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaxFlow maxFlowBy = new MaxFlow();

            Console.WriteLine("--> Example 1:");
            int[,] graph1 = new int[,] {
            { 0, 10, 10, 0, 0, 0 },
            { 0, 0, 2, 4, 8, 0 },
            { 0, 0, 0, 0, 9, 0 },
            { 0, 0, 11, 0, 0, 10 },
            { 0, 0, 0, 6, 0, 10 },
            { 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph1, t: graph1.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph1, t: graph1.GetLength(0) - 1));

            /*Console.WriteLine("\n\n--> Example 2:");
            int[,] graph2 = new int[,] {
            { 0, 1000, 1000, 0 },
            { 0, 0, 1, 1000 },
            { 0, 0, 0, 1000 },
            { 0, 0, 0, 0 }
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph2, t: graph2.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph2, t: graph2.GetLength(0) - 1));*/

            /*Console.WriteLine("\n\n--> Example 3:");
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
                              + maxFlowBy.FordFulkerson(graph3, t: graph3.GetLength(0) - 1));*/

            /*Console.WriteLine("\n\n--> Example 4:");
            int[,] graph4 = new int[,]
            {
               // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11
                { 0, 15, 25, 35, 0, 0, 0, 0, 0, 0, 0, 0 }, //0   
                { 0, 0, 0, 7, 0, 8, 0, 0, 0, 0, 8, 8 }, //1
                { 0, 0, 0, 0, 8, 0, 0, 0, 7, 0, 7, 0 }, //2
                { 0, 0, 0, 0, 8, 0, 9, 0, 9, 0, 0, 7 }, //3
                { 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 8, 0 }, //4
                { 0, 0, 0, 3, 7, 0, 4, 0, 12, 15, 3, 1 }, //5
                { 0, 7, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 }, //6
                { 0, 0, 1, 0, 0, 7, 0, 0, 0, 3, 0, 10 }, //7
                { 0, 0, 0, 9, 0, 7, 0, 0, 3, 7, 0, 10 }, //8
                { 0, 0, 0, 0, 8, 0, 7, 0, 0, 0, 0, 20 }, //9
                { 0, 0, 10, 0, 0, 8, 0, 0, 7, 0, 0, 10 }, //10
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }  //11
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph4, t: graph4.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph4, t: graph4.GetLength(0) - 1));*/

            // An example when DFS stuck on loop
            /*Console.WriteLine("\n\n--> Example 5:");
            int[,] graph5 = new int[,]
            {
               // 0, 1,  2,  3,  4,  5,  6, 
                { 0, 10, 0,  0,  20, 0,  0  }, //0   
                { 0, 0,  10, 0,  0,  0,  0  }, //1
                { 0, 0,  0,  10, 0,  0,  0  }, //2
                { 0, 10, 0,  0,  0,  0,  0  }, //3
                { 0, 0,  0,  0,  0,  20, 0  }, //4
                { 0, 0,  0,  0,  0,  0,  20 }, //5
                { 0, 0,  0,  0,  0,  0,  0  }, //6
            };

            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.EdmondsKarp(graph5, t: graph5.GetLength(0) - 1));
            Console.WriteLine("\nThe maximum possible flow is: "
                              + maxFlowBy.FordFulkerson(graph5, t: graph5.GetLength(0) - 1));*/

            var maxBipartMatch = new BipartMatch();

            /*Console.WriteLine("\n\n--> Example of Maximum Bipartite Matching 11:");
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

            Console.WriteLine("\n\n--> Example of Maximum Bipartite Matching 12:");
            // Non bipartite graph
                             // 1, 2, 3, 4, 5 
            int[,] graph12 = {{ 0, 1, 0, 0, 1 }, //1
                              { 1, 0, 1, 0, 0 }, //2
                              { 0, 1, 0, 1, 0 }, //3
                              { 0, 0, 1, 0, 1 }, //4
                              { 1, 0, 0, 1, 0 }};//5

            Console.WriteLine("--> Maximum Bipartite Matching is: " +
                               maxBipartMatch.MaxBipartMatch(graph12));*/

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nInsert your network here: ");
            Console.Write("--> Insert number of vertices in network: ");
            int V = Convert.ToInt32(Console.ReadLine());
            int[,] graph = new int[V, V];
            for (int i = 0; i < V ; i++)
            {
                for (int j = 0; j < V; j++)
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

            int number = -1;
            while (number != 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFord-Fulkerson => 1");
                Console.WriteLine("Edmonds-karp => 2");
                Console.WriteLine("Maximum Bipartite Matching => 3");
                Console.WriteLine("If you want to exit the programm then write number 0");
                Console.Write("--> Write the number of function you want to use : ");
                number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("\nThe maximum possible flow is: "
                                  + maxFlowBy.FordFulkerson(graph, t: graph.GetLength(0) - 1));
                        break;
                    case 2:
                        Console.WriteLine("\nThe maximum possible flow is: "
                                  + maxFlowBy.EdmondsKarp(graph, t: graph.GetLength(0) - 1));
                        break;
                    case 3:
                        Console.WriteLine("--> Maximum Bipartite Matching is: " +
                                   maxBipartMatch.MaxBipartMatch(graph));
                        break;
                    default:
                        Console.WriteLine("--> Function with that number is not specified !!");
                        break;
                }
            }
        }
    }
}