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
        // 24ms 26.5MB 斐波那契数列 通项公式 参考同目录图片 时间O(log(n)) 空间O(1)
        public int ClimbStairs(int n)
        {
            int[][] m = new int[2][] { new int[2] { 0, 1 }, new int[2] { 1, 1 } };
            int[][] res = pow(m, n);
            return res[1][1];
        }

        public int[][] pow(int[][] a, int n)
        {
            int[][] ret = new int[2][] { new int[2] { 1, 0 }, new int[2] { 0, 1 } };
            while(n > 0)
            {
                // 二分方式将时间复杂度降为O(log(n))
                if ((n & 1) == 1) // 如果是奇数就多乘一个a，因为后面n要除以2，向下取整
                {
                    ret = multiply(ret, a);
                }
                n >>= 1; // 除以2，向下取整
                a = multiply(a, a);
            }
            return ret;
        }

        // 矩阵乘法
        public int[][] multiply(int[][] a, int[][] b)
        {
            int[][] c = new int[2][]{new int[2], new int[2]};
            c[0][0] = a[0][0] * b[0][0] + a[0][1] * b[1][0];
            c[0][1] = a[0][0] * b[0][1] + a[0][1] * b[1][1];
            c[1][0] = a[1][0] * b[0][0] + a[1][1] * b[1][0];
            c[1][1] = a[1][0] * b[0][1] + a[1][1] * b[1][1];
            return c;
        }

        // 24ms 25.9MB DP 时间O(n) 空间O(1) 只需要前两个数据
        public int ClimbStairs_DP2(int n)
        {
            if (n == 1)
                return 1;
            int first = 1, second = 2;
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }
            return second;
        }

        // 24ms 25.9MB DP 时间O(n) 空间O(n)
        public int ClimbStairs_DP1(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        private Dictionary<int, int> cache = new Dictionary<int, int>();

        // 20ms 26.5MB 递归 时间O(n) 空间O(n)
        public int ClimbStairs_Recursion(int n)
        {
            cache[1] = 1;
            cache[2] = 2;
            return DP(n);
        }

        private int DP(int n)
        {
            int temp;
            if (!cache.TryGetValue(n, out temp))
            {
                temp = DP(n - 1) + DP(n - 2);
                cache[n] = temp;
            }
            return temp;
        }
    }

    // @lc code=end
}