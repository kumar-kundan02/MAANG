/* 
Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
(i.e., from left to right, then right to left for the next level and alternate between).
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int data;
 *     public TreeNode left;
 *     public TreeNode right;
 *     TreeNode(int val) { data = val; left = null, right = null }
 * }
 */

public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        //your code goes here
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null) return result;

        return Traverse(root, result, true);
    }

    private IList<IList<int>> Traverse(TreeNode root, IList<IList<int>> res, bool isLeftToRight)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Count > 0)
        {
            // This is something which is helping to maintain same queue and still able to distingues level nodes
            int size = q.Count;

            // Maintain an array to store the level nodes values to add in result List
            int[] levelArray = new int[size];
            
            for(int i=0; i<size; i++)
            {
                var node = q.Dequeue();

                if(isLeftToRight)
                {
                    levelArray[i] = node.data;
                }
                else
                {
                    levelArray[size-i-1] = node.data;
                }

                if(node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            isLeftToRight = !isLeftToRight;
            // Now one level has been completed. Add all the traversed array in the result list
            res.Add(levelArray.ToList());
        }

        return res;
    }
}