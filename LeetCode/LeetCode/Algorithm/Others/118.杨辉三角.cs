/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 */

namespace _118
{
using System.Collections.Generic;
// @lc code=start
public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> result = new List<IList<int>>(numRows);
        for(int r = 0; r < numRows; r++)
        {
            result.Add(new List<int>(r));
            for(int c = 0; c <= r; c++)
            {
                if(c == 0 || c == r)
                {
                    result[r].Add(1);
                }
                else
                {
                    result[r].Add(result[r-1][c-1] + result[r-1][c]);
                }
            }
        }
        return result;
    }
}
// @lc code=end

}