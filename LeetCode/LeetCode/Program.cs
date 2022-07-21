using _77;
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        IList<IList<int>> list = sol.Combine(4, 2);
        Console.WriteLine("End!");
    }
}