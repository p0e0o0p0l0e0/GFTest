/*
 * @lc app=leetcode.cn id=566 lang=csharp
 *
 * [566] 重塑矩阵
 */

// @lc code=start
public class Solution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        if (m * n != r * c) {
            return mat;
        }

        int[][] result = new int[r][];
        for (int i = 0; i < r; ++i)
        {
            result[i] = new int[c];
        }
        for (int x = 0; x < m * n; ++x) {
            result[x / c][x % c] = mat[x / n][x % n];
        }
        return result;
    }
    
    public int[][] MatrixReshape1(int[][] mat, int r, int c)
    {
        if(mat.Length * mat[0].Length != r * c)
            return mat;

        int[][] result = new int[r][];
        for (int i = 0; i < r; ++i)
        {
            result[i] = new int[c];
        }
        int x = 0, y = 0;
        for(int i = 0; i < mat.Length; i++)
        {
            for(int j = 0; j < mat[i].Length; j++)
            {
                result[x][y] = mat[i][j];
                y++;
                if(y == c)
                {
                    y = 0;
                    x++;
                    if(x == r)
                        break;
                }
            }
            if(x == r)
                break;
        }
        return result;
    }
}
// @lc code=end

