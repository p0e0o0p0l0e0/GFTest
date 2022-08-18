using System.Collections.Generic;

namespace _994// 994. 腐烂的橘子
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        private int[] dx = { 1, 0, 0, -1 };
        private int[] dy = { 0, 1, -1, 0 };

        // BFS 多源广度优先 80ms 38.9MB
        public int OrangesRotting(int[][] grid)
        {
            int row = grid.Length, column = grid[0].Length;
            int freshCount = 0, min = 0;
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                    else if (grid[i][j] == 2)
                    {
                        queue.Enqueue(new int[2] { i, j });
                    }
                }
            }
            if (freshCount == 0)
                return 0;

            while (queue.Count > 0)
            {
                int count = queue.Count;
                min++;
                for (int k = 0; k < count && freshCount > 0; k++)
                {
                    int[] cell = queue.Dequeue();
                    for (int i = 0; i < 4 && freshCount > 0; i++)
                    {
                        int x = cell[0] + dx[i];
                        int y = cell[1] + dy[i];
                        if (x >= 0 && x < row && y >= 0 && y < column)
                        {
                            if (grid[x][y] == 1)
                            {
                                grid[x][y] = 2;
                                queue.Enqueue(new int[2] { x, y });
                                freshCount--;
                            }
                        }
                    }
                }
                if (freshCount == 0)
                    return min;
            }
            return -1;
        }
    }
}