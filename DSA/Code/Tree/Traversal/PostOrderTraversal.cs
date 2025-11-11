/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int data;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val) {
 *         this.data = val;
 *         this.left = null;
 *         this.right = null;
 *     }
 * }
 */

public class Solution {
    public List<int> postorder(TreeNode root) {
        // Your code goes here

        List<int> res = new List<int>();
        Traverse(root, res);

        return res;
    }

    private void Traverse(TreeNode root, List<int> res)
    {
        if(root == null) return;

        Traverse(root.left, res);
        Traverse(root.right, res);
        res.Add(root.data);
    }
}