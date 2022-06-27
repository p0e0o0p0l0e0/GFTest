using _617;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new(); 
        TreeNode root1 = new TreeNode(1);
        root1.left = new TreeNode(3);
        root1.right = new TreeNode(2);
        root1.left.left = new TreeNode(5);

        TreeNode root2 = new TreeNode(2);
        root2.left = new TreeNode(1);
        root2.right = new TreeNode(3);
        root2.left.right = new TreeNode(4);
        root2.right.right = new TreeNode(7);

        TreeNode maxarea = sol.MergeTrees(root1, root2);
        treeDfs(maxarea);
    }

    public static void treeDfs(TreeNode root)
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