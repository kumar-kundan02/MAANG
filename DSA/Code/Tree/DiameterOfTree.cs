/*
Given the root of a binary tree, return the length of the diameter of the tree.
The diameter of a binary tree is the length of the longest path between any two nodes in the tree. It may or may not pass through the root.
*/

public class Solution {
    int diameter = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        //your code goes here
        Solve(root);
        return diameter;
    }

    private int Solve(TreeNode root)
    {
        if(root == null) return 0;

        int lh = Solve(root.left);

        int rh = Solve(root.right);

        diameter = Math.Max(diameter, lh+rh);    
        return Math.Max(lh, rh) + 1;
    }
}