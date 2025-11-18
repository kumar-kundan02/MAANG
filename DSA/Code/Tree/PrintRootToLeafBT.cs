/*
Given the root of a binary tree. Return all the root-to-leaf paths in the binary tree.

A leaf node of a binary tree is the node which does not have a left and right child.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int data;
 *     public TreeNode left;
 *     public TreeNode right;
 *      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
 *          this.data = val;
 *          this.left = left;
 *          this.right = right;
 *      }
 * }
 */

public class Solution {
    public List<List<int>> AllRootToLeaf(TreeNode root) {
        // Your code goes here

        List<List<int>> res = new List<List<int>>();

        if(root == null) return res;
        Traverse(root, res, new List<int>());
        return res;
    }

    private void Traverse(TreeNode root, List<List<int>> res, List<int> path)
    {
        if(root == null) return;

        // Adding the node data here as if it is the leaf node it should be included
        path.Add(root.data);

        // Checking if its a leaf node then add the current Path
        if(root.left == null && root.right == null)
        {
            var lst = new List<int>(path);
            res.Add(lst);

            // Once Path is added then leaf node is the one which should be removed in the 1st place during backtracking
            path.RemoveAt(path.Count-1);
            return;
        }
        
        Traverse(root.left, res, path);
        Traverse(root.right, res, path);
        path.RemoveAt(path.Count-1);
    }
}