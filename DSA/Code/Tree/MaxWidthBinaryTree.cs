/*
Given the root of a binary tree, return the maximum width of the given tree.

The maximum width of a tree is the maximum width among all levels. The width of a level is determined by measuring the distance between its end nodes, which are the leftmost and rightmost non-null nodes. The length calculation additionally takes into account the null nodes that would be present between the end nodes if a full binary tree were to stretch down to that level.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int data;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int val) { data = val; left = null, right = null }
 * }
 **/

public class Solution
{
    public int widthOfBinaryTree(TreeNode root)
    {
        // Approach: we will be using the Level Order Traversal
        // Then apply the Indexing formula to identify the child index position in Level order as if it was a complete binary tree
        // for 1 based index: leftChild pos = 2*ParentIndex, rightChild = 2*ParentIndex+1

        int res = 0;

        if(root == null) return res;

        Queue<Tuple<TreeNode,int>> q = new Queue<Tuple<TreeNode, int>>();
        q.Enqueue(Tuple.Create(root, 0));

        while(q.Count > 0)
        {
            int size = q.Count;
            int first = 0;
            int last = 0;

            for(int i=0; i<size; i++)
            {
                var curr = q.Dequeue();
                int idx = curr.Item2;
                var node = curr.Item1;

                if(i == 0) first = idx;
                if(i == size-1) last = idx;

                if(node.left != null)
                {
                    q.Enqueue(Tuple.Create(node.left, idx*2));
                }

                if(node.right != null)
                {
                    q.Enqueue(Tuple.Create(node.right, idx*2+1));
                }
                
            }

            res = Math.Max(res, last - first + 1);
        }

        return res;
    }
}