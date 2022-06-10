using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _977.Solution sol = new _977.Solution();
        int[] nums = new int[] {-3, -3, -2, 1};
        int[] ret = sol.SortedSquares(nums);
        for(int i = 0; i < ret.Length; i++)
        {
            Console.Write(ret[i]);
            Console.Write("    ");
        }
    }
}