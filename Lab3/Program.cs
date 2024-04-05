using Lab3;
using Queue = Lab3.Queue<int>;

class Program
{
    public static void Main()
    {
        CheckSingleLinkedList();
        CheckDoubleLinkedList();
        CheckQueue();
    }

    public static void CheckSingleLinkedList()
    {
        Console.WriteLine("Check Single Linked List");
        SinglyLinkedList<int> listSingle = new();
        listSingle.InsertAfter(null, 40);
        listSingle.InsertAfter(listSingle.Last, 43);
        listSingle.InsertAfter(listSingle.Last, 42433);
        listSingle.InsertAfter(listSingle.Last, 431253);
        listSingle.InsertAfter(listSingle.Last, 4343);
        listSingle.InsertAfter(listSingle.Last, 43123);
        Console.WriteLine("Printing all elements");
        listSingle.PrintAll();
        (SinglyLinkedList<int>.Node foundPrev,SinglyLinkedList<int>.Node foundCur) = listSingle.Find(43123);
        Console.WriteLine("found prev - "+(foundPrev?.Data.ToString() ?? "none") +" found cur "+ (foundCur?.Data.ToString() ?? "none"));
        // Removing element
        Console.WriteLine("Removing element");
        listSingle.RemoveAfter(listSingle.Find(431253).Item2);
        listSingle.PrintAll();
        //Check if there are cycles
        if(listSingle.AssertNoCycles()) Console.WriteLine("There are no cycles");
        else Console.WriteLine("There are cycles");
        // Make a cycle
        listSingle.Find(431253).Item2.Next = listSingle.Find(43).Item2;
        //Check 
        if(listSingle.AssertNoCycles()) Console.WriteLine("There are no cycles");
        else Console.WriteLine("There are cycles");

    }

    public static void CheckDoubleLinkedList()
    {
        Console.WriteLine("Check Double Linked List");
        DoublyLinkedList<int> listDouble = new();
        listDouble.InsertBefore(null,43);
        listDouble.InsertBefore(listDouble.First,45);
        listDouble.InsertBefore(listDouble.First,46);
        listDouble.InsertBefore(listDouble.First,47);
        listDouble.InsertBefore(listDouble.First,49);
        //Removing Elements
        Console.WriteLine("Printing all elements");
        listDouble.PrintAll();
        listDouble.Remove(listDouble.Find(46).Item2);
        listDouble.Remove(listDouble.Find(49).Item2);
        Console.WriteLine("After removing 2 elements");
        listDouble.PrintAll();
    }

    public static void CheckQueue()
    {
        Console.WriteLine("Check Queue");
        Queue queue = new();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(5);
        Console.WriteLine("Printing queue");
        queue.PrintAll();

        Console.WriteLine("Dequeuing Test:");
        while (!queue.IsEmpty())
        {
            Console.WriteLine(queue.Dequeue());
        }

        Console.WriteLine("Queue is empty");
    }

}