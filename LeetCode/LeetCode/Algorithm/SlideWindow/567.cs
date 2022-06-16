using System.Collections.Generic;

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
            Dictionary<char, int> dic = new Dictionary<char, int>(26); // 对照组
            Dictionary<char, int> dic1 = new Dictionary<char, int>(26); // 临时组
            List<char> list = new List<char>(); // 存储遍历中的字符
            for (int i = 0; i < s1.Length; i++)
            {
                char c = s1[i];
                if(dic.ContainsKey(c))
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
                char c = s2[i];
                if(dic.ContainsKey(c))
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
                            char c2 = list[j];
                            dic1[c2] = dic1[c2] - 1;
                        }
                        list.RemoveRange(0, index + 1);
                    }
                }
                else
                {
                    list.Clear();
                    foreach(char cx in dic1.Keys)
                    {
                        dic1[cx] = 0;
                    }
                }
            }
            return false;
        }

        private bool Check(Dictionary<char, int> dic, Dictionary<char, int> dic1)
        {
            foreach(char c in dic.Keys)
            {
                if (dic1[c] != (dic[c]))
                    return false;
            }
            return true;
        }
    }
}