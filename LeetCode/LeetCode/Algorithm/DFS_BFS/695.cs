using System;
using System.Collections.Generic;

namespace _695 // 695. 岛屿的最大面积
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        // BFS 104ms 43.2MB
        public int MaxAreaOfIsland_BFS(int[][] grid)
        {
            int[] dx = { 1, 0, 0, -1 };
            int[] dy = { 0, 1, -1, 0 };

            int maxarea = 0, temparea = 0;
            int m = grid.Length, n = grid[0].Length;

            Queue<int[]> queue = new Queue<int[]>();
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        queue.Enqueue(new int[] { i, j });
                        temparea++;
                        grid[i][j] = -1;
                        while (queue.Count > 0)
                        {
                            int[] cell = queue.Dequeue();
                            int x = cell[0], y = cell[1];
                            for (int k = 0; k < 4; k++)
                            {
                                int mx = x + dx[k], my = y + dy[k];
                                if (mx >= 0 && mx < m && my >= 0 && my < n && grid[mx][my] == 1)
                                {
                                    queue.Enqueue(new int[] { mx, my });
                                    grid[mx][my] = -1;
                                    temparea++;
                                }
                            }
                        }
                        maxarea = Math.Max(maxarea, temparea);
                        temparea = 0;
                    }
                }
            }
            return maxarea;
        }




        // DFS: 80ms 42MB
        int temparea = 0;
        public int MaxAreaOfIsland_DFS(int[][] grid)
        {
            int maxarea = 0;
            int m = grid.Length, n = grid[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        DFSMaxArea(grid, i, j);
                        maxarea = Math.Max(maxarea, temparea);
                        temparea = 0;
                    }
                }
            }
            return maxarea;
        }

        private void DFSMaxArea(int[][] grid, int sr, int sc)
        {
            if (sr < 0 || sc < 0 || sr >= grid.Length || sc >= grid[0].Length || grid[sr][sc] != 1)
            {
                return;
            }
            grid[sr][sc] = -1;
            temparea++;
            DFSMaxArea(grid, sr + 1, sc);
            DFSMaxArea(grid, sr - 1, sc);
            DFSMaxArea(grid, sr, sc + 1);
            DFSMaxArea(grid, sr, sc - 1);
        }
    }
}