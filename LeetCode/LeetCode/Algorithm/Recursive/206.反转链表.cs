namespace _206// 206. 反转链表
{
    using System.Collections.Generic;

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        // 76ms 38.2MB 迭代 时间n，空间1
        public ListNode ReverseList2(ListNode head)
        {
            ListNode pre = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode list = curr.next;
                curr.next = pre;
                pre = curr;
                curr = list;
            }
            return pre;
        }

        // 96ms 38.2MB 官方递归
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode ret = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return ret;
        }

        private ListNode result = null;

        //76ms 38.3MB 递归 时间n 空间n（栈空间）
        public ListNode ReverseList1(ListNode head)
        {
            if (head == null)
                return null;
            Recursive(head);
            head.next = null;
            return result;
        }

        public ListNode Recursive(ListNode head)
        {
            if (head != null)
            {
                ListNode list = Recursive(head.next);
                if (list != null)
                {
                    list.next = head;
                    return head;
                }
                result = head; // 最后一个节点
                return head;
            }
            return null;
        }

        //100ms 38.2MB 用Stack存一下再pop出来就是反转的了
        public ListNode ReverseList_Stack(ListNode head)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            while (head != null)
            {
                stack.Push(head);
                head = head.next;
            }
            ListNode list = new ListNode(-1);
            ListNode temp = list;
            while (stack.Count > 0)
            {
                temp.next = stack.Pop();
                temp = temp.next;
            }
            temp.next = null;
            return list.next;
        }
    }
}