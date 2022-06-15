using System;
using System.Collections.Generic;

namespace _3 // 3. 无重复字符的最长子串
{//滑动窗口：
    public class Solution
    {
        // 64ms 39.5MB
        // 双指针：向后遍历字符串，如果遇到与前面重复的，更新maxcount和非重复字符串的开始位置，继续遍历
        public int LengthOfLongestSubstring(string s)
        {
            int maxcount = 0;
            int start = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dic.ContainsKey(c) && dic[c] >= start)
                {
                    maxcount = Math.Max(maxcount, i - start);
                    start = dic[c] + 1;
                }
                dic[c] = i;
            }
            maxcount = Math.Max(maxcount, s.Length - start);
            return maxcount;
        }

        // 56ms, 38.3MB
        // 用先进先出的队列存储char，遇到重复的，则推出前面直到重复字符串的字符。
        public int LengthOfLongestSubstring1(string s)
        {
            int max = 0;
            Queue<char> q = new Queue<char>();
            foreach (char c in s)
            {
                while (q.Contains(c))
                    q.Dequeue();
                q.Enqueue(c);
                if (q.Count > max)
                    max = q.Count;
            }
            return max;
        }

    }
}