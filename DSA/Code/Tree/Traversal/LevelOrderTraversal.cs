// Approach 1: Using BFS and Tuple (level, Node) in Queue 

public class Solution
{
    public IList<IList<int>> levelOrder(TreeNode root)
    {
        //your code goes here

        IList<IList<int>> res = new List<IList<int>>();

        if (root == null) return res;

        Queue<(int, TreeNode)> q = new Queue<(int, TreeNode)>();

        q.Enqueue((0, root));


        while (q.Count > 0)
        {
            var node = q.Dequeue();

            if (node.Item1 >= res.Count)
            {
                res.Add(new List<int>());
            }

            res[node.Item1].Add(node.Item2.data);

            if (node.Item2.left != null)
            {
                q.Enqueue((node.Item1 + 1, node.Item2.left));
                // res[node.item1].Add(node.item2.left.data);
            }

            if (node.Item2.right != null)
            {
                q.Enqueue((node.Item1 + 1, node.Item2.right));
                // res[node.item1].Add(node.item2.right.data);
            }
        }

        return res;
    }
}

// Approach 2: Recursive 

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        
        IList<IList<int>> res = new List<IList<int>>();
        Traverse(root, res, 1);
        return res;
    }

    private void Traverse(TreeNode node, IList<IList<int>> result, int level)
    {
        if(node == null)
            return;
        
        if(result.Count < level)
        {
            result.Add(new List<int>());
        }
        result[level-1].Add(node.data);
        Traverse(node.left, result, level+1);
        Traverse(node.right, result, level+1);
    }
}