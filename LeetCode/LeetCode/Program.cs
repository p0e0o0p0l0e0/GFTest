using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _704.Solution sol = new _704.Solution();
        int[] nums = new int[] {2, 5 };
        int ret = sol.Search1(nums, 5);
        Console.WriteLine(ret);
    }
}