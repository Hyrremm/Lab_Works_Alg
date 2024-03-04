using System.Reflection.Metadata.Ecma335;

namespace Lab3;

public class SinglyLinkedList<T> where T : IComparable<T>
{
   public class Node(T data)
   {
       public T Data { get; set; } = data;
       public Node? Next { get; set; }


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
            First = newNode;

            if (Last is null)
            {
                Last = newNode;
            }
        }
        else
        {
            newNode.Next = node.Next;
            node.Next = newNode;

            if (node == Last)
            {
                Last = newNode;
            }
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

    public void RemoveAfter(Node? node)
    {
        if (node is null)
        {
            if (First is not null)
            {
                First = First.Next;
                if (First is null)
                {
                    Last = null;
                }
            }
            else return;
        }
        else
        {
            if (node.Next is null) return;
            node.Next = node.Next.Next;
            if (node.Next is null) Last = node; 
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