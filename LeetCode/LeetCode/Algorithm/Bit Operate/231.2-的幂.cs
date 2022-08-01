/*
 * @lc app=leetcode.cn id=231 lang=csharp
 *
 * [231] 2 的幂
 */

namespace _231
{
    // @lc code=start

    // 24ms 27.7MB
    public class Solution
    {
        // 方法二：判断是否为最大 22 的幂的约数
        public bool IsPowerOfTwo(int n)
        {
            return n > 0 && (1 << 30) % n == 0;
        }

        // 方法一：二进制表示
        public bool IsPowerOfTwo_3(int n)
        {
            return (n > 0) && (n & -n) == n;
        }

        // 方法一：二进制表示
        public bool IsPowerOfTwo_2(int n)
        {
            return (n > 0) && (n & (n - 1)) == 0;
        }

        public bool IsPowerOfTwo_Mine(int n)
        {
            if (n <= 0)
                return false;
            while (n > 1)
            {
                int x = n >> 1;
                if ((x << 1) != n)
                    return false;
                n = x;
            }
            return true;
        }
    }

    // @lc code=end
}