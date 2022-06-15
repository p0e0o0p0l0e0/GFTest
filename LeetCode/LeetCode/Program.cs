using _876;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _876.Solution sol = new _876.Solution();
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
        ListNode middle = sol.MiddleNode1(head);
        while (middle != null)
        {
            Console.Write(middle.val);
            Console.Write("    ");
            middle = middle.next;
        }
    }
}