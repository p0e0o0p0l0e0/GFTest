using System.Collections.Generic;
using System.Linq;

namespace _567 // 567. 字符串的排列，s2是否包含s1的全排列，即使倒叙
{//滑动窗口：
    public class Solution
    {
        // 72ms 39.3MB
        // 两个字典，第一个存储s1对应字符的个数，作为比对模板。第二个字典存储向后遍历字符时的出现的各个字符的个数。当两个字典内容一样时return true。
        public bool CheckInclusion(string s1, string s2)
        {
            if (s2.Length - s1.Length < 0)
                return false;
            Dictionary<int, int> dic = new Dictionary<int, int>(26); // 对照组
            Dictionary<int, int> dic1 = new Dictionary<int, int>(26); // 临时组
            List<int> list = new List<int>(); // 存储遍历中的字符
            for (int i = 0; i < s1.Length; i++)
            {
                int c = s1[i] - 'a';
                if (dic.ContainsKey(c))
                {
                    dic[c] = dic[c] + 1;
                }
                else
                {
                    dic[c] = 1;
                }
                dic1[c] = 0;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                int c = s2[i] - 'a';
                if (dic.ContainsKey(c))
                {
                    dic1[c] = dic1[c] + 1;
                    list.Add(c);

                    if (Check(dic, dic1))
                        return true;
                    if (dic[c] < (dic1[c]))
                    {
                        int index = list.IndexOf(c);
                        for (int j = 0; j <= index; j++)
                        {
                            int c2 = list[j];
                            dic1[c2] = dic1[c2] - 1;
                        }
                        list.RemoveRange(0, index + 1);
                    }
                }
                else
                {
                    list.Clear();
                    foreach (int cx in dic1.Keys)
                    {
                        dic1[cx] = 0;
                    }
                }
            }
            return false;
        }

        private bool Check(Dictionary<int, int> dic, Dictionary<int, int> dic1)
        {
            foreach (int c in dic.Keys)
            {
                if (dic1[c] != (dic[c]))
                    return false;
            }
            return true;
        }

        // 72ms 40.5MB
        // 用一个array, s2中前len个字符与s1的差，如果差为0则包含; 每往后移动一位，则减去前面一个字符，加上新的字符。如果差为0则包含
        public bool CheckInclusion1(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            int len = s1.Length;

            int[] arr = new int[26];
            for (int i = 0; i < len; ++i)
            { // s2中前len个字符与s1的差，如果差为0则包含
                --arr[s1[i] - 'a'];
                ++arr[s2[i] - 'a'];
            }
            if (!arr.Any(e => e != 0)) return true;

            //每往后移动一位，则减去前面一个字符，加上新的字符。如果差为0则包含
            for (int i = len; i < s2.Length; ++i)
            {
                --arr[s2[i - len] - 'a'];
                ++arr[s2[i] - 'a'];
                if (!arr.Any(e => e != 0)) return true;
            }
            return false;
        }
    }
}