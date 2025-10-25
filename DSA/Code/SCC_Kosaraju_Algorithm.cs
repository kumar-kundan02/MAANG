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