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
        // 迭代
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode prehead = new ListNode(-1);
            ListNode temp = prehead;

            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    temp.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    temp.next = list2;
                    list2 = list2.next;
                }
                temp = temp.next;
            }
            temp.next = list1 != null ? list1 : list2;
            return prehead.next;
        }

        // 递归 92ms 39.1MB 空间为m+n，因为递归占用栈空间，时间m+n
        public ListNode MergeTwoLists2(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }
            else if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists2(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists2(list1, list2.next);
                return list2;
            }
        }

        public ListNode MergeTwoLists1(ListNode list1, ListNode list2)
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