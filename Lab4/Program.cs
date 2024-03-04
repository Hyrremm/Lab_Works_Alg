class Program
{
    public static void Main()
    {
        // Пример создания направленного графа
        GraphNode node1 = new GraphNode(1);
        GraphNode node2 = new GraphNode(2);
        GraphNode node3 = new GraphNode(3);
        GraphNode node4 = new GraphNode(4);
        node1.Connect(node2, true);
        node2.Connect(node3, true);
        node3.Connect(node4, true);
        node4.Connect(node2, false);
        node4.Connect(node1, true);
        List<GraphNode> nodes = [node1, node2, node3, node4];
        List<bool> visitedDFS = Enumerable.Repeat(false, nodes.Count).ToList();
        List<bool> visitedBFS = Enumerable.Repeat(false, nodes.Count).ToList();

        // Start DFS from node1
        Console.WriteLine("DFS:");
        DFS(node1, visitedDFS);

        // Start BFS from node1
        Console.WriteLine("BFS:");
        BFS(node1, visitedBFS);
        
        int sum = CalculateNeighborsSum(node1);
        Console.WriteLine("Sum of neighbors: " + sum);
    }

    public static void DFS(GraphNode node, List<bool> visited)
    {
        Console.WriteLine($"Visited node with value {node.Index}");
        visited[node.Index - 1] = true; 

        foreach (GraphNode neighbor in node.Neighbors)
        {
            if (!visited[neighbor.Index - 1])
            {
                DFS(neighbor, visited);
            }
        }
    }
    public static void BFS(GraphNode startNode, List<bool> visited)
    {
        Queue<GraphNode> queue = new Queue<GraphNode>();
        queue.Enqueue(startNode);
        visited[startNode.Index - 1] = true; 

        while (queue.Count > 0)
        {
            GraphNode current = queue.Dequeue();
            Console.WriteLine($"Visited node with value {current.Index}");

            foreach (GraphNode neighbor in current.Neighbors)
            {
                if (!visited[neighbor.Index - 1])
                {
                    visited[neighbor.Index - 1] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    public static int CalculateNeighborsSum(GraphNode node)
    {
        int sum = 0;

        foreach (GraphNode neighbor in node.Neighbors)
        {
            sum += neighbor.Index;
        }

        return sum;
    }
}

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