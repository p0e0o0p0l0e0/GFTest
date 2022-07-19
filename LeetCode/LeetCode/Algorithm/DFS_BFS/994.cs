using System.Collections.Generic;
using System;

namespace _994// 994. 腐烂的橘子
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        int[] dx = { 1, 0, 0, -1 };
        int[] dy = { 0, 1, -1, 0 };

        // BFS 广度优先 72ms 39MB
        public int OrangesRotting_BFS(int[][] grid)
        {
            int row = grid.Length;
            int column = grid[0].Length;
            int freshCount = 0, unfreshCount = 0;
            int min = 0;
            int tempCount1 = 0, tempCount2 = 0;
            Queue<int[]> queue = new Queue<int[]>();
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                    else if(grid[i][j] == 2)
                    {
                        queue.Enqueue(new int[2] { i, j });
                        unfreshCount++;
                    }
                }
            }
            if (freshCount == 0)
            {
                return 0;
            }
            min++;
            while(queue.Count > 0)
            {
                int[] cell = queue.Dequeue();
                for(int i = 0; i < 4; i++)
                {
                    int x = cell[0] + dx[i];
                    int y = cell[1] + dy[i];
                    if (x >= 0 && x < row && y >= 0 && y < column)
                    {
                        if(grid[x][y] == 1)
                        {
                            grid[x][y] = 2;
                            freshCount--;
                            tempCount2++;
                            queue.Enqueue(new int[2] { x, y });
                            if (freshCount == 0)
                                break;
                        }
                    }
                }
                if (freshCount == 0)
                    break;
                tempCount1++;
                if (tempCount1 == unfreshCount)
                {
                    min++;
                    unfreshCount = tempCount2;
                    tempCount1 = 0;
                    tempCount2 = 0;
                }
            }
            if (freshCount > 0)
                return -1;
            return min;
        }
    }
}