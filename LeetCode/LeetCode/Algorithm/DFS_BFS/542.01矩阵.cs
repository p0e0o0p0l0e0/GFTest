using System;
using System.Collections.Generic;

namespace _542// 542. 01 矩阵
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        private int[] dx = { 1, 0, 0, -1 };
        private int[] dy = { 0, 1, -1, 0 };

        // 动态规划DP：从左上遍历左上，再从右下遍历右下，得到最终值
        // 188ms 63.7MB
        public int[][] UpdateMatrix3(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            // 初始化动态规划的数组，所有的距离值都设置为一个很大的数
            int[][] path = new int[m][];
            for (int i = 0; i < m; ++i)
            {
                path[i] = new int[n];
                Array.Fill(path[i], int.MaxValue / 2); // 注意这里能设置为MaxValue，因为在+1后可能导致溢出
            }
            // 如果 (i, j) 的元素为 0，那么距离为 0
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (mat[i][j] == 0)
                    {
                        path[i][j] = 0;
                    }
                }
            }
            // 只有 水平向左移动 和 竖直向上移动，注意动态规划的计算顺序
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i - 1 >= 0)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i - 1][j] + 1);
                    }
                    if (j - 1 >= 0)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i][j - 1] + 1);
                    }
                }
            }
            // 只有 水平向右移动 和 竖直向下移动，注意动态规划的计算顺序
            for (int i = m - 1; i >= 0; --i)
            {
                for (int j = n - 1; j >= 0; --j)
                {
                    if (i + 1 < m)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i + 1][j] + 1);
                    }
                    if (j + 1 < n)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i][j + 1] + 1);
                    }
                }
            }
            return path;
        }

        // 第三种算法：多源广度优先
        // 先找到所有的0，加入queue，再从它们触发找到所有的非0，继续寻找。。。
        // 200ms 63.6MB
        public int[][] UpdateMatrix2(int[][] mat)
        {
            int row = mat.Length, column = mat[0].Length;
            int[][] path = new int[row][];
            for (int i = 0; i < row; i++)
            {
                path[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    path[i][j] = int.MaxValue / 2; // 注意这里能设置为MaxValue，因为在+1后可能导致溢出
                }
            }
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue(new int[] { i, j });
                        path[i][j] = 0;
                    }
                }
            }
            while (queue.Count > 0)
            {
                int[] cell = queue.Dequeue();
                int newPath = path[cell[0]][cell[1]] + 1;
                for (int k = 0; k < 4; k++)
                {
                    int x = cell[0] + dx[k], y = cell[1] + dy[k];
                    if (x >= 0 && y >= 0 && x < row && y < column && mat[x][y] != 0 && path[x][y] > newPath)
                    {
                        path[x][y] = newPath;
                        queue.Enqueue(new int[] { x, y });
                    }
                }
            }

            return path;
        }

        private Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

        // 第二种方法：找到第一个0，上下左右一直赋值，更新path数值。遇到新的0则进入递归，如果周围值小于等于新递归的值则停止。类似DFS吧
        // 2056ms 66.6MB时间太长
        public int[][] UpdateMatrix1(int[][] mat)
        {
            int row = mat.Length, column = mat[0].Length;
            int[][] path = new int[row][];
            for (int i = 0; i < row; i++)
            {
                path[i] = new int[column];
                Array.Fill(path[i], int.MaxValue / 2);
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
                    if (mat[x][y] == 0 && !DicContainsCell(x, y))
                    {
                        path[x][y] = 0;
                        DFS(mat, path, x, y);
                    }
                    else if (path[x][y] > (path[i][j] + 1))
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
                Array.Fill(path[i], int.MaxValue / 2);
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

        private int[] min = new int[4];

        private int GetMinimusPath(int[][] path, int i, int j)
        {
            Array.Fill(min, int.MaxValue);
            for (int k = 0; k < 4; k++)
            {
                int x = i + dx[k], y = j + dy[k];
                if (x >= 0 && y >= 0 && x < path.Length && y < path[0].Length)
                    min[k] = path[x][y] + 1;
            }
            int result = int.MaxValue;
            for (int k = 0; k < 4; k++)
            {
                if (min[k] > 0)
                {
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
                    if (path[x][y] > (path[i][j] + 1))
                    {
                        path[x][y] = path[i][j] + 1;
                        UpdateAround(path, x, y);
                    }
                }
            }
        }
    }
}