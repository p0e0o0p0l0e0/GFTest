using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _189.Solution sol = new _189.Solution();
        int[] nums = new int[] {-1};
        int[] ret = sol.Rotate(nums, 2);
        for(int i = 0; i < ret.Length; i++)
        {
            Console.Write(ret[i]);
            Console.Write("    ");
        }
    }
}