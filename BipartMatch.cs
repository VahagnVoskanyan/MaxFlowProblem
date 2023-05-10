namespace MaxFlowProblem
{
    internal class BipartMatch
    {
        // This function returns true if graph is Bipartite
        private bool IsBipartite(int[,] graph, int[] colorArr, int s = 0)
        {
            int V = graph.GetLength(0);

            // Assign first color to source
            colorArr[s] = 1;

            // Create a queue (FIFO)
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);

            // Run while there are vertices in queue
            while (queue.Count != 0)
            {
                // Gets first item and deletes it
                int u = queue.Dequeue();

                // Return false if there is a self-loop
                if (graph[u, u] == 1)
                    return false;

                // Find all non-colored adjacent vertices
                for (int v = 0; v < V; ++v)
                {
                    // An edge from u to v exists and destination v is not colored
                    if (graph[u, v] == 1 && colorArr[v] == -1)
                    {
                        // Assign alternate color to this adjacent v of u
                        colorArr[v] = 1 - colorArr[u];
                        queue.Enqueue(v);
                    }

                    // An edge from u to v exists and destination v
                    // is colored with same color as u
                    else if (graph[u, v] == 1 && colorArr[v] == colorArr[u])
                        return false;
                }
            }
            // All adjacent vertices are colored with alternate color
            return true;
        }

        private int[,] GraphFF(int[,] bpgraph)
        {
            int bp_V = bpgraph.GetLength(0);

            // To serparate graph vertices into 2 groups
            int[] colorArr = new int[bp_V];
            for (int i = 0; i < bp_V; ++i)
                colorArr[i] = -1;

            // Cheks if the graph is bipartite
            if (IsBipartite(bpgraph, colorArr))
            {
                // Creating new matrix (for FF algorithm) 
                int new_V = bp_V + 2;
                var newGraph = new int[new_V, new_V];

                int s = 0;
                int t = new_V - 1;

                // Creates edges from s to vertexes
                // bp_V == colorArr.Length
                for (int i = 0; i < bp_V; i++)
                {
                    // If vertex color is 1 we
                    // connect it with source
                    if (colorArr[i] == 1)
                    {
                        newGraph[s, i + 1] = 1;
                    }
                    // If vertex color is 0 we
                    // connect it with sink
                    else
                    {
                        newGraph[i + 1, t] = 1;
                    }
                }

                // Creates edges from bipartite graph
                for (int i = 0; i < bp_V; i++)
                {
                    for (int j = 0; j < bp_V; j++)
                    {
                        if (bpgraph[i, j] > 0)
                        {
                            newGraph[i + 1, j + 1] = 1;
                        }
                    }
                }
                return newGraph;
            }
            //If isn't bipartite
            return new int[0, 0];
        }

        // Finds "Augmenting path" and stores it
        // rGraph = "residual" Graph
        // Breadth First Search
        private bool AugPathExists(int[,] rGraph, int[] parent)
        {
            int V = rGraph.GetLength(0); // Number of vertices in graph
            int s = 0;
            int t = V - 1;

            // Create a visited array and mark all vertices as not visited
            // Default value in C# is false
            bool[] visited = new bool[V];

            // Create a stack, push source vertex and mark source vertex as visited
            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard DFS Loop
            while (stack.Count != 0)
            {
                // Gets first item and deletes it
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

        public int MaxBipartMatch(int[,] graph)
        {
            var newGraph = GraphFF(graph);

            // If isn't bipartite
            if (newGraph.Length == 0)
            {
                Console.WriteLine("\n--> The given graph is not bipartite");
                return 0;
            }
            int V = newGraph.GetLength(0);   // Number of vertices in graph
            int s = 0;         // source
            int t = V - 1;     // sink

            // Represents the new graph
            Console.WriteLine("\n--> Your new matrix with source and sink is: ");
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Console.Write($"{newGraph[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int u, v;

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            // Augment the flow while there is path from source to sink
            while (AugPathExists(newGraph, parent))
            {
                Console.WriteLine("We found an 'Augmenting path' ");
                var path = new List<int>();   // To show the path

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    newGraph[u, v]--;
                    //newGraph[v, u]++; // It's not uses.. Yes??
                }

                // Add path flow to overall flow
                max_flow++;

                Console.WriteLine($"Maximum reached flow is: {max_flow}\n");
            }
            // Return the overall flow
            return max_flow;
        }
    }
}
