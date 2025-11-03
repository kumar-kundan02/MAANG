### Graph

>- **Adjacency Matrix:** Space Complexity: O(V^2), Time Complexity for checking edge: O(1), for traversing all neighbors: O(V)
>- **Adjacency List:** Space Complexity: O(V + E), Time Complexity for checking edge: O(V) in worst case, for traversing all neighbors: O(degree of vertex)

#### Breadth First Search (BFS)
* Used for traversing or searching tree or graph data structures.
* Explores all neighbors at the present depth prior to moving on to nodes at the next depth
* It works for both **directed and undirected** graphs.
* It uses a **queue** data structure to keep track of nodes to visit next.
* It uses a **set or boolean array** to keep track of **visited nodes** to avoid processing the same node multiple times.

**Setup and Steps for BFS**

>- Initialize Visited Array/Set to Keep track Visited Nodes
>- Initialize Queue to store neighbours and Enqueue the Starting Node
>- Once node is inserted in Queue, mark it as Visited

**Time and Space Complexity**
* **Time Complexity:** O(V + E) where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity:** O(V) for the visited array and the queue in the worst case.

```CSharp
public class BFS
{
    public void Traverse(int startNode, List<List<int>> adj);o
    {
        int V = adj.Count;
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[startNode] = true;
        queue.Enqueue(startNode);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.WriteLine(node); // Process the node

            foreach (var neighbor in adj[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
```

#### DFS (Depth First Search)
* Used for traversing or searching tree or graph data structures.
* Explores as far as possible along each branch before backtracking.
* It works for both **directed and undirected** graphs.
* It uses a **stack** data structure (can be implemented using recursion) to keep track of nodes to visit next.
* It uses a **set or boolean array** to keep track of **visited nodes** to avoid processing the same node multiple times.

**Time and Space Complexity**
Where V is the number of vertices and E is the number of edges in the graph.

**Time Complexity: O(V + E)**
Summation of degree of nodes i.e 2xE and each Nodes need to be visited once then again O(V).
**Space Complexity: O(V)** 
O(V) : Visited + O(V) : Stack(skewed Graph) + O(V): All Nodes
O(V) for the visited array and the stack in the worst case.

**Setup and Steps for DFS**
>
>- Initialize Visited Array/Set to Keep track Visited Nodes
>- Initialize Stack to store neighbours and Push the Starting Node
>- Once node is inserted in Stack, mark it as Visited
>

```CSharp

// Iterative DFS using Stack
public class DFS
{
    public void Traverse(int startNode, List<List<int>> adj)
    {
        int V = adj.Count;
        bool[] visited = new bool[V];
        Stack<int> stack = new Stack<int>();

        stack.Push(startNode);
        visited[startNode] = true;

        while (stack.Count > 0)
        {
            int node = stack.Pop();
            Console.WriteLine(node); // Process the node

            foreach (var neighbor in adj[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    stack.Push(neighbor);
                }
            }
        }
    }
}

// Recursive DFS
public class DFSRecursive
{
    public void Traverse(int startNode, List<List<int>> adj)
    {
        int V = adj.Count;
        bool[] visited = new bool[V];
        DFSUtil(startNode, visited, adj);
    }

    private void DFSUtil(int node, bool[] visited, List<List<int>> adj)
    {
        visited[node] = true;
        Console.WriteLine(node); // Process the node

        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited, adj);
            }
        }
    }
}
```

#### Topological Sort
* Topological Sort is a linear ordering of vertices such that for every directed edge u -> v, vertex u comes before v in the ordering.
* It is applicable only to Directed Acyclic Graphs (DAGs).
* It is mainly used for scheduling tasks, resolving dependencies, and organizing data with precedence constraints.
* **Time Complexity: O(V + E)**, where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity: O(V)** for the visited array and the stack.

**Intuition:**
>- Use DFS to explore each vertex and its neighbors.
>- Once all neighbors of a vertex are visited, push the vertex onto a stack.

**Setup and Steps:**
>- Initialize a visited array to keep track of visited nodes.
>- Initialize a stack to store the topological order.
>- ***DFS(n) => Mark 'n' as visited => Keep going until DFS leaf then while bactracking push the Node in Stack***

```CSharp
public class TopologicalSortDFS
{
    public List<int> TopologicalSort(int V, List<List<int>> adj)
    {
        bool[] visited = new bool[V];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                DFS(i, visited, stack, adj);
            }
        }

        List<int> topoOrder = new List<int>();
        while (stack.Count > 0)
        {
            topoOrder.Add(stack.Pop());
        }
        return topoOrder;
    }

    private void DFS(int node, bool[] visited, Stack<int> stack, List<List<int>> adj)
    {
        visited[node] = true;

        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, visited, stack, adj);
            }
        }
        stack.Push(node);
    }
}
```

