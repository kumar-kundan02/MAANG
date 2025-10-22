public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return node;
        Dictionary<int, Node> map = new Dictionary<int, Node>();
        CloneNodes(node, map);
        return map[1];
        
    }
    
    private void CloneNodes(Node node, Dictionary<int, Node> map)
    {
        Node newNode = new Node(node.val);
        newNode.neighbors = new List<Node>();
        
        map.Add(newNode.val, newNode);
        foreach(Node n in node.neighbors)
        {
            if(!map.ContainsKey(n.val))
                CloneNodes(n,map);
            newNode.neighbors.Add(map[n.val]);
            
        }
    }
}