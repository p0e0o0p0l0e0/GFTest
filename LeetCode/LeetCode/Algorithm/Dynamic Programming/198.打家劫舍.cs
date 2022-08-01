/*
 * @lc app=leetcode.cn id=198 lang=csharp
 *
 * [198] 打家劫舍
 */

namespace _198
{
    // @lc code=start
    using System.Collections.Generic;
    using System;

    //84ms 37.1MB 动态规划
    public class Solution
    {
        public int Rob(int[] nums) {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int length = nums.Length;
            if (length == 1) 
            {
                return nums[0];
            }
            int first = nums[0], second = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < length; i++) {
                int temp = second;
                second = Math.Max(first + nums[i], second);
                first = temp;
            }
            return second;
        }

        int[] cache;
        public int Rob_DP1(int[] nums)
        {
            cache = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                cache[i] = -1;
            }
            return DP(nums, 0);
        }

        public int DP(int[] nums, int start)
        {
            if(cache[start] >= 0)
                return cache[start];
            int val = 0;
            if(nums.Length == start + 1)
            {
                val = nums[start];
            }
            else if(nums.Length == start + 2)
            {
                val = Math.Max(nums[start], nums[start + 1]);
            }
            else if(nums.Length == start + 3)
            {
                val = Math.Max(nums[start] + nums[start + 2], nums[start + 1]);
            }
            else
            {
                val = Math.Max((nums[start] + DP(nums, start + 2)), (nums[start + 1] + DP(nums, start + 3)));
            }
            cache[start] = val;
            return val;
        }
    }

    // @lc code=end
}