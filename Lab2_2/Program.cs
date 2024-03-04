using System.Diagnostics;
using System.Reflection;
using Lab2_2.Algorithms;
using static Lab2_2.Algorithms.AlgorithmsSpace;

class Program{

    public static void Main()
    {
        const int numOfTries = 10;
        const int arrLength = 1_000_000;
        int[] unsortedArray = GenerateUnSortedArray(arrLength);
        int[] sortedArray = GenerateSortedArray(arrLength);
        int[] reversedArray = new int[sortedArray.Length];
        Array.Copy(sortedArray, reversedArray, sortedArray.Length);
        Array.Reverse(reversedArray);
        BinarySearchTree<int> binarySearchTree = new();
        
        WarmUp();   
        
        Stopwatch stopwatch = new();
        stopwatch.Start();
        binarySearchTree.PutValuesIntoBinaryTree(unsortedArray);
        stopwatch.Stop();
        Console.WriteLine($"Time to put values into binary tree = {stopwatch.Elapsed.TotalMicroseconds} MICROSECONDS");
// Console.WriteLine("unsorted \n"+string.Join(" ",unsortedArray));
// Console.WriteLine("sorted \n"+string.Join(" ",sortedArray));
// Console.WriteLine("BinarySearchTree");
            // binarySearchTree.PrintTree();
        TimeSpan linearSum = TimeSpan.Zero;
        for (int i = 0; i < numOfTries; i++)
        {
            if(i%2==0) linearSum+= DetermineTimeOfSearchAlgorithm(LinearSearch,unsortedArray,false);
            else linearSum+= DetermineTimeOfSearchAlgorithm(LinearSearch,unsortedArray,true);
        }

        Console.WriteLine($"Average time for LinearSearch with length {arrLength} == {(linearSum/numOfTries).TotalMicroseconds} MICROSECONDS");
        TimeSpan binarySum = TimeSpan.Zero;
        for (int i = 0; i < numOfTries; i++)
        {
            if(i%2==0) binarySum+= DetermineTimeOfSearchAlgorithm(BinarySearch,sortedArray,false);
            else binarySum+= DetermineTimeOfSearchAlgorithm(BinarySearch,sortedArray,true);        }
        Console.WriteLine($"Average time for BinarySearch with length {arrLength} == {(binarySum/numOfTries).TotalMicroseconds} MICROSECONDS");

        TimeSpan jumpSum = TimeSpan.Zero;
        for (int i = 0; i < numOfTries; i++)
        {
            if(i%2==0) jumpSum+= DetermineTimeOfSearchAlgorithm(JumpSearch,sortedArray,false);
            else jumpSum+= DetermineTimeOfSearchAlgorithm(JumpSearch,sortedArray,true);        }
        Console.WriteLine($"Average time for JumpSearch with length {arrLength} == {(jumpSum/numOfTries).TotalMicroseconds} MICROSECONDS");

        TimeSpan binaryTreeSum = TimeSpan.Zero;
        for (int i = 0; i < numOfTries; i++)
        {
            binaryTreeSum+= DetermineTimeOfSearchAlgorithm(binarySearchTree,unsortedArray);
        }
        Console.WriteLine($"Average time for BinaryTreeSearch with length {arrLength} == {(binaryTreeSum/numOfTries).TotalMicroseconds} MICROSECONDS");

    }


static TimeSpan DetermineTimeOfSearchAlgorithm<T>(Func<T[],T,bool,int> Search,T[] arr,bool reversed=false)
{
    Random random = new();
    int value = random.Next(0, arr.Length);
    Stopwatch stopwatch = new();
    stopwatch.Start();
    int answer = Search(arr, arr[value], reversed);
    stopwatch.Stop();
    // Console.WriteLine($"Time spent doing {Search.GetMethodInfo().Name} : {stopwatch.Elapsed.ToString("g")} index - {answer}");
    return stopwatch.Elapsed;
   

}


static TimeSpan DetermineTimeOfSearchAlgorithmManual<T>(Func<T[],T,bool,int> Search,T[] arr,T value,bool reversed=false)
{
    Stopwatch stopwatch = new();
    stopwatch.Start();
    int answer = Search(arr, value,reversed);
    stopwatch.Stop();
    // Console.WriteLine($"Time spent doing {Search.GetMethodInfo().Name} : {stopwatch.Elapsed.ToString("g")} index - {answer}");
    return stopwatch.Elapsed;
}

static TimeSpan DetermineTimeOfSearchAlgorithm<T>(BinarySearchTree<T> binarySearchTree,T[] arr) where T : IComparable<T>
{
    Random random = new();
    int value = random.Next(0, binarySearchTree.Size);
    Stopwatch stopwatch = new();
    stopwatch.Start();
    BinarySearchTree<T>.Node? answer = binarySearchTree.Search(arr[value]);
    stopwatch.Stop();
    // Console.WriteLine($"Time spent doing binary tree search : {stopwatch.Elapsed.ToString("g")} value - {answer.Data}");
    return stopwatch.Elapsed;
}
static TimeSpan DetermineTimeOfSearchAlgorithmManual<T>(BinarySearchTree<T> binarySearchTree,T value) where T : IComparable<T>
{
    Stopwatch stopwatch = new();
    stopwatch.Start();
    BinarySearchTree<T>.Node? answer = binarySearchTree.Search(value);
    stopwatch.Stop();
    // Console.WriteLine($"Time spent doing binary tree search : {stopwatch.Elapsed.ToString("g")} value - {answer.Data}");
    return stopwatch.Elapsed;
}

static void WarmUp() 
{
    int[] arr = [1, 2, 3];
    BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
    binarySearchTree.PutValuesIntoBinaryTree(arr);
    LinearSearch(arr, arr[0],false);
    BinarySearch(arr, arr[0],false);
    JumpSearch(arr, arr[0],false);
    LinearSearch(arr, arr[0],true);
    BinarySearch(arr, arr[0],true);
    JumpSearch(arr, arr[0],true);
    
    binarySearchTree.Search(arr[0]);

}

static int[] GenerateUnSortedArray(int len)
{
    Random random = new Random();
    HashSet<int> unorderedSet = new HashSet<int>(len);
    while (unorderedSet.Count != len)
    {
        unorderedSet.Add(random.Next()%(len*10));
    }

    return unorderedSet.ToArray();
}
static int[] GenerateSortedArray(int len)
{
    Random random = new Random();
    SortedSet<int> unorderedSet = new SortedSet<int>();
    while (unorderedSet.Count != len)
    {
        unorderedSet.Add(random.Next()%(len*10));
    }
    return unorderedSet.ToArray();
}
}