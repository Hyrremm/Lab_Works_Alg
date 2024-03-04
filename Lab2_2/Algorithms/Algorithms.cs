namespace Lab2_2.Algorithms;

public static class AlgorithmsSpace
{
    
    public static int LinearSearch<T>(T[] arr, T value, bool reversed = false) where T : IComparable<T>
    {
        if (reversed)
        {
            for (int i = 1; i <= arr.Length; i++)
            {
                if (arr[^i].CompareTo(value) == 0) return arr.Length - i;
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(value) == 0) return i;
        }
        return -1;
    }
    public static int BinarySearch<T>(T[] arr, T value,bool reversed=false) where T : IComparable<T>
    {
        int low = 0;
        int high = arr.Length - 1;
        Func<T, T, int> comparer = reversed ? (a, b) => b.CompareTo(a) : (a, b) => a.CompareTo(b);

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int comparisonResult = comparer(value, arr[mid]);

            if (comparisonResult == 0)
            {
                return mid; 
            }
            if (comparisonResult < 0)
            {
                high = mid - 1; 
            }
            else
            {
                low = mid + 1; 
            }
        }
        return -1; 
    }
    public static int JumpSearch<T>(T[] arr, T x, bool reversed = false) where T : IComparable<T>
    {
        // init
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);

        // search
        int prev = 0;
        int jumpIndex = step;
        Func<T, T, int> comparer = reversed ? (a, b) => b.CompareTo(a) : (a, b) => a.CompareTo(b);

        while (comparer(arr[Math.Min(jumpIndex, n) - 1], x) == -1)
        {
            prev = jumpIndex;
            jumpIndex += step;
            if (prev >= n) return -1;
        }

        for (int i = prev; i < jumpIndex; i++)
        {
            if (comparer(arr[i], x) == 0) return i;
        }
        return -1;
    }


}