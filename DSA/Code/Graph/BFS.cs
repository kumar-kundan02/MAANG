// BFS Implementation for graph with 'n' nodes
class Graph
{
    void BFS(GraphNode root, int n)
    {
        int[] visited = new int[n];
        Queue<int> q = new Queue<int>();

        q.Enqueue(root.Value);
        visited[root.Value] = 1;

        while (q.Count != 0)
        {
            var currentNode = q.Dequeue();
            Console.WriteLine(currentNode.Value);

            foreach (var neighbor in currentNode.Neighbors)
            {
                if (visited[neighbor.Value] == 0)
                {
                    q.Enqueue(neighbor.Value);
                    visited[neighbor.Value] = 1;
                }  
            }
        }
    }
}
