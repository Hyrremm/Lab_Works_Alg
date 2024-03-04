
namespace Lab3;

public class DoublyLinkedList<T> where T : IComparable<T>
{
   public class Node(T data)
   {
       public T Data { get; set; } = data;
       public Node? Next { get; set; }
       public Node? Previous { get; set; }


   }

    public Node? First { get; set; }
    public Node? Last { get; set; }
    public int Count { get;  set; }


    public Node InsertAfter(Node? node, T value)
    {
        Node newNode = new Node(value);

        if (node is null)
        {
            newNode.Next = First;
            newNode.Previous = null;

            if (First is not null)
            {
                First.Previous = newNode;
            }
            First = newNode;

            if (Last is null)
            {
                Last = newNode;
            }
        }
        else
        {
            newNode.Next = node.Next;
            newNode.Previous = node;

            if (node.Next is not null)
            {
                node.Next.Previous = newNode;
            }
            else
            {
                Last = newNode;
            }

            node.Next = newNode;
        }

        Count++;
        return newNode;
    }

    public Node InsertBefore(Node? node, T value)
    {
        Node newNode = new Node(value);

        if (node is null)
        {
            newNode.Next = First;
            newNode.Previous = null;

            if (First is not null)
            {
                First.Previous = newNode;
            }
            First = newNode;

            if (Last is null)
            {
                Last = newNode;
            }
        }
        else
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;

            if (node.Previous is not null)
            {
                node.Previous.Next = newNode;
            }
            else
            {
                First = newNode;
            }

            node.Previous = newNode;
        }

        Count++;
        return newNode;
    }
    public (Node?, Node?) Find(T value)
    {
        Node? current = First;
        Node? previous = null;
        
        while (current != null)
        {
            if (current.Data.CompareTo(value)==0)
            {
                return (previous, current);
            }
            previous = current;
            current = current.Next;
        }

        return (null, null);
    }

    public void Remove(Node? node)
    {
        if (node is null)
            return;

        if (node == First)
        {
            First = node.Next;
        }
        else
        {
            node.Previous!.Next = node.Next;
        }

        if (node == Last)
        {
            Last = node.Previous;
        }
        else
        {
            node.Next!.Previous = node.Previous;
        }

        Count--;
    }
    public bool AssertNoCycles()
    {
        Node? current = First;
        int innerCount = 0;
        while (current != null)
        {
            Console.WriteLine("assert no cycles current - " +current.Data);
            innerCount++;
            if (innerCount > Count) return false;
            current = current.Next;
        }

        return true;
    }

    public void PrintAll()
    {
        Node? current = First;
        while (current is not null)
        {
            Console.Write(current.Data+" ");
            current = current.Next;
        }

        Console.WriteLine();
    }


}