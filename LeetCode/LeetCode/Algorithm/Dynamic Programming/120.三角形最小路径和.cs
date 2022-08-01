/*
 * @lc app=leetcode.cn id=120 lang=csharp
 *
 * [120] 三角形最小路径和
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        for (int i = 1; i < triangle.Count; i++)
        {
            triangle[i][0] += triangle[i - 1][0];
            triangle[i][i] += triangle[i - 1][i - 1];
            for (int j = 1; j < i; j++)
            {
                triangle[i][j] += Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]);
            }
        }
        IList<int> lastRow = triangle[triangle.Count - 1];
        int min = lastRow[0];
        for (int i = 0; i < lastRow.Count; i++)
        {
            min = Math.Min(lastRow[i], min);
        }
        return min;
    }
}

// @lc code=end