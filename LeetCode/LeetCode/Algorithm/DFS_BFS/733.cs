namespace _733// 733. 图像渲染
{// 深度优先DFS 广度优先BFS：


    // DFS 132ms 45MB
    public class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            DFS(image, sr, sc, image[sr][sc], newColor);
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