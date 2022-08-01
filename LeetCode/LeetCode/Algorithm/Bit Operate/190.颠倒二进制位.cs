/*
 * @lc app=leetcode.cn id=190 lang=csharp
 *
 * [190] 颠倒二进制位
 */

namespace _190
{
    // @lc code=start
    public class Solution
    {
        // 逐位颠倒 28ms 23.6MB O(logn) O(1)
        public uint reverseBits(uint n)
        {
            uint ret = 0;
            for (int i = 0; i < 32 && n != 0; ++i)
            {
                ret |= (n & 1) << (31 - i);
                n >>= 1;
            }
            return ret;
        }

        private uint M1 = 0x55555555; // 01010101010101010101010101010101
        private uint M2 = 0x33333333; // 00110011001100110011001100110011
        private uint M4 = 0x0f0f0f0f; // 00001111000011110000111100001111
        private uint M8 = 0x00ff00ff; // 00000000111111110000000011111111

        // 分治法 12ms 23.4MB O(1) O(1)
        public uint reverseBits_1(uint n)
        {
            n = n >> 1 & M1 | (n & M1) << 1; // 先把二进制两两分组，颠倒奇数位和偶数位
            n = n >> 2 & M2 | (n & M2) << 2; // 再四四分组颠倒。。
            n = n >> 4 & M4 | (n & M4) << 4;
            n = n >> 8 & M8 | (n & M8) << 8;
            return n >> 16 | n << 16;
        }
    }

    // @lc code=end
}