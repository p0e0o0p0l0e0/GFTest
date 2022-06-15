namespace _35
{// 二分查找：找到升序数组中匹配的值的序号，没有则返回插入的位置序号
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int mid = 0;
            while (left <= right)
            {
                //mid = (right + left) / 2; // 不要用这种方式，因为right如果刚好是int上限，left + right可能导致溢出。
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    if (mid > left && nums[mid - 1] < target)
                    {
                        return mid;
                    }
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                    mid = left;
                }
            }
            return mid;
        }
    }
}