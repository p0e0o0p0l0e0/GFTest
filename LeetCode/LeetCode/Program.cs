using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _283.Solution sol = new _283.Solution();
        int[] nums = new int[] {2};
        sol.MoveZeroes(nums);
        int[] ret = nums;
        for(int i = 0; i < ret.Length; i++)
        {
            Console.Write(ret[i]);
            Console.Write("    ");
        }
    }
}