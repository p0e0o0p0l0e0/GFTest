using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _35.Solution sol = new _35.Solution();
        int[] nums = new int[] { 1, 3, 5, 6 };
        int target = 7;
        int ret = sol.SearchInsert(nums, target);
        Console.WriteLine(ret);
    }
}