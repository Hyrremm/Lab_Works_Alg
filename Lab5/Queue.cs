class Queue<T>
{
    private LinkedList<T> items = new LinkedList<T>();

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void Enqueue(T value)
    {
        items.AddLast(value);
    }

    public T Front()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return items.First.Value;
    }

    public void Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        items.RemoveFirst();
    }
}