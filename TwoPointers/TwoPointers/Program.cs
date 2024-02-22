using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = "abc";
            Console.WriteLine(m.Substring(0, 2));
            var str = "abc";
            var arr = new int[] { 7, 1, 5, 3, 6, 4 };
            var res = MaxProfit(arr);

            Console.WriteLine("Hello World!");
        }

        public static int MaxProfit(int[] prices)
        {
            int left = 1, max = 0, curr = prices[0];
            while (left < prices.Length)
            {
                if (curr < prices[left])
                {
                    curr = prices[left];
                    left++;
                }
                else
                {
                    var profit = Math.Abs(curr - prices[left]);
                    max = Math.Max(max, profit);
                    left++;
                }
            }
            return max;
        }

        public static int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            int left = 0, right = nums.Length - 1, result = 0;
            int mod = 1000000007;
            int[] power = new int[nums.Length];
            power[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                // We need to modulo as it is going out bounds which is giving us the incorrect result.
                power[i] = (power[i - 1] * 2) % mod;
            }
            while (left <= right)
            {
                if (nums[left] + nums[right] <= target)
                {
                    result += power[right - left];
                    // We need to modulo as it is going out bounds which is giving us the incorrect result.
                    result = result % mod;
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return result;
        }

        #region 4Sum
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return kSum(nums, target, 0, 4);
        }

        public static IList<IList<int>> kSum(int[] nums, long target, int start, int k)
        {
            List<IList<int>> res = new();
            if(start == nums.Length)
            {
                return res;
            }

            long average = target / k;
            if (nums[start] > average || average > nums[nums.Length - 1]) return res;

            if(k == 2)
            {
                return twoSum(nums, target, start);
            }

            for(int i = start; i < nums.Length; i++)
            {
                if(i == start || nums[i] != nums[i - 1])
                {
                    foreach(var subSet in kSum(nums, target-nums[i], i+1, k - 1))
                    {
                        var list = new List<int> { i };
                        list.AddRange(subSet);
                        res.Add(list);
                    }
                }
            }
            return res;

        }

            public static IList<IList<int>> twoSum(int[] nums, long target, int start)
            {
                List<IList<int>> res = new List<IList<int>>();
                int lo = start, hi = nums.Length - 1;

                while (lo < hi)
                {
                    int currSum = nums[lo] + nums[hi];
                    if (currSum < target || (lo > start && nums[lo] == nums[lo - 1]))
                    {
                        ++lo;
                    }
                    else if (currSum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                    {
                        --hi;
                    }
                    else
                    {
                        res.Add(new List<int> { nums[lo++], nums[hi--] });
                    }
                }

                return res;
            }
        

        #endregion
        public static int[] RearrangeArray(int[] nums)
        {
            Array.Sort(nums);
            int right = nums.Length - 1, left = 0;
            var arr = new int[nums.Length];
            int index = 0;
            while (index != nums.Length)
            {
                arr[index] = nums[left];
                index++;
                left++;
                if (left <= right)
                {
                    arr[index] = nums[right];
                    index++;
                    right--;
                }
            }
            return arr;
        }

        public static int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int left = 0, right = people.Length - 1, boats = 0;
            while(left <= right)
            {
                if((people[left] + people[right]) <= limit)
                {
                    left++;
                }
                right--;
                boats++;
            }
            return boats;
        }

        public static int[] Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
            return nums;
        }

        private static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

            //public static void Rotate(int[] nums, int k)
            //{
            //    int[] output = new int[nums.Length];

            //    int length = nums.Length;
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        output[(i + k) % length] = nums[i];
            //    }
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        nums[i] = output[i];
            //    }
            //}


           

    public static List<List<int>> GenerateSubsequences(int[] arr)
        {
            var result = new List<List<int>>();
            GenerateSubsequencesHelper(arr, 0, new List<int>(), result);
            return result;
        }

        private static void GenerateSubsequencesHelper(int[] arr, int index, List<int> current, List<List<int>> result) 
        {
            if(index == arr.Length)
            {
                result.Add(new List<int> (current));
                return;
            }
            // Include the current element in the subsequence
            current.Add(arr[index]);
            GenerateSubsequencesHelper(arr, index + 1, current, result);

            // Exclude the current element from the subsequence
            current.RemoveAt(current.Count - 1);
            GenerateSubsequencesHelper(arr, index + 1, current, result);
        }

        public static int MaxArea(int[] height)
        {
            int[] nums = height;
            int left = 0, right = height.Length - 1;
            int max = 0;
            while (left < right)
            {
                if (nums[left] < nums[right])
                {
                    max = Math.Max(max, (nums[left] * (right - left)));
                    left++;
                }
                else
                {
                    max = Math.Max(max, (nums[right] * (right - left)));
                    right--;
                }
            }
            return max;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var res = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    int left = i+1, right = nums.Length - 1;
                    while (left < right)
                    {
                        int sum = 0 - nums[i];
                        if (nums[left] + nums[right] > sum) right--;
                        else if (nums[left] + nums[right] < sum) left++;
                        else
                        {
                            var list = new List<int> { nums[i], nums[left], nums[right] };
                            res.Add(list);
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                        };
                    }
                }
            }
            return res;
        }


        public static  void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int x = m + n - 1;
            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] >= nums2[n - 1])
                {
                    nums1[x] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[x] = nums2[n - 1];
                    n--;
                }
                x--;
            }
            if (n > 0) Array.Copy(nums2, 0, nums1, 0, n);
    }

        public static int MinimumDifference(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0, right = k - 1;
            int res = int.MaxValue;
            while (right < nums.Length)
            {
                var m = nums[right];
                var y = nums[left];
                res = Math.Min(res, nums[right] - nums[left]);
                left++;
                right++;
            }
            return res;
        }

        #region Valid Palindrome: 680
        public bool ValidPalindrome(string s)
        {
            s = s.ToLower();
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return (IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1));
                }
                left++;
                right--;
            }
            return true;
        }

        public bool IsPalindrome(string s, int left, int right)
        {

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }
        #endregion

        #region 125. Valid Palindrome
        public static bool IsPalindromeOne(string s)
        {
            int left = 0, right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;
                Console.WriteLine($"left: {left}:  {s[left]}");
                Console.WriteLine($"{right}: right: {s[right]}");
                if (s[left] != s[right]) return false;
                left++;
                right--;
            }
            return true;
        }
        #endregion

    }
}
