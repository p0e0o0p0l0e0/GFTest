namespace _21// 21. 合并两个有序链表
{
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
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode list = new ListNode(0);
            Recursive(list, list1, list2);
            return list.next;
        }

        // 100ms 38.8MB 新建一个链表，递归遍历两个非递减链表获取最小的值赋给新链表
        public void Recursive(ListNode list, ListNode list1, ListNode list2)
        {
            if (list2 == null)
            {
                list.next = list1;
            }
            else if (list1 == null)
            {
                list.next = list2;
            }
            else
            {
                if (list1.val < list2.val)
                {
                    list.next = list1;
                    Recursive(list.next, list1.next, list2);
                }
                else
                {
                    list.next = list2;
                    Recursive(list.next, list1, list2.next);
                }
            }
        }
    }
}