using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _167.Solution sol = new _167.Solution();
        int[] nums = new int[] {2};
        int[] ret = sol.TwoSums2(nums, 4);
        //int[] ret = nums;
        for(int i = 0; i < ret.Length; i++)
        {
            Console.Write(ret[i]);
            Console.Write("    ");
        }
    }
}