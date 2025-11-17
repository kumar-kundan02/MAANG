/*
Given a root of Binary Tree, perform the boundary traversal of the tree. 

The boundary traversal is the process of visiting the boundary nodes of the binary tree in the anticlockwise direction, starting from the root.

The boundary of a binary tree is the concatenation of the root, the left boundary, the leaves ordered from left-to-right, and the reverse order of the right boundary.

The left boundary is the set of nodes defined by the following:

The root node's left child is in the left boundary. If the root does not have a left child, then the left boundary is empty.

If a node in the left boundary and has a left child, then the left child is in the left boundary.

If a node is in the left boundary, has no left child, but has a right child, then the right child is in the left boundary.

The leftmost leaf is not in the left boundary.

The right boundary is similar to the left boundary, except it is the right side of the root's right subtree. Again, the leaf is not part of the right boundary, and the right boundary is empty if the root does not have a right child.
*/

public class Solution {
    public List<int> Boundary(TreeNode root) {
        // 1. Add LeftBoundary
        // 2. Add Leaf Nodes for left subtree
        // 3. Add Leaf Nodes for right subtree
        // 4. Add RightBoundary

        List<int> res = new List<int>();

        // Checking if given root node is null then simply return empty list
        if(root == null) return res;

        res.Add(root.data);
        // Checking if rootNode is leafNode then we need to return the rootNode value only
        if(root.left == null && root.right == null) return res;

        AddLeftBoundary(root, res);
        AddLeafNodes(root, res);
        AddRightBoundary(root, res);

        return res;
    }

    private void AddLeafNodes(TreeNode root, List<int> res)
    {
        if(root.left == null && root.right == null)
        {
            res.Add(root.data);
            return;
        }

        if(root.left != null)
            AddLeafNodes(root.left, res);
        if(root.right != null)
            AddLeafNodes(root.right, res);
    }

    private void AddLeftBoundary(TreeNode root, List<int> res)
    {
        if(root.left == null) return;

        TreeNode curr = root.left;
        // res.Add(curr.data);

        while(curr.left != null || curr.right != null)
        {
            if(curr.left != null)
            {
                res.Add(curr.data);
                curr = curr.left;
            }
            else if(curr.right != null)
            {
                res.Add(curr.data);
                curr = curr.right;
            }
        }
    }

    private void AddRightBoundary(TreeNode root, List<int> res)
    {
        if(root.right == null) return;

        TreeNode curr = root.right;
        List<int> temp = new List<int>();

        while(curr.left != null || curr.right != null)
        {
            if(curr.right != null)
            {
                temp.Add(curr.data);
                curr = curr.right;
            }
            else if(curr.left != null)
            {
                temp.Add(curr.data);
                curr = curr.left;          
            }
        }

        for(int i=temp.Count-1; i>=0; i--)
        {
            res.Add(temp[i]);
        }

    }
}