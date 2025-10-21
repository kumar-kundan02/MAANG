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