/*
Given the root node of a binary search tree (BST) and a value val to insert into the tree. Return the root node of the BST after the insertion.
It is guaranteed that the new value does not exist in the original BST. Note that the compiler output shows true if the node is added correctly, else false.
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

// Using Recursion

public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val) {

        if(root == null)
        {
            return new TreeNode(val);
        }

        if(val < root.val)
        {
            root.left = InsertIntoBST(root.left, val);
        }
        else
        {
            root.right = InsertIntoBST(root.right, val);
        }

        return root;
    }
}

// Using Iterative Approach
public class Solution
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        // Your code goes here

        TreeNode current = root;
        TreeNode lastNode = null;
        TreeNode nodeToAdd = new TreeNode(val);

        while (current != null)
        {
            if (val < current.val)
            {
                lastNode = current;
                current = current.left;
            }
            else if (val > current.val)
            {
                lastNode = current;
                current = current.right;
            }
        }

        if (val > lastNode.val)
        {
            lastNode.right = nodeToAdd;
        }
        else if (val < lastNode.val)
        {
            lastNode.left = nodeToAdd;
        }

        return root;

    }
}