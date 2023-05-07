﻿namespace MaxFlowProblem
{
    internal class MaxFlow
    {
        // Finds "Augmenting path" and stores it
        // rGraph = "residual" Graph
        // Breadth First Search
        private static bool bfs(int[,] rGraph, int s, int t, ref int repeat, int[] parent)
        {
            int V = rGraph.GetLength(0); // Number of vertices in graph

            // Create a visited array and mark all vertices as not visited
            // Default value in C# is false
            bool[] visited = new bool[V];

            // Create a queue, enqueue source vertex and mark source vertex as visited
            Queue<int> notExplored = new Queue<int>();
            notExplored.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (notExplored.Count != 0)
            {
                repeat++;

                // Gets first item and deletes it
                int u = notExplored.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && rGraph[u, v] > 0)
                    {
                        parent[v] = u;

                        // If we reach the sink
                        if (v == t)
                        {
                            return true;
                        }

                        notExplored.Enqueue(v);
                        visited[v] = true;
                    }
                }
            }
            // If there is no "Augmenting paths"
            return false;
        }

        private static bool DfsFlowPath(int[,] rGraph, int s, int t, ref int repeat, int[] parent)
        {
            int V = rGraph.GetLength(0); // Number of vertices in graph

            // Create a visited array and mark all vertices as not visited
            // Default value in C# is false
            bool[] visited = new bool[V];

            // Create a stacl=k, push source vertex and mark source vertex as visited
            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            visited[s] = true;
            parent[s] = -1;

            while (stack.Count > 0)
            {
                repeat++;

                // Gets first item
                int u = stack.Pop();

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && rGraph[u, v] > 0)
                    {
                        parent[v] = u;

                        // If we reach the sink
                        if (v == t)
                        {
                            return true;
                        }

                        stack.Push(v);
                        visited[v] = true;
                    }
                }
            }
            // If there is no "Augmenting paths"
            return false;
        }

        // A DFS based function to find all reachable
        // vertices from s. The function marks visited[i]
        // as true if i is reachable from s. The initial
        // values in visited[] must be false. We can also
        // use BFS to find reachable vertices. We use this
        // to find minimum cut
        private static void DfsMinCut(int[,] rGraph, int s, bool[] visited)
        {
            visited[s] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[s, i] > 0 && !visited[i])
                {
                    DfsMinCut(rGraph, i, visited);
                }
            }
        }

        public int EdmondsKarp(int[,] graph, int t, int s = 0)
        {
            Console.WriteLine("\n--> Edmonds-Karp algorithm\n");

            int V = graph.GetLength(0); // Number of vertices in graph
            int u, v;

            // Create a residual graph with same capacities as in original graph
            int[,] rGraph = new int[V, V];
            Array.Copy(graph, rGraph, graph.Length);

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            int repeat = 0; // Saves while count in BFS
            // Augment the flow while there is path from source to sink
            while (bfs(rGraph, s, t, ref repeat, parent))
            {
                Console.WriteLine("We found an 'Augmenting path', while count is: " + repeat);
                var path = new List<int>();   // To show the path

                // Finds edge with minimum capavity in 'parent' path
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path.Add(u);
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                path.Reverse();
                foreach (var item in path)
                {
                    Console.Write($"{item}->");
                }
                Console.WriteLine($"{t}");
                Console.WriteLine($"Minimum capacity in path is: {path_flow}");

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;

                Console.WriteLine($"Maximum reached flow: {max_flow}\n");
            }
            Console.WriteLine("While count: " + repeat);

            // Flow is maximum now, find vertices reachable from s    
            bool[] isVisited = new bool[graph.Length];
            DfsMinCut(rGraph, s, isVisited);

            Console.WriteLine("\nMinimum cut edges: ");

            // Prints all edges that are from a reachable vertex to
            // non-reachable vertex in the original graph    
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && isVisited[i] && !isVisited[j])
                    {
                        Console.WriteLine(i + " - " + j);
                    }
                }
            }
            // Return the overall flow
            return max_flow;
        }

        public int FordFulkerson(int[,] graph, int t, int s = 0)
        {
            Console.WriteLine("\n--> Ford-Fulkerson algorithm\n");

            int V = graph.GetLength(0); // Number of vertices in graph
            int u, v;

            // Create a residual graph with same capacities as in original graph
            int[,] rGraph = new int[V, V];
            Array.Copy(graph, rGraph, graph.Length);

            // This array is filled by DFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            int repeat = 0; // Saves while count in DFS
            // Augment the flow while there is path from source to sink
            while (DfsFlowPath(rGraph, s, t, ref repeat, parent))
            {
                Console.WriteLine("We found an 'Augmenting path', while count is: " + repeat);
                var path = new List<int>();   // To show the path

                // Finds edge with minimum capavity in 'parent' path
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path.Add(u);
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                path.Reverse();
                foreach (var item in path)
                {
                    Console.Write($"{item}->");
                }
                Console.WriteLine($"{t}");
                Console.WriteLine($"Minimum capacity in path is: {path_flow}");

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;

                Console.WriteLine($"Maximum reached flow: {max_flow}\n");
            }
            Console.WriteLine("While count: " + repeat);

            // Flow is maximum now, find vertices reachable from s    
            bool[] isVisited = new bool[V];
            DfsMinCut(rGraph, s, isVisited);

            Console.WriteLine("\nMinimum cut edges: ");

            // Prints all edges that are from a reachable vertex to
            // non-reachable vertex in the original graph    
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && isVisited[i] && !isVisited[j])
                    {
                        Console.WriteLine(i + " - " + j);
                    }
                }
            }
            // Return the overall flow
            return max_flow;
        }
    }
}
