using System;

namespace _876
{//双指针：
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null)
        {
          this.val = val;
          this.next = next;
        }
  }
 
    public class Solution
    {
        // 76ms 37.1MB
        // 快慢指针：count记录向后移的个数，偶数时centerPointer向后移动一位。时间复杂度O(n)，空间复杂度O(1)
        public ListNode MiddleNode(ListNode head)
        {
            int count = 0;
            ListNode slow = head, fast = head;
            while(fast.next != null)
            {
                count++;
                fast = fast.next;
                if((count + 1) % 2 == 0)
                {
                    slow = slow.next;
                }
            }
            return slow;
        }

        // 思路与时长同上，写法更简洁
        public ListNode MiddleNode1(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }
}
