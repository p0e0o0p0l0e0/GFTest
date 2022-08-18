namespace _344 // 344. 反转字符串
{//双指针：
    public class Solution
    {
        // 240ms 66.3MB
        public void ReverseString(char[] s)
        {
            char temp;
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
        }
    }
}