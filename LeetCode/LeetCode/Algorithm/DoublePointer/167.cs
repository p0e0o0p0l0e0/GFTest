using System.Collections.Generic;

namespace _167
{//双指针：
    public class Solution
    {
        // 152ms 45.4MB
        // 未找到匹配值的数字存在Dic中，用于后续数字的对应值在dic中匹配。时间复杂度O(n)
        public int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int temp = 0;
            for(int i = 0; i < numbers.Length;i++)
            {
                temp = target - numbers[i];
                if(!dic.ContainsKey(temp))
                {
                    dic[numbers[i]] = i;
                }
                else
                {
                    return new int[2] { dic[temp] + 1, i + 1 };
                }
            }
            return null;
        }

        // 480ms 45.1MB
        // 因为序列递增，依次遍历数组的每一个值，去后续序列里寻找匹配值。时间复杂度O(nlogn)
        public int[] TwoSum1(int[] numbers, int target)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                for(int j = i+1; j < numbers.Length; j++)
                {
                    int temp = numbers[i] + numbers[j];
                    if (temp > target)
                        break;
                    if (temp == target)
                    {
                        return new int[2] { i + 1, j + 1 };
                    }
                }
            }
            return null;
        }

        // 128ms 45.3MB
        // 前后两个指针，当和大于target，则后指针往前移，如果小于target则前指针向后移
        public int[] TwoSums2(int[] numbers, int target)
        {
            for (int i = 0, j = numbers.Length - 1; ;)
            {
                if (i >= j)
                    break;
                int temp = numbers[i] + numbers[j];
                if (temp == target)
                    return new int[2] { i + 1, j + 1 };
                else if (temp > target)
                    j--;
                else
                    i++;
            }
            return null;
        }
    }
}