#### Kahn's Algorithm for Topological Sort(BFS)
* Kahn's Algorithm is another method to perform topological sorting of a Directed Acyclic
Graph (DAG) using BFS.
* **Time Complexity: O(V + E)**, where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity: O(V)** for the in-degree array and the queue.

**Intuition:**
>- Calculate the ***in-degree*** (number of incoming edges) for each vertex.
>- Start with all vertices that have an in-degree of 0 (no dependencies).
>- Use a queue to process these vertices, and for each vertex processed, reduce the in-degree
of its neighbors. If any neighbor's in-degree becomes 0, add it to the queue.
>- ***No Need of Visited Array as we are using inDegree to track processed nodes.***
>- ***Note:*** If ther is a cycle in the graph, Kahn's algorithm will not be able to process all vertices, indicating that a topological sort is not possible.
>- ***Reason:*** In a cycle, there will be no vertex with in-degree 0 to start the process as the Node Forming Cycle will be having inDegree > 0 
so, in this case no Node will be added to Queue but Queue will become empty as last node is processed and loop will terminate.

```CSharp
public class TopologicalSortKahn
{
    public List<int> TopologicalSort(int V, List<List<int>> adj)
    {
        int[] inDegree = new int[V];
        for (int i = 0; i < V; i++)
        {
            foreach (var neighbor in adj[i])
            {
                inDegree[neighbor]++;
            }
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < V; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        List<int> topoOrder = new List<int>();
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            topoOrder.Add(node);

            foreach (var neighbor in adj[node])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        if (topoOrder.Count != V)
        {
            throw new InvalidOperationException("Graph is not a DAG; topological sort not possible.");
        }

        return topoOrder;
    }
}
```

#### Dijkstra's Algorithm
* **Dijkstra's varriations:** [Problems](https://leetcode.com/discuss/post/7322154/10-dijkstra-variations-for-interview-pre-s8by/)
* Dijkstra's Algorithm is used to find the shortest path from a source vertex to all other  vertices in a weighted graph with ***non-negative edge weights***.
* It uses a priority queue to explore the vertex with the smallest known distance first.
* It updates the distances of neighboring vertices if a shorter path is found through the current vertex.
* It works for both directed and undirected graphs.
* It usage kind of similar but not exactly to BFS approach with priority queue to ensure the shortest path is found efficiently.
* **Time Complexity: O((V + E) log V)**, where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity: O(V)** for the distance array and the priority queue.

```CSharp 
// Dijkstra's Algorithm Implementation using Priority Queue but not SortedSet
// As SortedSet does not allow duplicate priorities which may lead to incorrect results in Dijkstra's Algorithm
public class DijkstraAlgorithm
{
    public int[] Dijkstra(int V, List<List<(int neighbor, int weight)>> adj, int source)
    {
        int[] distances = new int[V];
        for (int i = 0; i < V; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[source] = 0;

        var pq = new PriorityQueue<(int node, int distance), int>();
        pq.Enqueue((source, 0), 0);

        while (pq.Count > 0)
        {
            var (node, currentDistance) = pq.Dequeue();

            if (currentDistance > distances[node]) continue;

            foreach (var (neighbor, weight) in adj[node])
            {
                int newDist = distances[node] + weight;
                if (newDist < distances[neighbor])
                {
                    distances[neighbor] = newDist;
                    pq.Enqueue((neighbor, newDist), newDist);
                }
            }
        }

        return distances;
    }
}
```

#### Belmon-Ford Algorithm
* Bellman-Ford Algorithm is used to find the ***shortest path from a source vertex to all other vertices*** in a weighted graph, even if the graph contains edges with negative weights.
* It works by repeatedly relaxing all edges, ensuring that the shortest path to each vertex is found.
* It should be noted that Bellman-Ford is less efficient than Dijkstra's algorithm for graphs with non-negative weights.
* It runs for V-1 iterations, where V is the number of vertices in the graph, and in each iteration, it relaxes all edges.
* It can also detect negative weight cycles in the graph.
* **Time Complexity: O(V * E)**, where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity: O(V)** for the distance array.

