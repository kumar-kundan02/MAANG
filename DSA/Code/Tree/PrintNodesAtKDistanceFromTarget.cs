/*
Given the root of a binary tree, the value of a target node target, and an integer k. Return an array of the values of all nodes that have a distance k from the target node.

The answer can be returned in any order (N represents null).

Note: Although input shows target as a value, internally it refers to the TreeNode with that value.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int data;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int val) { data = val; left = null, right = null }
 * }
 */

public class Solution
{
    public IList<int> distanceK(TreeNode root, TreeNode target, int k)
    {
        Dictionary<int, TreeNode> parentMap = new Dictionary<int, TreeNode>();

        Queue<TreeNode> q = new Queue<TreeNode>();
        if(root != null)
            q.Enqueue(root);

        while(q.Count > 0)
        {
            var node = q.Dequeue();
            if(node.left != null) 
            {
                q.Enqueue(node.left);
                parentMap[node.left.data] = node;
            }
            if(node.right != null) 
            {
                q.Enqueue(node.right);
                parentMap[node.right.data] = node;
            }

            // if(node.data == target.data) break;
        }
        
        // Now start from the target node and traverse its neighbours(leftChild, rightChild, parent)
        // User BFS traversal using queue
        // Maintain visited nodes as it will again revisit the parent node and then again its child

        q.Clear();
        List<int> nodesToPrint = new List<int>();
        int distance = 0;
        HashSet<int> visited = new HashSet<int>();

        if(target != null)
        {
            q.Enqueue(target);
            visited.Add(target.data);
        }

        while(q.Count > 0)
        {
            if(distance == k)
            {
                while(q.Count > 0)
                {
                    nodesToPrint.Add(q.Dequeue().data);
                }
                return nodesToPrint;
            }

            int size = q.Count;

            for(int i=0; i<size; i++)
            {
                var curr = q.Dequeue();

                if(parentMap.ContainsKey(curr.data) && !visited.Contains(parentMap[curr.data].data))
                {
                    q.Enqueue(parentMap[curr.data]);
                    visited.Add(parentMap[curr.data].data);
                }

                if(curr.left != null && !visited.Contains(curr.left.data))
                {
                    q.Enqueue(curr.left);
                    visited.Add(curr.left.data);
                }

                if(curr.right != null && !visited.Contains(curr.right.data))
                {
                    q.Enqueue(curr.right);
                    visited.Add(curr.right.data);
                }
            }
            distance++;
        }

        return nodesToPrint;
    }
}