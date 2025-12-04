/*
Given the root node of a binary tree. Return true if the given binary tree is a binary search tree(BST) else false.
A valid BST is defined as follows:
The left subtree of a node contains only nodes with key strictly less than the node's key.
The right subtree of a node contains only nodes with key strictly greater than the node's key.
Both the left and right subtrees must also be binary search trees.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int data;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.data = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
   public bool IsBST(TreeNode root) {
        return ValidateBST(root, new List<int>());

    }

    private bool ValidateBST(TreeNode root, List<int> lst)
    {
        if(root == null) return true;

        if(!ValidateBST(root.left, lst)) 
        {
            return false;
        }
        if(lst.Count > 0 && root.data <= lst[lst.Count-1])
            return false;
        lst.Add(root.data);
        return ValidateBST(root.right, lst);
    }
}
