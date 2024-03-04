namespace Lab2_2.Algorithms;

public class BinarySearchTree<T> where T : IComparable<T>
{
   
    private Node? _root;
    public int Size { get; private set; } = 0;

    public void Add(T value)
    {
        if (_root is null)
            _root = new Node(value);
        else AddRecursively(_root, value);
        Size++;
    }

    private void AddRecursively(Node node, T value)
    {
        int result = value.CompareTo(node.Data);
        if (result < 0)
        {
            if (node.LeftNode == null) node.LeftNode = new Node(value);
            else AddRecursively(node.LeftNode,value);
        }
        else
        {
            if (node.RightNode == null) node.RightNode = new Node(value);
            else AddRecursively(node.RightNode,value);
        }
    }

    public Node? Search(T value)
    {
        if (_root is null)
            return null;
        return SearchRecursively(_root, value);
    }

    public Node? SearchRecursively(Node? node, T value)
    {
        int result = value.CompareTo(node!.Data);
        if (result == 0) return node;
        if (result < 0)
        {
            if (node.LeftNode == null) return null;
            return SearchRecursively(node.LeftNode, value);
        }
        else
        {
            if (node.RightNode == null) return null;
            return SearchRecursively(node.RightNode, value);
        }
    }
    public void PutValuesIntoBinaryTree(T[] arr) 
    {
        foreach (var value in arr)
        {
            this.Add(value);
        }
    }
    private void PrintTree(Node? node)
    {
        if (node is not null)
        {
            PrintTree(node.LeftNode);
            Console.Write(node.Data + " ");
            PrintTree(node.RightNode);
        }
    }
    public void PrintTree()
    {
        PrintTree(_root);
        Console.WriteLine();
    }
    public class Node(T data)
    {
        public T Data { get; init; } = data;
        public Node? LeftNode { get; set; } = null;
        public Node? RightNode { get; set; } = null;
    }

}