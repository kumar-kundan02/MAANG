// Using DFS to traverse a graph using recursion(in-built call stack)
public class Graph
{
    HashSet<int> visited = new HashSet<int>();
    public void DFS(GraphNode node, HashSet<int> visited)
    {
        if (node == null || visited.Contains(node.Value))
            return;

        Console.WriteLine(node.Value);
        visited.Add(node.Value);

        foreach (var neighbor in node.Neighbors)
        {
            if (!visited.Contains(neighbor.Value))
            {
                DFS(neighbor, visited);
            }
        }
    }
}

// Using DFS to traverse a graph using an explicit stack
public class GraphIterative
{
    public void DFS(GraphNode root, int n)
    {
        int[] visited = new int[n];
        Stack<GraphNode> stack = new Stack<GraphNode>();

        stack.Push(root);

        while (stack.Count != 0)
        {
            var currentNode = stack.Pop();

            if (visited[currentNode.Value] == 1)
                continue;

            Console.WriteLine(currentNode.Value);
            visited[currentNode.Value] = 1;

            foreach (var neighbor in currentNode.Neighbors)
            {
                if (visited[neighbor.Value] == 0)
                {
                    stack.Push(neighbor);
                }
            }
        }
    }
}