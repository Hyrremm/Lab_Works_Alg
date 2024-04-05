// Test Queue
Console.WriteLine("Testing Queue:");
Queue<int> queue = new Queue<int>();

Console.WriteLine($"Is Queue empty? {queue.IsEmpty()}"); 
Console.WriteLine("Adding values 1 and 2");
queue.Enqueue(1);
queue.Enqueue(2);
Console.WriteLine($"Is Queue empty? {queue.IsEmpty()}"); 
Console.WriteLine($"Front of Queue: {queue.Front()}"); 

queue.Dequeue();
Console.WriteLine($"Front of Queue after Dequeue: {queue.Front()}"); 

Console.WriteLine();

// Test DynamicArrayQueue
Console.WriteLine("Testing DynamicArrayQueue:");
DynamicArrayQueue<string> dynamicQueue = new DynamicArrayQueue<string>();

Console.WriteLine($"Is DynamicArrayQueue empty? {dynamicQueue.IsEmpty()}");
Console.WriteLine("Adding values apple and banana");
dynamicQueue.Enqueue("apple");
dynamicQueue.Enqueue("banana");
Console.WriteLine($"Is Queue empty? {queue.IsEmpty()}"); 
Console.WriteLine($"Front of DynamicArrayQueue: {dynamicQueue.Front()}"); 

dynamicQueue.Dequeue();
Console.WriteLine($"Front of DynamicArrayQueue after Dequeue: {dynamicQueue.Front()}"); 

Console.WriteLine();

// Test Stack
Console.WriteLine("Testing Stack:");
Stack<double> stack = new Stack<double>();

Console.WriteLine($"Is Stack empty? {stack.IsEmpty()}"); 
Console.WriteLine("Adding values 3.5 and 2.5");
stack.Push(3.5);
stack.Push(2.5);
Console.WriteLine($"Is Stack empty? {stack.IsEmpty()}"); 
Console.WriteLine($"Last element in Stack: {stack.GetLastElement()}"); 

stack.Pop();
Console.WriteLine($"Last element in Stack after Pop: {stack.GetLastElement()}");


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
        return items[0];
    }

    public void Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        items.RemoveAt(0);
    }
}
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