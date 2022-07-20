using _206;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Solution sol = new();
        ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        ListNode list = sol.ReverseList(list1);
        PrintListNode(list);
        
    }
    private static void PrintListNode(ListNode list)
    {
        if(list != null)
        {
            Console.WriteLine(list.val);
            PrintListNode(list.next);
        }
    }
}