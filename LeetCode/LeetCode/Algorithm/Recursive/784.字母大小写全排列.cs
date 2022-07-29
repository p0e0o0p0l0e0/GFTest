/*
 * @lc app=leetcode.cn id=784 lang=csharp
 *
 * [784] 字母大小写全排列
 */

namespace _784
{
    using System.Collections.Generic;

    // @lc code=start

    public class Solution
    {
        private IList<string> result = new List<string>();
        private char[] path;

        // 回溯算法 152ms 64.4MB
        // c^32可以切换字母大小写
        public IList<string> LetterCasePermutation(string s)
        {
            path = s.ToCharArray();
            BackTracking(s, 0);
            return result;
        }

        private void BackTracking(string s, int start)
        {
            if (s.Length == start)
            {
                result.Add(new string(path));
                return;
            }

            char c = s[start];
            if (!IsNumber(c))
            {
                path[start] = c;
                BackTracking(s, start + 1);

                path[start] = (char)(c ^ 32);
                BackTracking(s, start + 1);
            }
            else
            {
                BackTracking(s, start + 1);
            }
        }

        private bool IsNumber(char c)
        {
            return c >= 48 && c <= 57;
        }
    }

    // @lc code=end
}