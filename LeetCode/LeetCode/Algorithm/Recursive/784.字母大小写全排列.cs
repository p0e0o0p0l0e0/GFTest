/*
 * @lc app=leetcode.cn id=784 lang=csharp
 *
 * [784] 字母大小写全排列
 */

namespace _784
{
    using System.Collections.Generic;

    // @lc code=start
    using System.Text;

    public class Solution
    {
        private IList<string> result = new List<string>();
        private StringBuilder sb = new StringBuilder();

        public IList<string> LetterCasePermutation(string s)
        {
            BackTracking(s, 0);
            return result;
        }

        private void BackTracking(string s, int start)
        {
            if (s.Length == sb.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                if (IsLetter(s[i]))
                {
                    sb.Append(s[i].ToString().ToLower());
                    BackTracking(s, i + 1);
                    sb.Remove(sb.Length - 1, 1);

                    sb.Append(s[i].ToString().ToUpper());
                    BackTracking(s, i + 1);
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(s[i]);
                    BackTracking(s, i + 1);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }

        private bool IsLetter(char c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }
    }

    // @lc code=end
}