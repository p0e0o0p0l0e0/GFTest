namespace _977 // 有序数组的平方
{//双指针：
    public class Solution
    {
        // 双指针前后缩进 160ms 58.9MB
        public int[] SortedSquares(int[] nums)
        {
            int[] squaredArray = new int[nums.Length];
            int left = 0, right = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[left] < 0 && -nums[left] > nums[right])
                {
                    squaredArray[i] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    squaredArray[i] = nums[right] * nums[right];
                    right--;
                }
            }
            return squaredArray;
        }
    }
}