using System.Collections.Generic;
using System;

namespace _542// 542. 01 矩阵
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        int[] dx = { 1, 0, 0, -1 };
        int[] dy = { 0, 1, -1, 0 };
        Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

        // 第二种方法：找到第一个0，上下左右一直赋值，更新path数值。遇到新的0则进入递归，如果周围值小于等于新递归的值则停止。类似DFS吧
        // 2056ms 66.6MB时间太长
        public int[][] UpdateMatrix1(int[][] mat)
        {
            int row = mat.Length, column = mat[0].Length;
            int[][] path = new int[row][];
            for (int i = 0; i < row; i++)
            {
                path[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    path[i][j] = -1;
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (mat[i][j] == 0 && !DicContainsCell(i, j))
                    {
                        path[i][j] = 0;
                        DFS(mat, path, i, j);
                    }
                }
            }
            return path;
        }

        private bool DicContainsCell(int i, int j)
        {
            if (!dic.ContainsKey(i) || !dic[i].ContainsKey(j))
            {
                if (!dic.ContainsKey(i))
                {
                    dic[i] = new Dictionary<int, int>();
                }
                dic[i][j] = 1;
                return false;
            }
            return true;
        }

        private void DFS(int[][] mat, int[][] path, int i, int j)
        {
            if (i >= path.Length || j >= path[0].Length || i < 0 || j < 0 || path[i][j] < 0)
                return;
            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k], y = j + dy[k];
                if (x >= 0 && y >= 0 && x < path.Length && y < path[0].Length)
                {
                    if(mat[x][y] == 0 && !DicContainsCell(x, y))
                    {
                        path[x][y] = 0;
                        DFS(mat, path, x, y);
                    }
                    else if (path[x][y] == -1 || path[x][y] > (path[i][j] + 1))
                    {
                        path[x][y] = path[i][j] + 1;
                        DFS(mat, path, x, y);
                    }
                }
            }
        }



        // 第一种方法：每次给一个格子赋值，如果是0则赋值为0，如果不是0则寻找上下左右最小值，+1得当前值。
        // 赋值后更新上下左右的值，出现比当前值+1还大的，则继续更新上下左右的值，直到停止。
        // 超时了！！！
        public int[][] UpdateMatrix(int[][] mat)
        {
            int row = mat.Length, column = mat[0].Length;
            int[][] path = new int[row][];
            for (int i = 0; i < row; i++)
            {
                path[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    path[i][j] = -1;
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        path[i][j] = 0;
                    }
                    else
                    {
                        path[i][j] = GetMinimusPath(path, i, j);
                    }
                    UpdateAround(path, i, j);
                }
            }
            return path;
        }

        int[] min = new int[4];
        private int GetMinimusPath(int[][] path, int i, int j)
        {
            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k], y = j + dy[k];
                if (x >= 0 && y >= 0 && x < path.Length && y < path[0].Length)
                    min[k] = path[x][y] + 1;
                else
                    min[k] = -1;
            }
            int result = -1;
            for (int k = 0; k < 4; k++)
            {
                if (min[k] > 0)
                {
                    if (result == -1)
                        result = min[k];
                    else
                        result = Math.Min(result, min[k]);
                }
            }
            return result;
        }

        private void UpdateAround(int[][] path, int i, int j)
        {
            if (i >= path.Length || j >= path[0].Length || i < 0 || j < 0 || path[i][j] < 0)
                return;
            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k], y = j + dy[k];
                if (x >= 0 && y >= 0 && x < path.Length && y < path[0].Length)
                {
                    if(path[x][y] == -1 || path[x][y] > (path[i][j] + 1))
                    {
                        path[x][y] = path[i][j] + 1;
                        UpdateAround(path, x, y);
                    }
                }
            }
        }
    }
}