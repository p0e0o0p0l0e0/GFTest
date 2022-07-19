using _994;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        int min = sol.OrangesRotting(new int[][] { 
            new int[] { 2, 1, 1}, 
            new int[] { 1, 1, 0}, 
            new int[] { 0, 1, 1}, 
        });
    }
}