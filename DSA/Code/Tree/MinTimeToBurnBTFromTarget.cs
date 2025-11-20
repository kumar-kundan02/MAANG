/*
Given a target node data and a root of binary tree. If the target is set on fire, determine the shortest amount of time needed to burn the entire binary tree.

It is known that in 1 second all nodes connected to a given node get burned. That is its left child, right child, and parent.
*/


/*
 // Definition for a binary tree node.
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;

     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }
*/

public class Solution {
    public int TimeToBurnTree(TreeNode root, int start) {
       // Approach: Store the parent from target till the root node
       // now start buring the node fron target 
       // Traverse in all the directions(left, right, parent)
       // the longest direction means till the BFS queue is not empty keep iterating

       // 1. BFS to Store the parent
       Dictionary<TreeNode, TreeNode> parentMap = new Dictionary<TreeNode, TreeNode>();
       Queue<TreeNode> q = new Queue<TreeNode>();
       TreeNode startNode = null;

       if(root != null)
       {
            q.Enqueue(root);
       }

       while(q.Count > 0)
       {
            var curr = q.Dequeue();
            if(curr.data == start)
            {
                startNode = curr;
            } 
            
            if(curr.left != null)
            {
                parentMap[curr.left] = curr;
                q.Enqueue(curr.left);
            }

            if(curr.right != null)
            {
                parentMap[curr.right] = curr;
                q.Enqueue(curr.right);
            }
       }

       // Clear the Queue to Reuse the existing Queue
       // BFS to calculate the burning time
       q.Clear();
       int time = 0;
       HashSet<TreeNode> visited = new HashSet<TreeNode>();

        if(startNode != null)
        {
            q.Enqueue(startNode);
            visited.Add(startNode);
        }

        while(q.Count > 0)
        {
            int size = q.Count;
            // This condition is required to track if any new node is burned or not ?
            bool burned = false;

            for(int i=0; i< size; i++)
            {
                var curr = q.Dequeue();

                if(curr.left != null && !visited.Contains(curr.left))
                {
                    q.Enqueue(curr.left);
                    visited.Add(curr.left);
                    burned = true;
                }

                if(curr.right != null && !visited.Contains(curr.right))
                {
                    q.Enqueue(curr.right);
                    visited.Add(curr.right);
                    burned = true;
                }

                if(parentMap.ContainsKey(curr) && !visited.Contains(parentMap[curr]))
                {
                    q.Enqueue(parentMap[curr]);
                    visited.Add(parentMap[curr]);
                    burned = true;
                }
            }

            if(burned)
                time++;
        }
       
        return time;
    }
}
