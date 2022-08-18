/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

namespace _53
{
// @lc code=start

public class Solution {

    // 官方动态规划方法 f(i)=max{f(i−1)+nums[i],nums[i]}
    // 考虑nums[i]单独成为一段还是加入f(i−1)对应的那一段
    public int MaxSubArray(int[] nums) {
        int pre = 0, maxAns = nums[0];
        foreach (int x in nums) {
            pre = Max(pre + x, x);
            maxAns = Max(maxAns, pre);
        }
        return maxAns;
    }

    // 自己的类似方法
    public int MaxSubArray1(int[] nums) {
        int maxSubSum = nums[0];
        int ret = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (ret < 0)
            {
                ret = num;
            }
            else
            {
                ret += num;
            }
            maxSubSum = Max(maxSubSum, ret);
        }
        return maxSubSum;
    }

    private int Max(int a, int b)
    {
        return a >= b ? a : b;
    }
}

// @lc code=end
}
