/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    IList<IList<int>> result = new List<IList<int>>();
    IList<int> path = new List<int>();
    int[] b;

    // 124ms 42.3MB 回溯算法
    public IList<IList<int>> Permute(int[] nums) {
        int length = nums.Length;
        b = new int[nums.Length];
        BackTracking(nums, length);
        return result;
    }

    private void BackTracking(int[] nums, int n)
    {
        if (path.Count == nums.Length)
        {
            result.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if(!path.Contains(nums[i]))
            {
                path.Add(nums[i]);
                BackTracking(nums, n);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
// @lc code=end

