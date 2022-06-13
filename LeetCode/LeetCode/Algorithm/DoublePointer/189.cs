using System.Collections.Generic;

namespace _189
{//双指针：
    public class Solution
    {
        // 循环向前移动，把新位置的值记录下来继续进行移动。有个标记列表，记录此位置是否已经存放过移动后的值。
        public int[] Rotate(int[] nums, int k)
        {
            Dictionary<int, int> flagDic = new Dictionary<int, int>();
            int length = nums.Length;
            int tempValue = 0, newTempValue = 0, newPos = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (!flagDic.ContainsKey(i))
                {
                    tempValue = nums[i];
                    newPos = GetNewPos(i, k, length);
                    while(!flagDic.ContainsKey(newPos))
                    {
                        newTempValue = nums[newPos];
                        nums[newPos] = tempValue;
                        tempValue = newTempValue;
                        flagDic[newPos] = 1;
                        newPos = GetNewPos(newPos, k, length);
                    }
                }
            }
            return nums;
        }
        private int GetNewPos(int i, int k, int length)
        {
            return (i + k) % length;
        }
    }
}