```CSharp
public class BellmanFordAlgorithm
{
    public int[] BellmanFord(int V, List<(int u, int v, int weight)> edges, int source)
    {
        int[] distances = new int[V];
        for (int i = 0; i < V; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[source] = 0;

        for (int i = 1; i <= V - 1; i++)
        {
            // Relaxing edeges
            foreach (var (u, v, weight) in edges)
            {
                if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                }
            }
        }

        // Relax edge one more time to detect negative weight cycle
        foreach (var (u, v, weight) in edges)
        {
            if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
            {
                throw new InvalidOperationException("Graph contains a negative weight cycle.");
            }
        }

        return distances;
    }
}
```

#### Floyd-Warshall Algorithm
* ***Multi source shortest path*** algorithm.
* It computes the shortest paths between all pairs of nodes in a weighted graph.
* It finds shortest paths between all pairs of vertices in a weighted graph.
* It finds shortest path from all vertices to all vertices.
* It works by considering each vertex as an intermediate point and updating the shortest paths accordingly.
* It can handle graphs with negative edge weights but no negative weight cycles(but it can detect).
* **Time Complexity: O(V^3)**, where V is the number of vertices in the graph.
* **Space Complexity: O(V^2)** for the distance matrix.

```CSharp
public class FloydWarshallAlgorithm
{
    public int[,] FloydWarshall(int V, int[,] graph)
    {
        int[,] dist = new int[V, V];

        // Initialize distance array
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                dist[i, j] = graph[i, j];
            }
        }

        // Update distances using intermediate vertices
        for (int k = 0; k < V; k++)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue)
                    {
                        dist[i, j] = Math.Min(dist[i,j], dist[i, k] + dist[k, j]);
                    }
                }
            }
        }

        // Detect negative cycles
        for (int i = 0; i < n; i++)
        {
            if (dist[i, i] < 0)
            {
                Console.WriteLine("Graph contains a negative weight cycle.");
                break;
            }
        }

        return dist;
    }
}
```

#### Minimum Spanning Tree (MST)
* A Minimum Spanning Tree (MST) of a connected, undirected graph is a subset of edges that connects all vertices together without any cycles and with the minimum possible total edge weight.
* Two popular algorithms to find the MST are Prim's Algorithm and Kruskal's Algorithm.
* Both algorithms use greedy strategies to build the MST incrementally.
* Prim's Algorithm starts from a single vertex and grows the MST by adding the smallest edge that connects a vertex in the MST to a vertex outside the MST.
* Kruskal's Algorithm sorts all edges by weight and adds them one by one to the MST, ensuring that no cycles are formed.
* Both algorithms have a time complexity of O(E log V), where E is the number of edges and V is the number of vertices in the graph.
* They are widely used in network design, clustering, and other applications where minimizing connection costs is essential.


#### Prim's Algorithm
* Prim's Algorithm finds the Minimum Spanning Tree (MST) of a connected, undirected graph by starting from a single vertex and growing the MST by adding the smallest edge that connects a vertex in the MST to a vertex outside the MST.
* It uses a priority queue to efficiently select the next edge with the smallest weight.
* The algorithm continues until all vertices are included in the MST.
* Below is the implementation of Prim's Algorithm in C#.

```CSharp
public class PrimAlgorithm
{
    public List<(int u, int v, int weight)> Prim(int V, List<List<(int neighbor, int weight)>> adj)
    {
        bool[] inMST = new bool[V];
        var pq = new SortedSet<(int weight, int u, int v)>();
        List<(int u, int v, int weight)> mstEdges = new List<(int u, int v, int weight)>();

        inMST[0] = true;
        foreach (var (neighbor, weight) in adj[0])
        {
            pq.Add((weight, 0, neighbor));
        }

        while (pq.Count > 0)
        {
            var (weight, u, v) = pq.Min;
            pq.Remove(pq.Min);

            if (inMST[v]) continue;

            inMST[v] = true;
            mstEdges.Add((u, v, weight));

            foreach (var (neighbor, edgeWeight) in adj[v])
            {
                if (!inMST[neighbor])
                {
                    pq.Add((edgeWeight, v, neighbor));
                }
            }
        }

        return mstEdges;
    }
}
```

#### Disjoint Set Union (DSU) / Union-Find
* Disjoint Set Union (DSU), also known as Union-Find, is a data structure that keeps track of a partition of a set into disjoint subsets.
* It supports two main operations: Find and Union.
* The Find operation determines which subset a particular element is in, allowing for efficient checking of whether two elements are in the same subset.
* The Union operation merges two subsets into a single subset.
* DSU is commonly used in graph algorithms, such as Kruskal's algorithm for finding the Minimum Spanning Tree (MST) and in network connectivity problems.
* It is efficient, with nearly constant time complexity for both operations when implemented with path compression and union by rank.
* Below is the implementation of Disjoint Set Union (DSU) in C#.

