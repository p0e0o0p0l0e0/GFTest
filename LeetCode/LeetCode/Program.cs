using _784;
using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        IList<string> list = sol.LetterCasePermutation("a1b2");
        Console.WriteLine("End!");
    }
}