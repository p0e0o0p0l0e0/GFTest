using System;

internal class Program
{
    static string s1 = "ab";
    static string s2 = "sdfabdc";

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _733.Solution sol = new _733.Solution();
        int[][] array = { new int[3]{ 1, 1, 1 }, new int[3]{ 1, 1, 0 }, new int[3]{ 1, 0, 1 } };
        int[][] image = sol.FloodFill(array, 1, 1, 2);
        for(int i = 0; i < image.GetLength(0); i++)
        {
            for(int j = 0; j < image[i].GetLength(0); j++)
            {
                Console.Write(image[i][j]);
            }
            Console.WriteLine();

        }
    }
}