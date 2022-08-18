/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

namespace _88
{
// @lc code=start
public class Solution {
    // 逆向双指针 时间O(m+n) 空间O(1)
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int lastIndex = nums1.Length - 1;
        for(int i = m - 1, j = n - 1; i >= 0 || j >= 0; )
        {
            if(i >= 0 && j >= 0)
            {
                if(nums1[i] >= nums2[j])
                {
                    nums1[lastIndex] = nums1[i];
                    lastIndex--;
                    i--;
                }
                else
                {
                    nums1[lastIndex] = nums2[j];
                    lastIndex--;
                    j--;
                }
            }
            else if(i >= 0)
            {
                nums1[lastIndex] = nums1[i];
                lastIndex--;
                i--;
            }
            else if(j >= 0)
            {
                nums1[lastIndex] = nums2[j];
                lastIndex--;
                j--;
            }
        }
    }
}
// @lc code=end
}
