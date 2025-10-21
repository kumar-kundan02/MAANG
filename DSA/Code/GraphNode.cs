public class GraphNode
{
    public int Value { get; private set; }
    public List<GraphNode> Neighbors;

    public GraphNode(int value)
    {
        Value = value;
        Neighbors = new List<GraphNode>();
    }
}