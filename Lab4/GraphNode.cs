public class GraphNode
{
    public int Index { get; set; }
    public List<GraphNode> Neighbors { get; set; }

    public GraphNode(int value)
    {
        Index = value;
        Neighbors = new List<GraphNode>();
    }


    public GraphNode Connect(GraphNode to,bool directed = false)
    {
        this.Neighbors.Add(to);
        if(!directed) to.Neighbors.Add(this);
        return this;
    }
}