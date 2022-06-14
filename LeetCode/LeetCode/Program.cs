using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _557.Solution sol = new _557.Solution();
        int[] nums = new int[] {2};
        string s = sol.ReverseWords("contest");
        Console.WriteLine(s);
        //int[] ret = nums;
        //for(int i = 0; i < ret.Length; i++)
        //{
        //    Console.Write(ret[i]);
        //    Console.Write("    ");
        //}
    }
}