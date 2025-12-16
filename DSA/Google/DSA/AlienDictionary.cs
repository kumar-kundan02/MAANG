using System;
using System.Collections.Generic;
using System.Text;

public class SolutionEditorial
{
    /* Function to return the topological
     sorting of given graph */
    private List<int> topoSort(int V, List<List<int>> adj)
    {
        // To store the In-degrees of nodes
        int[] inDegree = new int[V];

        // Update the in-degrees of nodes
        for (int i = 0; i < V; i++)
        {
            foreach (int it in adj[i])
            {
                // Update the in-degree
                inDegree[it]++;
            }
        }

        // To store the result
        List<int> ans = new List<int>();

        // Queue to facilitate BFS
        Queue<int> q = new Queue<int>();

        // Add the nodes with no in-degree to queue
        for (int i = 0; i < V; i++)
        {
            if (inDegree[i] == 0)
            {
                q.Enqueue(i);
            }
        }

        // Until the queue is empty
        while (q.Count > 0)
        {
            // Get the node
            int node = q.Dequeue();

            // Add it to the answer
            ans.Add(node);

            // Traverse the neighbours
            foreach (int it in adj[node])
            {
                // Decrement the in-degree
                inDegree[it]--;

                /* Add the node to queue if
                its in-degree becomes zero */
                if (inDegree[it] == 0)
                {
                    q.Enqueue(it);
                }
            }
        }

        // Return the result
        return ans;
    }

    /* Function to determine order of
    letters based on alien dictionary */
    public string findOrder(string[] dict, int N, int K)
    {
        // Initialise a graph of K nodes
        List<List<int>> adj = new List<List<int>>(K);
        for (int i = 0; i < K; i++)
        {
            adj.Add(new List<int>());
        }

        // Compare the consecutive words
        for (int i = 0; i < N - 1; i++)
        {
            string s1 = dict[i];
            string s2 = dict[i + 1];
            int len = Math.Min(s1.Length, s2.Length);

            /* Compare the pair of strings letter by
            letter to identify the differentiating letter */
            for (int ptr = 0; ptr < len; ptr++)
            {
                // If the differentiating letter is found
                if (s1[ptr] != s2[ptr])
                {
                    // Add the edge to the graph
                    adj[s1[ptr] - 'a'].Add(s2[ptr] - 'a');
                    break;
                }
            }
        }

        /* Get the topological sort
        of the graph formed */
        List<int> topo = this.topoSort(K, adj);

        // To store the answer
        StringBuilder ansBuilder = new StringBuilder();

        for (int i = 0; i < K; i++)
        {
            // Add the letter to the result
            ansBuilder.Append((char)('a' + topo[i]));
            ansBuilder.Append(' ');
        }

        // Return the answer
        return ansBuilder.ToString().TrimEnd();
    }
}

public class ProgramEditorial
{
    public static void Main(string[] args)
    {
        // Example usage
        int N = 5;
        int K = 4;
        string[] dict = new string[]
        {
            "baa", "abcd", "abca", "cab", "cad"
        };

        SolutionEditorial sol = new SolutionEditorial();
        string ans = sol.findOrder(dict, N, K);

        // Output
        Console.WriteLine("The order to characters as per alien dictionary is: " + ans);
    }
}