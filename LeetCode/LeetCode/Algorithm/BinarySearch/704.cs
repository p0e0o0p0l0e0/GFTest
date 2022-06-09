namespace _704
{//二分查找：找到升序数组中匹配的值的序号，没有则返回-1
    public class Solution
    {
        // 108ms 50.1MB 二分查找
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int mid;
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
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }

        // 108ms 50MB 遍历列表
        public int Search1(int[] nums, int target)
        {
            for(int i = 0; i <= nums.Length - 1; i++)
            {
                if(nums[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
