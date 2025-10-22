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

