/*
 * @lc app=leetcode.cn id=217 lang=csharp
 *
 * [217] 存在重复元素
 */

namespace _217
{
// @lc code=start
using System.Collections.Generic;

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> set = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++)
        {
            if(set.Contains(nums[i]))
                return true;
            set.Add(nums[i]);
        }
        return false;
    }
}
// @lc code=end

}