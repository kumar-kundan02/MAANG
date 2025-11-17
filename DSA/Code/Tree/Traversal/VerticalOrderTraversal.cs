/*
Compute the binary tree's vertical order traversal given its root.

The left and right children of a node at location (row, col) will be at (row + 1, col - 1) and (row + 1, col + 1), respectively. The tree's root is located at (0, 0).

The vertical order traversal of a binary tree is a list of top-to-bottom orderings for each column index starting from the leftmost column and ending on the rightmost column. There may be multiple nodes in the same row and same column. In such a case, sort these nodes by their values. Return the binary tree's vertical order traversal.
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
public class Solution
{
    public IList<IList<int>> VerticalTraversal(TreeNode root)
    {
         var res = new List<IList<int>>();
        if (root == null) return res;

        // SortedDictionary: column -> List of (row, value) as Tuple<int, int>
        var dict = new SortedDictionary<int, List<Tuple<int, int>>>();

        Traverse(root, 0, 0, dict);

        foreach (var key in dict.Keys)
        {
            // Sort by row, then value
            var sorted = dict[key]
                .OrderBy(x => x.Item1) // Item1 is row
                .ThenBy(x => x.Item2)  // Item2 is value
                .Select(x => x.Item2)  // Select the value
                .ToList();
            res.Add(sorted);
        }

        return res;
    }

    private void Traverse(TreeNode node, int row, int col, SortedDictionary<int, List<Tuple<int, int>>> dict)
    {
        if (node == null) return;
        if (!dict.ContainsKey(col))
        {
            dict[col] = new List<Tuple<int, int>>();
        }
        dict[col].Add(Tuple.Create(row, node.val));

        Traverse(node.left, row + 1, col - 1, dict);
        Traverse(node.right, row + 1, col + 1, dict);
    }
}