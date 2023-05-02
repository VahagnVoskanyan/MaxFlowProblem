namespace MaxFlowProblem
{
    public class MaxFlow
    {
        // Finds "Augmenting path" and stores it
        // rGraph = "residual" Graph
        // Breadth First Search
        private static bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            int V = rGraph.GetLength(0); // Number of vertices in graph

            // Create a visited array and mark all vertices as not visited
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;

            // Create a queue, enqueue source vertex and mark source vertex as visited
            List<int> notExplored = new List<int>();
            notExplored.Add(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (notExplored.Count != 0)
            {
                //Console.WriteLine("-->While loop ");

                int u = notExplored[0];
                notExplored.RemoveAt(0);

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false && rGraph[u, v] > 0)
                    {
                        parent[v] = u;

                        // If we reach the sink
                        if (v == t)
                        {
                            return true;
                        }

                        notExplored.Add(v);
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
        private static void dfs(int[,] rGraph, int s, bool[] visited)
        {
            visited[s] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[s, i] > 0 && !visited[i])
                {
                    dfs(rGraph, i, visited);
                }
            }
        }

        public int EdmondsKarp(int[,] graph, int t, int s = 0)
        {
            int V = graph.GetLength(0); // Number of vertices in graph
            int u, v;

            // Create a residual graph with same capacities as in original graph
            int[,] rGraph = new int[V, V];

            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            // Augment the flow while there is path from source to sink
            while (bfs(rGraph, s, t, parent))
            {
                Console.WriteLine("We found an 'Augmenting path' ");
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

            // Flow is maximum now, find vertices reachable from s    
            bool[] isVisited = new bool[graph.Length];
            dfs(rGraph, s, isVisited);

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
