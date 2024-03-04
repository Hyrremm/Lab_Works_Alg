namespace Lab3;

public class Queue<T>
{
    private class Node(T data)
    {
        public T Value = data;
        public Node? Next;
    }

    private Node? _front;
    private Node? _rear;

    public void Enqueue(T value)
    {
        Node newNode = new Node(value);

        if (_rear == null)
        {
            _front = _rear = newNode;
        }
        else
        {
            _rear.Next = newNode;
            _rear = newNode;
        }
    }

    public void PrintAll()
    {
        Node current = _front;
        while (current != null)
        {
            Console.Write($"{current.Value} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T value = _front.Value;
        _front = _front.Next;

        if (_front == null)
        {
            _rear = null;
        }

        return value;
    }

    public bool IsEmpty()
    {
        return _front == null;
    }
}