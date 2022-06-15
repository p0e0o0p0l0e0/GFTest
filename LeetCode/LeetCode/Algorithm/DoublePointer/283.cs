namespace _283
{//双指针：
    public class Solution
    {
        // 136ms 52.7MB
        // 双指针，i记录非零位置，j向后移动寻找非零值
        public void MoveZeroes(int[] nums)
        {
            for (int i = 0, j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    if (i != j)
                    {
                        nums[i] = nums[j];
                        nums[j] = 0;
                    }
                    i++;
                }
            }
        }
    }
}