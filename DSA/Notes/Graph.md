# Graph

## Breadth First Search (BFS)
* Used for traversing or searching tree or graph data structures.
* Explores all neighbors at the present depth prior to moving on to nodes at the next depth
* It works for both **directed and undirected** graphs.
* It uses a **queue** data structure to keep track of nodes to visit next.
* It uses a **set or boolean array** to keep track of **visited nodes** to avoid processing the same node multiple times.

#### Setup and Steps for BFS

>- Initialize Visited Array/Set to Keep track Visited Nodes
>- Initialize Queue to store neighbours and Enqueue the Starting Node
>- Once node is inserted in Queue, mark it as Visited

#### Time and Space Complexity
* **Time Complexity:** O(V + E) where V is the number of vertices and E is the number of edges in the graph.
* **Space Complexity:** O(V) for the visited array and the queue in the worst case.

@import "../Code/BFS.cs" ```

## DFS (Depth First Search)
* Used for traversing or searching tree or graph data structures.
* Explores as far as possible along each branch before backtracking.
* It works for both **directed and undirected** graphs.
* It uses a **stack** data structure (can be implemented using recursion) to keep track of nodes to visit next.
* It uses a **set or boolean array** to keep track of **visited nodes** to avoid processing the same node multiple times.

#### Time and Space Complexity
Where V is the number of vertices and E is the number of edges in the graph.

* **Time Complexity: O(V + E)**
Summation of degree of nodes i.e 2xE and each Nodes need to be visited once then again O(V).
* **Space Complexity: O(V)** 
O(V) : Visited + O(V) : Stack(skewed Graph) + O(V): All Nodes
O(V) for the visited array and the stack in the worst case.

#### Setup and Steps for DFS
>
>- Initialize Visited Array/Set to Keep track Visited Nodes
>- Initialize Stack to store neighbours and Push the Starting Node
>- Once node is inserted in Stack, mark it as Visited
>

@import "../Code/DFS.cs" ```

#### Topological Sort
* Topological Sort is a linear ordering of vertices such that for every directed edge u -> v, vertex u comes before v in the ordering.
* It is applicable only to Directed Acyclic Graphs (DAGs).
* It is mainly used for scheduling tasks, resolving dependencies, and organizing data with precedence constraints.

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

**Intuition:**
>- Calculate the ***in-degree*** (number of incoming edges) for each vertex.
>- Start with all vertices that have an in-degree of 0 (no dependencies).
>- Use a queue to process these vertices, and for each vertex processed, reduce the in-degree
of its neighbors. If any neighbor's in-degree becomes 0, add it to the queue.

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
* Dijkstra's Algorithm is used to find the shortest path from a source vertex to all other  vertices in a weighted graph with ***non-negative edge weights***.
* It uses a priority queue to explore the vertex with the smallest known distance first.
* It updates the distances of neighboring vertices if a shorter path is found through the current vertex.

```CSharp
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

        var priorityQueue = new SortedSet<(int distance, int vertex)>();
        priorityQueue.Add((0, source));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentVertex) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            foreach (var (neighbor, weight) in adj[currentVertex])
            {
                int newDist = currentDistance + weight;
                if (newDist < distances[neighbor])
                {
                    priorityQueue.Remove((distances[neighbor], neighbor));
                    distances[neighbor] = newDist;
                    priorityQueue.Add((newDist, neighbor));
                }
            }
        }

        return distances;
    }
}
```

#### Belmon-Ford Algorithm
* Bellman-Ford Algorithm is used to find the shortest path from a source vertex to all other vertices in a weighted graph, even if the graph contains edges with negative weights.
* It works by repeatedly relaxing all edges, ensuring that the shortest path to each vertex is found.
* It can also detect negative weight cycles in the graph.

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
            foreach (var (u, v, weight) in edges)
            {
                if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                {
                    distances[v] = distances[u] + weight;
                }
            }
        }

        // Check for negative weight cycles
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
* Multi source shortest path algorithm.
* It finds shortest paths between all pairs of vertices in a weighted graph.
* It finds shortest path from all vertices to all vertices.
* It works by considering each vertex as an intermediate point and updating the shortest paths accordingly.
* It can handle graphs with negative edge weights but no negative weight cycles.

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
                    if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                        dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
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


**Prim's Algorithm**
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

**Kruskal's Algorithm**
* Kruskal's Algorithm finds the Minimum Spanning Tree (MST) of a connected, undirected graph by sorting all edges by weight and adding them one by one to the MST, ensuring that no cycles are formed.
* It uses the Disjoint Set Union (DSU) data structure to efficiently manage and merge connected components.
* The algorithm continues adding edges until the MST contains V-1 edges, where V is the number of vertices in the graph.
* Below is the implementation of Kruskal's Algorithm in C#.

```CSharp
public class KruskalAlgorithm
{
    private class DisjointSet
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
                parent[u] = Find(parent[u]);
            }
            return parent[u];
        }

        public void Union(int u, int v)
        {
            int rootU = Find(u);
            int rootV = Find(v);

            if (rootU != rootV)
            {
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
#### Kosaraju's Algorithm for Strongly Connected Components (SCC)
* Kosaraju's Algorithm is used to find all Strongly Connected Components (SCCs) in a directed graph.
* An SCC is a maximal subgraph where every vertex is reachable from every other vertex within the subgraph.
* The algorithm works in two main passes:   
  1. Perform a DFS on the original graph to determine the finishing order of vertices.
  2. Reverse the graph (transpose) and perform DFS in the order of decreasing finishing times to identify SCCs.
* Below is the implementation of Kosaraju's Algorithm in C#.

```CSharp
public class KosarajuAlgorithm
{
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

    private void TransposeGraph(List<List<int>> adj, List<List<int>> transposedAdj)
    {
        for (int i = 0; i < adj.Count; i++)
        {
            foreach (var neighbor in adj[i])
            {
                transposedAdj[neighbor].Add(i);
            }
        }
    }

    private void DFSUtil(int node, bool[] visited, List<int> component, List<List<int>> transposedAdj)
    {
        visited[node] = true;
        component.Add(node);
        foreach (var neighbor in transposedAdj[node])
        {
            if (!visited[neighbor])
            {
                DFSUtil(neighbor, visited, component, transposedAdj);
            }
        }
    }
    public List<List<int>> FindSCCs(int V, List<List<int>> adj)
    {
        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[V];

        // First pass: Fill vertices in stack according to their finishing times
        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                DFS(i, visited, stack, adj);
            }
        }
        // Transpose the graph
        List<List<int>> transposedAdj = new List<List<int>>(V);
        for (int i = 0; i < V; i++)
        {
            transposedAdj.Add(new List<int>());
        }

        TransposeGraph(adj, transposedAdj);
        // Second pass: Process all vertices in order defined by the stack
        visited = new bool[V];
        List<List<int>> sccs = new List<List<int>>();
        while (stack.Count > 0)
        {
            int node = stack.Pop();
            if (!visited[node])
            {
                List<int> component = new List<int>();
                DFSUtil(node, visited, component, transposedAdj);
                sccs.Add(component);
            }
        }
        return sccs;
    }
}
```

#### Tarjan's Algorithm for Strongly Connected Components (SCC)
* Tarjan's Algorithm is another method to find all Strongly Connected Components (SCCs) in a directed graph.
* It uses a single DFS traversal and maintains two arrays: discovery time and low-link values.
* The low-link value of a vertex is the smallest discovery time reachable from that vertex.
* When a vertex's discovery time equals its low-link value, it indicates the root of an SCC.
* Below is the implementation of Tarjan's Algorithm in C#.

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

