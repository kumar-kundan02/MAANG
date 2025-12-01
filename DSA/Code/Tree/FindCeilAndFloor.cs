/*
Given a root of binary search tree and a key(node) value, find the floor and ceil value for that particular key value.

Floor Value Node: Node with the greatest data lesser than or equal to the key value. 
Ceil Value Node: Node with the smallest data larger than or equal to the key value.
If a particular floor or ceil value is not present then output -1.
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int data;
 *     public TreeNode left;
 *     public TreeNode right;
 *      public TreeNode(int val) {
 *          data = val;
 *          left = null;
 *          right = null;
 *      }
 * };
 **/

public class Solution {
    public List<int> FloorCeilOfBST(TreeNode root, int key) {
        // Approach: I need to find the floor and ceil separately
        // We need to keep moving untill encounter either exactly key or null

        List<int> res = new List<int>();
        int floor = -1, ceil = -1;
        TreeNode currentNode = root;

        // find floor
        while(currentNode != null)
        {
            if(currentNode.data == key)
            {
                floor = currentNode.data;
                break;
            }
            else if(key > currentNode.data)
            {
                floor = currentNode.data;
                currentNode = currentNode.right;
            }
            else
            {
                currentNode = currentNode.left;
            }
        }

        // Finding Ceil
        currentNode = root;
        while(currentNode != null)
        {
            if(currentNode.data == key)
            {
                ceil = currentNode.data;
                break;
            }
            else if(key < currentNode.data)
            {
                ceil = currentNode.data;
                currentNode = currentNode.left;
            }
            else
            {
                currentNode = currentNode.right;
            }
        }

        res.Add(floor);
        res.Add(ceil);

        return res;
    }
}
