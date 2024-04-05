class Stack<T>
{
    private LinkedList<T> items = new();

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void Push(T value)
    {
        items.AddLast(value);

    }

    public T GetLastElement()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        return items.Last.Value;
    }

    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        items.RemoveLast();
    }
}