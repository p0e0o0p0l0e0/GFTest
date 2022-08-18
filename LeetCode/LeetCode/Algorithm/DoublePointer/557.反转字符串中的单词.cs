namespace _557 // 557. 反转字符串中的单词 III
{//双指针：
    public class Solution
    {
        // 76ms 43.6MB
        // 转char[]，每遇到空格就把前面单词反转。
        public string ReverseWords(string s)
        {
            char[] c = s.ToCharArray();
            int from = -1, to = -1;
            for (int i = 0; i < c.Length; i++)
            {
                if (from == -1 && c[i] != ' ')
                {
                    from = i;
                }
                else if (c[i] == ' ')
                {
                    to = i - 1;
                    ReverseString(c, from, to);
                    from = -1;
                }
                else if (i == c.Length - 1)
                {
                    to = i;
                    ReverseString(c, from, to);
                    from = -1;
                }
            }
            return new string(c);
        }

        private void ReverseString(char[] s, int from, int to)
        {
            char temp;
            for (int i = from, j = to; i < j; i++, j--)
            {
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
        }
    }
}