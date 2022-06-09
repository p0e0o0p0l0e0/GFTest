
namespace _278
{// 二分查找：查找第一个错误的版本
    public class Solution
    {
        public int badVersion = 4;
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n, mid = left;
            while(right >= left)
            {
                mid = left + (right - left) / 2;
                if(IsBadVersion(mid))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                    mid = left; // 如果刚好从这里结束循环，则left+1是badversion
                }
            }
            return mid;
        }

        private bool IsBadVersion(int version)
        {
            return version >= badVersion;
        }
    }
}
