using System.Collections.Generic;

namespace _733// 733. 图像渲染
{// 深度优先DFS 广度优先BFS：
    public class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            // DFS 132ms 45MB
            //DFS(image, sr, sc, image[sr][sc], newColor);

            // BFS 132ms 344.8MB
            int[] dx = { 1, 0, 0, -1 };
            int[] dy = { 0, 1, -1, 0 };

            int oldColor = image[sr][sc];
            if (oldColor == newColor)
                return image;
            int m = image.Length, n = image[0].Length;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { sr, sc });
            image[sr][sc] = newColor;
            while (queue.Count > 0)
            {
                int[] cell = queue.Dequeue();
                int x = cell[0], y = cell[1];
                for (int i = 0; i < 4; i++)
                {
                    int mx = x + dx[i], my = y + dy[i];
                    if (mx >= 0 && mx < m && my >= 0 && my < n && image[mx][my] == oldColor)
                    {
                        queue.Enqueue(new int[] { mx, my });
                        image[mx][my] = newColor;
                    }
                }
            }

            return image;
        }

        private void DFS(int[][] image, int x, int y, int oldColor, int newColor)
        {
            if (x < 0 || y < 0 || x >= image.Length || y >= image[0].Length)
            {
                return;
            }
            if (image[x][y] != oldColor || image[x][y] == newColor)
            {
                return;
            }

            image[x][y] = newColor;
            DFS(image, x + 1, y, oldColor, newColor);
            DFS(image, x - 1, y, oldColor, newColor);
            DFS(image, x, y + 1, oldColor, newColor);
            DFS(image, x, y - 1, oldColor, newColor);
        }
    }
}