```CSharp
public class DisjointSet
{
    private int[] parent;
    private int[] rank;

    public DisjointSet(int size)
    {
        parent = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int u)
    {
        if (parent[u] != u)
        {
            parent[u] = Find(parent[u]); // Path compression
        }
        return parent[u];
    }

    public void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);

        if (rootU != rootV)
        {
            // Union by rank
            if (rank[rootU] > rank[rootV])
            {
                parent[rootV] = rootU;
            }
            else if (rank[rootU] < rank[rootV])
            {
                parent[rootU] = rootV;
            }
            else
            {
                parent[rootV] = rootU;
                rank[rootU]++;
            }
        }
    }
}
```

#### Kruskal's Algorithm
* Kruskal's Algorithm finds the Minimum Spanning Tree (MST) of a connected, undirected graph by sorting all edges by weight and adding them one by one to the MST, ensuring that no cycles are formed.
* It uses the Disjoint Set Union (DSU) data structure to efficiently manage and merge connected components.
* The algorithm continues adding edges until the MST contains V-1 edges, where V is the number of vertices in the graph.
* Below is the implementation of Kruskal's Algorithm in C#.

```CSharp
public class KruskalAlgorithm
{
    // Referring DisjointSet class defined earlier

    public List<(int u, int v, int weight)> Kruskal(int V, List<(int u, int v, int weight)> edges)
    {
        edges.Sort((a, b) => a.weight.CompareTo(b.weight));
        DisjointSet ds = new DisjointSet(V);
        List<(int u, int v, int weight)> mstEdges = new List<(int u, int v, int weight)>();

        foreach (var (u, v, weight) in edges)
        {
            if (ds.Find(u) != ds.Find(v))
            {
                ds.Union(u, v);
                mstEdges.Add((u, v, weight));
            }
        }

        return mstEdges;
    }
}
```

#### Kosaraju's Algorithm for Strongly Connected Components (SCC)
* It is applicable to **directed graphs** only.
* Kosaraju's Algorithm is used to find all Strongly Connected Components (SCCs).
* An SCC is a maximal subgraph where every vertex is reachable from every other vertex within the subgraph.
* It means that if there is a path from vertex A to vertex B, then there is also a path from vertex B to vertex A.

* The algorithm works in two main passes:   
  1. Perform a DFS on the original graph to determine the finishing order of vertices.
  2. Put all vertices in a stack according to their finishing times.
  3. Reverse the graph (transpose) and perform DFS in the order of decreasing finishing times to identify SCCs.
  4. Each Node will be taken from Stack and DFS will be performed if not visited already in transposed graph.
  5. Each DFS traversal in the transposed graph will yield one SCC.
* Below is the implementation of Kosaraju's Algorithm in C#.

```CSharp
public class SCC_Kosaraju_Algorithm
{
    private List<List<int>> FindSCCs(int vertices, List<List<int>> adj)
    {
        // Step 1: Perform DFS and store the finish order
        Stack<int> finishStack = new Stack<int>();
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                DFS(i, adj, visited, finishStack);
            }
        }

        // Step 2: Transpose the graph
        List<List<int>> transposedAdj = TransposeGraph(vertices, adj);

        // Step 3: Perform DFS on transposed graph in finish order
        visited = new bool[vertices];
        List<List<int>> sccs = new List<List<int>>();
        while (finishStack.Count > 0)
        {
            int node = finishStack.Pop();
            if (!visited[node])
            {
                List<int> currentSCC = new List<int>();
                DFS_Transpose(node, transposedAdj, visited, currentSCC);
                sccs.Add(currentSCC);
            }
        }
        return sccs;
    }

    private void DFS(int node, List<List<int>> adj, bool[] visited, Stack<int> finishStack)
    {
        visited[node] = true;
        foreach (var neighbor in adj[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, adj, visited, finishStack);
            }
        }
        finishStack.Push(node);
    }

    private List<List<int>> TransposeGraph(int vertices, List<List<int>> adj)
    {
        List<List<int>> transposedAdj = new List<List<int>>();
        for (int i = 0; i < vertices; i++)
        {
            transposedAdj.Add(new List<int>());
        }

        for (int i = 0; i < vertices; i++)
        {
            foreach (var neighbor in adj[i])
            {
                transposedAdj[neighbor].Add(i);
            }
        }
        return transposedAdj;
    }

    private void DFS_Transpose(int node, List<List<int>> transposedAdj, bool[] visited, List<int> currentSCC)
    {
        visited[node] = true;
        currentSCC.Add(node);
        foreach (var neighbor in transposedAdj[node])
        {
            if (!visited[neighbor])
            {
                DFS_Transpose(neighbor, transposedAdj, visited, currentSCC);
            }
        }
    }
}
```

