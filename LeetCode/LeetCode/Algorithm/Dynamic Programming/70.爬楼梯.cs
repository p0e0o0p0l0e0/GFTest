/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

namespace _70
{
    // @lc code=start
    using System.Collections.Generic;

    public class Solution
    {

        // 20ms 26.5MB
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                dp[i] = dp[i-1] + dp[i-2];
            }
            return dp[n];
        }


        private Dictionary<int, int> cache = new Dictionary<int, int>();

        // 20ms 26.5MB
        public int ClimbStairs1(int n)
        {
            cache[1] = 1;
            cache[2] = 2;
            return DP(n);
        }

        private int DP(int n)
        {
            int temp;
            if(!cache.TryGetValue(n, out temp))
            {
                temp = DP(n-1) + DP(n-2);
                cache[n] = temp;
            }
            return temp;
        }
    }

    // @lc code=end
}