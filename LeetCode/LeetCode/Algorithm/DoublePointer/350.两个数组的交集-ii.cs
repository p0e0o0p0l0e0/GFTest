/*
 * @lc app=leetcode.cn id=350 lang=csharp
 *
 * [350] 两个数组的交集 II
 */

namespace _350
{
    using System;
    using System.Collections.Generic;
// @lc code=start
public class Solution {
    // 哈希表
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for(int i = 0; i < nums1.Length; i++)
        {
            if(!dic.ContainsKey(nums1[i]))
            {
                dic[nums1[i]] = 0;
            }
            dic[nums1[i]]++;
        }
        
        List<int> temp = new List<int>();

        for(int i = 0; i < nums2.Length; i++)
        {
            if(dic.ContainsKey(nums2[i]) && dic[nums2[i]] > 0)
            {
                temp.Add(nums2[i]);
                dic[nums1[i]]--;
            }
        }
        Console.WriteLine("111");
        return temp.ToArray();
    }
    
    // 排序+双指针
    public int[] Intersect1(int[] nums1, int[] nums2) {

        Array.Sort(nums1);
        Array.Sort(nums2);
        List<int> temp = new List<int>();
        for(int i = 0, j = 0; i < nums1.Length && j < nums2.Length; )
        {
            if(nums1[i] == nums2[j])
            {
                temp.Add(nums1[i]);
                i++; j++;
            }
            else if(nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return temp.ToArray();
    }
}
// @lc code=end
}
