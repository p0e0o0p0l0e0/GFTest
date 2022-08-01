/*
 * @lc app=leetcode.cn id=136 lang=csharp
 *
 * [136] 只出现一次的数字
 */

namespace _136
{
    // @lc code=start
    public class Solution
    {
        // 位运算 异或 96ms 42.6MB
        // 异或运算满足交换律和结合律，即a⊕b⊕a=b⊕a⊕a=b⊕(a⊕a)=b⊕0=b。
        // 时间复杂度：O(n)，其中n是数组长度。只需要对数组遍历一次。
        // 空间复杂度：O(1)。
        public int SingleNumber(int[] nums)
        {
            int ret = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ret ^= nums[i];
            }
            return ret;
        }
    }

    // @lc code=end
}