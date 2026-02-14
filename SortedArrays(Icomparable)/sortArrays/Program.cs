using System.Collections.Generic;
using System;
class Program
{
    public static void Main(string[] args)
    {
        int[] arr1 = {1, 3, 5, 7};
        int[] arr2 = {2, 4, 6};
        int[] result = Merge.MergeSortedArrays(arr1, arr2);
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write($"{result[i]}");
        }
        Console.WriteLine();
    }
}
class Merge
{
    public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
    {
        int i = 0, j = 0, k =0;
        T[] merged =new T[a.Length + b.Length];
        while (i < a.Length && j < b.Length)
        {
            if(a[i].CompareTo(b[j]) <= 0)
            {
                merged[k++] = a[i++];
            }
            else
            {
                merged[k++] = b[j++];
            }
        }
        while(i < a.Length)
        {
            merged[k++] = a[i++];
        }
        while(j < b.Length)
        {
            merged[k++] = b[j++];
        }
        return merged;
    }
}