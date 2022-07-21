namespace _77// 77. 组合
{
    using System.Collections.Generic;
    class Solution
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> path = new List<int>();

        // 96ms 43.1MB DFS
        public IList<IList<int>> Combine(int n, int k)
        {
            DFS(1, n, k);
            return result;
        }

        private void DFS(int start, int n, int k)
        {
            if (k == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = start; i <= n - k + 1; i++)
            {
                path.Add(i);
                DFS(i + 1, n, k - 1);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}