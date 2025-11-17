/*
Given the root of a binary tree, return the top view of the binary tree.

Top view of a binary tree is the set of nodes visible when the tree is viewed from the top. Return nodes from the leftmost node to the rightmost node. Also if 2 nodes are outside the shadow of the tree and are at the same position then consider the left ones only(i.e. leftmost). 
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
    public List<int> TopView(TreeNode root)
    {
        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

        Traverse(root, dict, 0, 0);

        return dict.Values.ToList();

    }

    private void Traverse(TreeNode root, SortedDictionary<int,int> dict, int row, int col)
    {
        if(root == null) return;

        if(!dict.ContainsKey(col))
        {
            dict.Add(col, root.data);
        }

        Traverse(root.left, dict, row+1, col-1);
        Traverse(root.right, dict, row+1, col+1);
    }
}