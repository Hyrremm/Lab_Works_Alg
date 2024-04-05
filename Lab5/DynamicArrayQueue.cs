class DynamicArrayQueue<T>
{
    private List<T> items = new();

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void Enqueue(T value)
    {
        items.Add(value);
    }

    public T Front()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return items.Last();
    }

    public void Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        items.RemoveAt(items.Count-1);
    }
}