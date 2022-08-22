/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */


namespace _121
{
    using System;
    // @lc code=start
    public class Solution
    {
        // 一次遍历 O(n) O(1)
        public int MaxProfit(int[] prices) {
            int max = 0, start = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if(prices[i] < prices[start])
                {
                    start = i;
                }
                else
                {
                    max = Math.Max(max, prices[i] - prices[start]);
                }
            }
            return max;
        }
}
// @lc code=end
}
