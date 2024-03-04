using Lab3;

class Program
{
    public static void Main()
    {
        SinglyLinkedList<int> list = new();
        list.InsertAfter(null, 40);
        list.InsertAfter(list.Last, 43);
        list.InsertAfter(list.Last, 42433);
        list.InsertAfter(list.Last, 431253);
        list.InsertAfter(list.Last, 4343);
        list.InsertAfter(list.Last, 43123);
        Console.WriteLine("Printing all elements");
        list.PrintAll();
        (SinglyLinkedList<int>.Node foundPrev,SinglyLinkedList<int>.Node foundCur) = list.Find(43123);
        Console.WriteLine("found prev - "+(foundPrev?.Data.ToString() ?? "none") +" found cur "+ (foundCur?.Data.ToString() ?? "none"));
        //Check if there are cycles
        if(list.AssertNoCycles()) Console.WriteLine("There are no cycles");
        else Console.WriteLine("There are cycles");
        // Make a cycle
        list.Find(431253).Item2.Next = list.Find(43).Item2;
        list.Count++;
        //Check 
        if(list.AssertNoCycles()) Console.WriteLine("There are no cycles");
        else Console.WriteLine("There are cycles");


    }
}