#### Tarjan's Algorithm for Strongly Connected Components (SCC)
* Tarjan's Algorithm is another method to find all Strongly Connected Components (SCCs) in a directed graph.
* It uses a single DFS traversal and maintains two arrays: discovery time and low-link values.
* The low-link value of a vertex is the smallest discovery time reachable from that vertex.
* When a vertex's discovery time equals its low-link value, it indicates the root of an SCC.
* **Applications:** Circuit analysis, dependency resolution, deadlock detection, optimizing routes, and more!* Below is the implementation of Tarjan's Algorithm in C#.

```CSharp
public class TarjanAlgorithm
{
    private int time = 0;
    private void DFS(int u, bool[] onStack, int[] disc, int[] low, Stack<int> stack, List<List<int>> adj, List<List<int>> sccs)
    {
        disc[u] = low[u] = ++time;
        stack.Push(u);
        onStack[u] = true;

        foreach (var v in adj[u])
        {
            if (disc[v] == -1)
            {
                DFS(v, onStack, disc, low, stack, adj, sccs);
                low[u] = Math.Min(low[u], low[v]);
            }
            else if (onStack[v])
            {
                low[u] = Math.Min(low[u], disc[v]);
            }
        }

        // If u is a root node, pop the stack and generate an SCC
        if (low[u] == disc[u])
        {
            List<int> component = new List<int>();
            int w;
            do
            {
                w = stack.Pop();
                onStack[w] = false;
                component.Add(w);
            } while (w != u);
            sccs.Add(component);
        }
    }

    public List<List<int>> FindSCCs(int V, List<List<int>> adj)
    {
        int[] disc = new int[V];
        int[] low = new int[V];
        bool[] onStack = new bool[V];
        Stack<int> stack = new Stack<int>();
        List<List<int>> sccs = new List<List<int>>();

        for (int i = 0; i < V; i++)
        {
            disc[i] = -1;
            low[i] = -1;
        }

        for (int i = 0; i < V; i++)
        {
            if (disc[i] == -1)
            {
                DFS(i, onStack, disc, low, stack, adj, sccs);
            }
        }

        return sccs;
    }
}
```

#### Articulation Points and Bridges in a Graph
* Articulation Points (or Cut Vertices) are vertices in a graph whose removal increases the number of connected components.
* Bridges (or Cut Edges) are edges in a graph whose removal increases the number of connected components.
* Both concepts are important in network design and analysis, as they identify critical points whose failure can disrupt connectivity.
* The algorithms to find articulation points and bridges use DFS traversal and maintain discovery and low-link values for each vertex.
* Below is the implementation of finding Articulation Points and Bridges in C#.

```CSharp
public class GraphArticulationPointsAndBridges
{
    private int time = 0;

    private void APAndBridgesDFS(int u, bool[] visited, int[] disc, int[] low, int parent, List<List<int>> adj, HashSet<int> articulationPoints, List<(int u, int v)> bridges)
    {
        visited[u] = true;
        disc[u] = low[u] = ++time;
        int children = 0;

        foreach (var v in adj[u])
        {
            if (!visited[v])
            {
                children++;
                APAndBridgesDFS(v, visited, disc, low, u, adj, articulationPoints, bridges);
                low[u] = Math.Min(low[u], low[v]);

                // Articulation point condition
                if (parent != -1 && low[v] >= disc[u])
                {
                    articulationPoints.Add(u);
                }

                // Bridge condition
                if (low[v] > disc[u])
                {
                    bridges.Add((u, v));
                }
            }
            else if (v != parent)
            {
                low[u] = Math.Min(low[u], disc[v]);
            }
        }

        // Special case for root
        if (parent == -1 && children > 1)
        {
            articulationPoints.Add(u);
        }
    }

    public (HashSet<int> articulationPoints, List<(int u, int v)> bridges) FindArticulationPointsAndBridges(int V, List<List<int>> adj)
    {
        bool[] visited = new bool[V];
        int[] disc = new int[V];
        int[] low = new int[V];
        HashSet<int> articulationPoints = new HashSet<int>();
        List<(int u, int v)> bridges = new List<(int u, int v)>();

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                APAndBridgesDFS(i, visited, disc, low, -1, adj, articulationPoints, bridges);
            }
        }

        return (articulationPoints, bridges);
    }
}
```

