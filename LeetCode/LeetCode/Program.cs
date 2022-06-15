using _19;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        _19.Solution sol = new _19.Solution();
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
        ListNode middle = sol.RemoveNthFromEnd1(head, 1);
        while (middle != null)
        {
            Console.Write(middle.val);
            Console.Write("    ");
            middle = middle.next;
        }
    }
}