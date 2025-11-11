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
    public List<int> Preorder(TreeNode root) {
        //your code goes here
        List<int> res = new List<int>();

        Traverse(root, res);

        return res;
    }

    private void Traverse(TreeNode root, List<int> res)
    {
        if(root == null) return;

        res.Add(root.data);
        Traverse(root.left, res);
        Traverse(root.right, res);
    }
}