using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _695.Solution sol = new();
        int[][] array = {
            new int[]{ 1, 1, 0, 0, 0 },
            new int[]{ 1, 1, 0, 0, 0 },
            new int[]{ 0, 0, 0, 1, 1 },
            new int[]{ 0, 0, 0, 1, 1 },
        };
        int maxarea = sol.MaxAreaOfIsland_BFS(array);
        Console.WriteLine(maxarea);
    }
}