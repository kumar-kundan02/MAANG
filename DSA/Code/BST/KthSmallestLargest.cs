/*
Given the root node of a binary search tree (BST) and an integer k.
Return the kth smallest and largest value (1-indexed) of all values of the nodes in the tree.
Return the 1st integer as kth smallest and 2nd integer as kth largest in the returned array.
*/

/** Definition for a binary tree node.
* public class TreeNode {
*     public int Data;
*     public TreeNode Left;
*     public TreeNode Right;
*     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
*       Data = val;
*       Left = left;
*       Right = right;
*   }
*}
*/

public class Solution {
    public List<int> KLargesSmall(TreeNode root, int k) {
        // Do the Inorder traversal to get the sorted Array
        // Find the kth smallest and largest from the array

        List<int> lst = new List<int>();
        Traverse(root, lst);

        List<int> res = new List<int>();
        res.Add(lst[k-1]);
        res.Add(lst[lst.Count - k]);

        return res;
    }

    private void Traverse(TreeNode root, List<int> lst)
    {
        if(root == null)
            return;
        
        Traverse(root.Left, lst);
        lst.Add(root.Data);
        Traverse(root.Right, lst);
    }
}