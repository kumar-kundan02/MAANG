/*
Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
*/

public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return Solve(root.left, root.right);
    }

    private bool Solve(TreeNode root1, TreeNode root2)
    {
        if(root1 == null && root2 == null) return true;

        if(root1 == null || root2 == null) return false;

        if(root1.data != root2.data) return false;

        return Solve(root1.left, root2.right) && Solve(root1.right, root2.left);
    }
}