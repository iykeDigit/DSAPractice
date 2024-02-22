using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 10, 1, 2, 7, 1, 3 };
            var res = MinimizeMax(arr, 2);
            Console.WriteLine();
        }

        public static long MinimizeMax(int[] nums, int p)
        {
            Array.Sort(nums);
            if (p == 0) return 0;
            //long left = 0;
            //long right = (long)Math.Pow(10, 9);
            //long res = (long)Math.Pow(10, 9);
            long left = 0;
            long right = nums.Max() + 1;
            long res = nums.Max() + 1;
            while (left <= right)
            {
                long mid = ( left + right) / 2;
                if (IsValid(nums, mid, p))
                {
                    res = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return res;

        }

        public static bool IsValid(int[] nums, long threshold, int p)
        {
            int i = 0, cnt = 0;
            while(i < nums.Length - 1)
            {
                var diff = Math.Abs(nums[i] - nums[i + 1]);
                if (Math.Abs(nums[i] - nums[i+1]) <= threshold)
                {
                    cnt += 1;
                    i += 2;
                }
                else
                {
                    i += 1;
                }
                if (cnt == p) return true;
            }
            return false;

        }

        public static int FindMax(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[right] >= nums[left]) return nums[right];
                int mid = (left + right) / 2;
                if (nums[left] > nums[mid] || nums[mid] > nums[right]) right = mid;
                else left = mid + 1;
            }
            return -1;
        }

        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] <= nums[right]) return nums[left];
                int mid = (left + right) / 2;
                if (nums[mid] >= nums[left]) left = mid + 1;
                else right = mid;
            }
            return -1;
        }
    

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = piles.Max();
            while(left < right)
            {
                int mid = left + (right-left)/ 2;
                int currentSum = 0;
                foreach(var pile in piles)
                {
                    currentSum += (int)Math.Ceiling((double)pile / mid);
                }
                if(currentSum <= h)
                {
                    //min = Math.Min(min, mid);
                    right = mid;
                }
                else if(currentSum > h)
                {
                    left = mid + 1;
                }
            }
            return left;

        }


    }
}
