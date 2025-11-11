/*
Given root of the binary tree, return its maximum depth.
A binary tree's maximum depth is number of nodes along the longest path from root node down to the farthest node.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int maxDepth(TreeNode root) {
        //your code goes here

        if(root == null) return 0;

        int lh = 1 + maxDepth(root.left);
        int rh = 1 + maxDepth(root.right);

        return Math.Max(lh, rh);
    }
}