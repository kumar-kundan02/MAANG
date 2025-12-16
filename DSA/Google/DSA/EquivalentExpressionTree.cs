/*
You are given two binary trees representing mathematical expressions. Each tree node contains either a lowercase English letter ('a' to 'z') or the character +.

Two binary expression trees are equivalent if they evaluate to the same value, regardless of what the variables are set to.

The task is to check whether the two expression trees are equivalent.


Example 1

Input: root1 = ["x"], root2 = ["x"]

Output: true

Explanation:

Both trees contain a single node with the value x.

Example 2

Input: root1 = ["+", "a", "+", "null", "null", "b", "c"], root2 = ["+", "+", "a", "b", "c"]

Output: true

Explanation:

The expressions a + (b + c) and (b + c) + a are equivalent due to the associative property of addition.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public char data;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(char val) { this.data = val; }
 * }
 */
public class Solution {
    public bool checkEquivalence(TreeNode root1, TreeNode root2) {
        // Your Code Goes Here
        Dictionary<char, int> map = new Dictionary<char, int>();
        Traverse(root1, map, 1);
        Traverse(root2, map, -1);

        return map.Count == 0;
    }

    private void Traverse(TreeNode root, Dictionary<char, int> map, int counter)
    {
        if(root == null) return;

        Traverse(root.left, map, counter);
        
        if(!map.ContainsKey(root.data))
        {
            map.Add(root.data, 0);
        }
        map[root.data] += counter;

        if(map[root.data] == 0)
            map.Remove(root.data);
        Traverse(root.right, map, counter);
    }
}