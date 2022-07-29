/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 */

 /*
    总结：
    这里形成的数列正好是斐波那契数列，答案要求的f(n)即是斐波那契数列的第n项（下标从0开始）。
    我们来总结一下斐波那契数列第 nn 项的求解方法：

    1 n比较小的时候，可以直接使用过递归法求解，不做任何记忆化操作，时间复杂度是 O(2^n)，存在很多冗余计算。
    2 一般情况下，我们使用「记忆化搜索」或者「迭代」的方法，实现这个转移方程，时间复杂度和空间复杂度都可以做到O(n)。
    3 为了优化空间复杂度，我们可以不用保存f(x−2)之前的项，我们只用三个变量来维护f(x)、f(x−1)和f(x−2)，
      你可以理解成是把「滚动数组思想」应用在了动态规划中，也可以理解成是一种递推，这样把空间复杂度优化到了O(1)。
    4 随着n的不断增大 O(n) 可能已经不能满足我们的需要了，我们可以用「矩阵快速幂」的方法把算法加速到O(logn)。
    5 我们也可以把n代入斐波那契数列的通项公式计算结果，但是如果我们用浮点数计算来实现，可能会产生精度误差。

    作者：LeetCode-Solution
    链接：https://leetcode.cn/problems/climbing-stairs/solution/pa-lou-ti-by-leetcode-solution/
    来源：力扣（LeetCode）
    著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
 */

namespace _70
{
    // @lc code=start
    using System.Collections.Generic;

    public class Solution
    {
        // Binet's Formula 通项公式 解析解
        public int ClimbStairs(int n)
        {
            return 0;
        }

        // 24ms 26.5MB 斐波那契数列 矩阵快速幂 参考同目录图片 时间O(log(n)) 空间O(1)
        public int ClimbStairs_FibonacciSequence(int n)
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