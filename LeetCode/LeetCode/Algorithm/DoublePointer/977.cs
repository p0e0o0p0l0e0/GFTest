namespace _977
{//双指针：
    public class Solution
    {
        public int[] SortedSquares(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int mid = 0, target = 0;
            while (left <= right)
            {
                //mid = (right + left) / 2; // 不要用这种方式，因为right如果刚好是int上限，left + right可能导致溢出。
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    break;
                }
                else if (nums[mid] > target)
                {
                    if (mid > left && nums[mid - 1] < target)
                    {
                        break;
                    }
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                    mid = left;
                }
            }
            int[] negativeArray = new int[mid];
            int[] positiveArray;
            int[] squaredArray = new int[nums.Length];
            int negPointer = 0, posPointer = 0, pointer = 0;
            if (mid < nums.Length && nums[mid] == 0)
            {
                positiveArray = new int[nums.Length - mid - 1];
                squaredArray[pointer++] = 0;
            }
            else
            {
                positiveArray = new int[nums.Length - mid];
            }
            for(int i = mid - 1; i >= 0; i--)
            {
                negativeArray[mid - i - 1] = nums[i] * nums[i];
            }
            for(int i = mid + pointer; i < nums.Length; i++)
            {
                positiveArray[i - mid - pointer] = nums[i] * nums[i];
            }

            for(int i = pointer; i < nums.Length; i++)
            {
                if (negPointer < negativeArray.Length && posPointer < positiveArray.Length)
                {
                    if (negativeArray[negPointer] <= positiveArray[posPointer])
                    {
                        squaredArray[i] = negativeArray[negPointer];
                        negPointer++;
                    }
                    else
                    {
                        squaredArray[i] = positiveArray[posPointer];
                        posPointer++;
                    }
                }
                else if (negPointer < negativeArray.Length)
                {
                    squaredArray[i] = negativeArray[negPointer];
                    negPointer++;
                }
                else
                {
                    squaredArray[i] = positiveArray[posPointer];
                    posPointer++;
                }
            }
            return squaredArray;
        }
    }
}
