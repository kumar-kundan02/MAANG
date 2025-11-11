/*
In a binary tree, a path is a list of nodes where there is an edge between every pair of neighbouring nodes. A node may only make a single appearance in the sequence.

The total of each node's values along a path is its path sum. Return the largest path sum of all non-empty paths given the root of a binary tree.

Note: The path does not have to go via the root.
*/

public class Solution {

    int maxPathVal = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        //your code goes here

        Solve(root);
        return maxPathVal;
    }

    private int Solve(TreeNode root)
    {
        if(root == null) return 0;

        // If Path Length is -ve then just ignore as it won't contribute in maxPath Length
        // and should be discarded
        int leftSum = Math.Max(0, Solve(root.left));
        int rightSum = Math.Max(0, Solve(root.right));

        // Total path length needs to be calculated as
        // path length => leftPath + RightPath + currentNode
        int pathSum = root.val + leftSum + rightSum;

        // Updating maxPathLength
        maxPathVal = Math.Max(maxPathVal, pathSum);

        // Returnig single path as at a time either left or right needs to be picked
        // To contribute in current Node path. whichever is maximum
        return Math.Max(leftSum, rightSum) + root.val;
    }
}