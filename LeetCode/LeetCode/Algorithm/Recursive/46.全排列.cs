/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

using System.Collections.Generic;

namespace _46
{
    // @lc code=start
    public class Solution
    {
        private IList<IList<int>> result = new List<IList<int>>();
        private IList<int> path = new List<int>();

        // 124ms 42.3MB 回溯算法
        public IList<IList<int>> Permute(int[] nums)
        {
            int length = nums.Length;
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
                if (!path.Contains(nums[i]))
                {
                    path.Add(nums[i]);
                    BackTracking(nums, n);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }

    // @lc code=end
}