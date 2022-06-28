using _542;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        sol.UpdateMatrix1(new int[][] { 
            new int[] { 0, 0, 0}, 
            new int[] { 0, 1, 0}, 
            new int[] { 0, 0, 0}, 
        });
    }
}