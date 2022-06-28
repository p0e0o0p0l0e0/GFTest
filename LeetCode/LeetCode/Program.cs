using _116;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        Node root = new Node(1, new Node(2, new Node(4), new Node(5), null), new Node(3, new Node(6), new Node(7), null), null);
        sol.Connect1(root);
    }

    public static void treeDfs(Node root)
    {
        if (root == null)
        {
            return;
        }
        Console.Write(root.val + " ");
        treeDfs(root.left);
        treeDfs(root.right);
    }
}