namespace _19 //19. 删除链表的倒数第N个结点
{//双指针：
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
        // 80ms 38.2MB
        // 快慢指针：fast先向后移动，当slow和fast间距等于n时同时向后移动。时间复杂度O(n)，空间复杂度O(1)
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode slow = null, fast = head;
            int count = 0;
            while (fast != null)
            {
                if (count >= n)
                {
                    if (slow == null)
                    {
                        slow = head;
                    }
                    else
                    {
                        slow = slow.next;
                    }
                }
                count++;
                fast = fast.next;
            }
            if (slow != null && slow.next != null)
            {
                slow.next = slow.next.next;
            }
            else if (slow == null && n == count)
            {// 如果slow是空说明n>=count，相等则说明刚好要删除第一个节点
                head = head.next;
            }
            return head;
        }

        // 84ms, 37.8MB
        // 递归链表，可以倒叙计算cur，与n相等时返回head.next
        private int cur = 0;

        public ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            if (head == null)
                return null;
            head.next = RemoveNthFromEnd1(head.next, n);
            cur++;
            if (cur == n)
                return head.next;
            return head;
        }
    }
}