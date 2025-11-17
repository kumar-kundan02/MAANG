/*
Return the number of nodes in a binary tree given its root.
Every level in a complete binary tree possibly with the exception of the final one is fully filled, and every node in the final level is as far to the left as it can be. At the last level h, it can have 1 to 2h nodes inclusive.
*/

/*
 // Definition for a binary tree node.
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;

     public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }
*/

public class Solution {
    public int CountNodes(TreeNode root) {

        if(root == null) return 0;

        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
}
