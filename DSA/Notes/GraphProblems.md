## Problems Based on Graph Traversal
1. [Number of Islands](https://leetcode.com/problems/number-of-islands/)

> **Intution:**
>- We can use either BFS or DFS to explore all connected land cells (1s) starting from each unvisited land cell.
>- Each time we start a new BFS/DFS, we increment our island count.

```CSharp
public class Solution {
	
    public int NumIslands(char[][] grid) {
		int islandCount =0;
		bool[,] visitorMatirx = new bool[grid.Length, grid[0].Length];
		
		for(int row=0; row < grid.Length; row++)
		{
			for(int col=0; col < grid[0].Length; col++)
			{
				visitorMatirx[row,col] = false;
			}
		}
		
        for(int row=0; row < grid.Length; row++)
		{
			for(int col=0; col < grid[0].Length; col++)
			{
				if(grid[row][col] == '1' && visitorMatirx[row,col] == false)
				{
					DFS(grid,row,col,visitorMatirx);
					islandCount++;
				}					
			}
		}
		
		return islandCount;
    }
	
	private void DFS(char[][] grid, int i, int j, bool[,] visitorMatirx)
	{
        
		if(i < grid.Length && j < grid[0].Length && i >= 0 && j >= 0 && grid[i][j] != '0' && !visitorMatirx[i,j])	
		{
			visitorMatirx[i,j] = true;
			DFS(grid, i+1,j, visitorMatirx);
            DFS(grid, i-1,j, visitorMatirx);
			DFS(grid, i,j+1, visitorMatirx);
			DFS(grid, i,j-1, visitorMatirx);
		}
	}
}
```

2. [Rotting Oranges](https://leetcode.com/problems/rotting-oranges/)

> **Intution:**
>- We need to explore all the directions to figure out what all neighbour Oranges which are getting rotated
>- Using BFS to explore all the neighbours

```CSharp
public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        bool[,] visited = new bool[rows, cols];
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;
        int minutes = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue((r, c));
                    visited[r, c] = true;
                } else if (grid[r][c] == 1) {
                    freshCount++;
                }
            }
        }

        int[][] directions = new int[][] {
            new int[] {1, 0},
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {0, -1}
        };

        while (queue.Count > 0 && freshCount > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();
                foreach (var dir in directions) {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols &&
                        grid[newRow][newCol] == 1 && !visited[newRow, newCol]) {
                        visited[newRow, newCol] = true;
                        grid[newRow][newCol] = 2;
                        freshCount--;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
            minutes++;
        }

        return freshCount == 0 ? minutes : -1;
    }
}
```

3. [Clone Graph](https://leetcode.com/problems/clone-graph/)

> **Intution:**
>- Need to do DFS to explore all the neighbours
>- Created node if it's not already created. Deciding this based on node Value
>- Used Dictionary as a map to get the Node corresponding to node Value
>- Keep Adding the neighbours in the existing node. Will get the Node directly from Dictinoary map based on value.

```CSharp
public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return node;
        Dictionary<int, Node> map = new Dictionary<int, Node>();
        CloneNodes(node, map);
        return map[1];
        
    }
    
    private void CloneNodes(Node node, Dictionary<int, Node> map)
    {
        Node newNode = new Node(node.val);
        newNode.neighbors = new List<Node>();
        
        map.Add(newNode.val, newNode);
        foreach(Node n in node.neighbors)
        {
            if(!map.ContainsKey(n.val))
                CloneNodes(n,map);
            newNode.neighbors.Add(map[n.val]);
            
        }
    }
}
```

**4. Detect Cycle in an Undirected Graph(BFS)**
> **Intution:**
>- To detect a cycle in an undirected graph using BFS, we can keep track of the parent node while traversing.
>- If we encounter a visited node that is not the parent of the current node, we have detected a cycle.

**Setup and Steps:**
>- Initialize a visited array to keep track of visited nodes.
>- Initialize a Queue to perform BFS.
>- Keep both current node and parent node while traversing.

```CSharp
public class GraphCycleDetectorUndirectedBFS
{
    public bool HasCycle(int V, List<List<int>> adj)
    {
        bool[] visited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                if (IsCyclic(i, visited, adj))
                    return true;
            }
        }
        return false;
    }

    private bool IsCyclic(int start, bool[] visited, List<List<int>> adj)
    {
        Queue<(int node, int parent)> queue = new Queue<(int, int)>();
        queue.Enqueue((start, -1));
        visited[start] = true;

        while (queue.Count > 0)
        {
            var (node, parent) = queue.Dequeue();

            foreach (var neighbor in adj[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue((neighbor, node));
                }
                else if (neighbor != parent)
                {
                    return true; // Cycle detected
                }
            }
        }
        return false;
    }
}

```

**5. Detect Cycle in an Undirected Graph(DFS)**
> **Intution:**
>- To detect a cycle in an undirected graph, we can use DFS traversal while keeping track of the parent node.
>- If we encounter a visited node that is not the parent of the current node, we have detected a cycle.

**Setup and Steps:**
>- Initialize a visited array to keep track of visited nodes.
>- Initialize Parent Node to -1 for starting node.
>- Keep both current node and parent node while traversing.

```CSharp
public class GraphCycleDetectorUndirected
{
    public bool HasCycle(int V, List<List<int>> adj)
    {
        bool[] visited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                if (IsCyclic(i, -1, visited, adj))
                    return true;
            }
        }
        return false;
    }

    private bool IsCyclic(int v, int parent, bool[] visited, List<List<int>> adj)
    {
        visited[v] = true;

        foreach (var neighbor in adj[v])
        {
            // if the neighbor hasn't been visited, recurse on it
            if (!visited[neighbor])
            {
                if (IsCyclic(neighbor, v, visited, adj))
                    return true;
            }
            // if the neighbor is visited and not parent of current vertex, we found a cycle
            else if (neighbor != parent)
            {
                return true;
            }
        }
        return false;
    }
}

```

**6. Detect Cycle in a Directed Graph**
> **Intution:**
>- To detect a cycle in a directed graph, we can use DFS traversal while keeping track of nodes in the current path.
>- If we encounter a node that is already in the current path, we have detected a cycle.
>- We can use a recursion stack (for DFS) to keep track of nodes in the current path.
>- If we finish exploring all neighbors of a node and backtrack, we remove it from the recursion stack.
>- If we complete the DFS for all nodes without finding a cycle, then the graph is acyclic.

**Setup and Steps:**
>- Initialize a visited array to keep track of visited nodes.
>- Initialize a path visited array (recursion stack) to keep track of nodes in the current DFS path.
>- If the node reach to end and backtrack, node will be removed from visited array(Recursion Stack) and **update the path visited array.**
>- If the node reaches a neighbor that is already in the path visited array, a cycle is detected.


```CSharp
public class GraphCycleDetector
{
    public bool HasCycle(int V, List<List<int>> adj)
    {
        bool[] visited = new bool[V];
        bool[] pathVisited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                if (IsCyclic(i, visited, pathVisited, adj))
                    return true;
            }
        }
        return false;
    }

    private bool IsCyclic(int v, bool[] visited, bool[] pathVisited, List<List<int>> adj)
    {
        visited[v] = true;
        pathVisited[v] = true;

        foreach (var neighbor in adj[v])
        {
            // if the neighbor hasn't been visited, recurse on it
            if (!visited[neighbor])
            {
                if (IsCyclic(neighbor, visited, pathVisited, adj))
                    return true;
            }
            // if the neighbor is in the current path, we found a cycle
            else if (pathVisited[neighbor])
            {
                return true;
            }
        }

        pathVisited[v] = false; // remove the vertex from recursion stack
        return false;
    }
} 
```
@import "../Images/DSA/Graph_DetectCycle_Directed.png"

**7. Detect Cycle in a Directed Graph using Kahn's Algorithm(BFS)**

> **Intution:**
>- Kahn's Algorithm can also be used to detect cycles in a directed graph.
>- If we can process all vertices using Kahn's Algorithm, the graph is acyclic.

**Setup and Steps:**
>- Calculate the in-degree for each vertex.
>- Use a queue to process vertices with in-degree of 0.
>- ***Keep a count of processed vertices. If this count is less than the total number of vertices, a cycle exists.***

```CSharp
public class GraphCycleDetectorKahn
{
    public bool HasCycle(int V, List<List<int>> adj)
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

        int count = 0;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            count++;

            foreach (var neighbor in adj[node])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return count != V; // If count is less than V, there is a cycle
    }
}
```

**8. [CourseSchedule 1](https://leetcode.com/problems/course-schedule/)**

```
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
You are given an array prerequisites where 
prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.

Example 2:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.
```

> **Intution:**
>- It can be solved using cycle detection in a directed graph.
>- It can also be solved by Topological Sort using DFS/Kahn's Algorithm(BFS)
>- If we can complete a topological sort of the graph, it means there are no cycles, and all courses can be completed.

```CSharp
public class CourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new List<List<int>>(new List<int>[numCourses]);
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }

        foreach (var pre in prerequisites)
        {
            adj[pre[1]].Add(pre[0]);
        }

        GraphCycleDetectorKahn cycleDetector = new GraphCycleDetectorKahn();
        return !cycleDetector.HasCycle(numCourses, adj);
    }
}
```
**9. [Course Schedule II](https://leetcode.com/problems/course-schedule-ii/)**

```
There are a total of numCourses courses you have to take, labeled from 0 to num Courses - 1. 
You are given an array prerequisites where
prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
Return the ordering of courses you should take to finish all courses.
If there are many valid answers, return any of them.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take.
To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take.
To take course 3 you should have finished both courses 1 and 2. So one correct course order is [0,2,1,3].
```
**Intution:**
>- It can be solved using Topological Sort using DFS/Kahn's Algorithm(BFS)
>- If we can complete a topological sort of the graph, it means there are no cycles, and all courses can be completed.

```CSharp
public class CourseScheduleII
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<List<int>> adj = new List<List<int>>(new List<int>[numCourses]);
        for (int i = 0; i < numCourses; i++)
        {
            adj[i] = new List<int>();
        }

        foreach (var pre in prerequisites)
        {
            adj[pre[1]].Add(pre[0]);
        }

        TopologicalSortDFS topoSort = new TopologicalSortDFS();
        List<int> order = topoSort.TopologicalSort(numCourses, adj);

        // Check if topological sort includes all courses
        if (order.Count != numCourses)
        {
            return new int[0]; // Cycle detected, return empty array
        }

        return order.ToArray();
    }
}
```

**10. [Alien Dictionary](https://leetcode.com/problems/alien-dictionary/)**

```
There is a new alien language that uses the English alphabet. However, the order among letters are unknown to you.
You are given a list of strings words from the alien language's dictionary, where the strings in
words are sorted lexicographically by the rules of this new language.
Return a string of the unique letters in the new alien language sorted in lexicographically increasing order

Example 1:
Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"

Example 2:
Input: words = ["z","x"]
Output: "zx"

Example 3:
Input: words = ["z","x","z"]
Output: ""
Explanation: The order is invalid, so return "".
```
> **Intution:**
>- We can solve this problem using Topological Sort.
>- We will build a directed graph based on the order of characters in adjacent words.
>- Then, we will perform a topological sort on this graph to determine the order of characters.
>- If a cycle is detected during the topological sort, it means the order is invalid.
>- Finally, we will return the characters in the order determined by the topological sort.

```CSharp
public class AlienDictionary
{
    public string AlienOrder(string[] words)
    {
        int V = 26; // Assuming only lowercase English letters
        List<List<int>> adj = new List<List<int>>(new List<int>[V]);
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }

        // Build the graph
        for (int i = 0; i < words.Length - 1; i++)
        {
            string word1 = words[i];
            string word2 = words[i + 1];
            int minLength = Math.Min(word1.Length, word2.Length);
            for (int j = 0; j < minLength; j++)
            {
                if (word1[j] != word2[j])
                {
                    adj[word1[j] - 'a'].Add(word2[j] - 'a');
                    break;
                }
            }
        }

        TopologicalSortDFS topoSort = new TopologicalSortDFS();
        List<int> order = topoSort.TopologicalSort(V, adj);

        // Convert to string and filter out unused characters
        HashSet<char> usedChars = new HashSet<char>();
        foreach (var word in words)
        {
            foreach (var ch in word)
            {
                usedChars.Add(ch);
            }
        }

        StringBuilder result = new StringBuilder();
        foreach (var index in order)
        {
            char ch = (char)(index + 'a');
            if (usedChars.Contains(ch))
            {
                result.Append(ch);
            }
        }

        return result.ToString();
    }
}
```

**11. Shortest Path in Directred Acyclic Graph(DAG)**

> **Intution:**
>- In a Directed Acyclic Graph (DAG), we can find the shortest path from a source node to all other nodes using topological sorting.
>- First, we perform a ***Topological sort*** of the graph.
>- Then, we **initialize** distances from the source to **all nodes** as **infinite**, except for the **source** itself which is **set to 0**.
>- We then process each node in topological order, **updating the distances to its neighbors** if a shorter path is found.

```CSharp
public class ShortestPathDAG
{
    public int[] ShortestPath(int V, List<List<(int neighbor, int weight)>> adj, int source)
    {
        TopologicalSortDFS topoSort = new TopologicalSortDFS();
        List<int> order = topoSort.TopologicalSort(V, ConvertToAdjacencyList(adj));

        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[source] = 0;

        foreach (var node in order)
        {
            if (dist[node] != int.MaxValue)
            {
                foreach (var (neighbor, weight) in adj[node])
                {
                    if (dist[node] + weight < dist[neighbor])
                    {
                        dist[neighbor] = dist[node] + weight;
                    }
                }
            }
        }

        return dist;
    }

    private List<List<int>> ConvertToAdjacencyList(List<List<(int neighbor, int weight)>> adj)
    {
        List<List<int>> simpleAdj = new List<List<int>>(new List<int>[adj.Count]);
        for (int i = 0; i < adj.Count; i++)
        {
            simpleAdj[i] = new List<int>();
            foreach (var (neighbor, _) in adj[i])
            {
                simpleAdj[i].Add(neighbor);
            }
        }
        return simpleAdj;
    }
}
```

**12. Shortest Path in Undirected Graph using BFS with Unit Weights**

> **Intution:**
>- In an undirected graph with unit weights, we can find the shortest path from a source node to all other nodes using BFS.
>- We initialize distances from the source to all nodes as infinite, except for the source itself which is set to 0.
>- We use a queue to perform BFS, updating the distances to neighbors as we explore the graph.

```CSharp
public class ShortestPathUndirectedGraph
{
    public int[] ShortestPath(int V, List<List<int>> adj, int source)
    {
        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[source] = 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            foreach (var neighbor in adj[node])
            {
                if (dist[node] + 1 < dist[neighbor])
                {
                    dist[neighbor] = dist[node] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return dist;
    }
}
```

