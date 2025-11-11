/*
Given a binary tree root, find if it is height-balanced or not.
A tree is height-balanced if the difference between the heights of left and right subtrees is not more than one for all nodes of the tree. 
*/

public class Solution
{
    public bool IsBalanced(TreeNode root)
    {
        return Height(root) != -1;
    }

    // Returns height if balanced, -1 if not
    private int Height(TreeNode node)
    {
        if(node == null) return 0;

        int leftHeight = Height(node.left);
        if(leftHeight == -1) return -1;

        int rightHeight = Height(node.right);
        if(rightHeight == -1) return -1;

        if(Math.Abs(leftHeight - rightHeight) > 1) return -1;

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}