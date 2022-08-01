/*
 * @lc app=leetcode.cn id=191 lang=csharp
 *
 * [191] 位1的个数
 */

namespace _191
{
    // @lc code=start
    public class Solution
    {
        // 方法三：二分计数法 20ms 23.2MB O(lognlogn) O(1)
        /*
           0x5555……这个换成二进制之后就是0101010101010101……
           0x3333……这个换成二进制之后就是0011001100110011……
           0x0f0f……...这个换成二进制之后就是0000111100001111……
           对于2位的x，有x中1的个数=(x>>1)+(x&1)。是不是和上面的式子有点像？
           就是一个 错位分段相加，然后递归合并的过程
        */

        public int HammingWeight(uint n)
        {
            n = (n & 0x55555555) + ((n >> 1) & 0x55555555);
            n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
            n = (n & 0x0f0f0f0f) + ((n >> 4) & 0x0f0f0f0f);
            n = (n & 0x00ff00ff) + ((n >> 8) & 0x00ff00ff);
            n = (n & 0x0000ffff) + ((n >> 16) & 0x0000ffff);
            return (int)n;
        }

        // 方法二：位运算优化 20ms 23.1MB O(logn) O(1)
        // 不断让当前的n与n-1做与运算，直到n变为0即可。
        // 因为每次运算会使得n的最低位的1被翻转，因此运算次数就等于n的二进制位中1的个数。
        public int HammingWeight_2(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                n &= n - 1;
                count++;
            }
            return count;
        }

        // 方法一：循环检查二进制位 24ms 23.3MB O(k) O(1) k是int型二进制的位数
        public int HammingWeight_1(uint n)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if (((1 << i) & n) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }

    // @lc code=end
}