using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();
            //dict.Values.Sum();
            //[1,2,3,4,5], k = 4, x = 3
            //[1,3,-1,-3,5,3,6,7]
            var stArr = new string[] { "5", "2", "C", "D", "+" };
            var arr = new int[] { 8,6,9,3,5 };
            var str = "cabwefgewcwaefgcf";
            var t = "cae";
            
            string s1 = "ab", s2 = "eidbaooo";
            var res = CalPoints(stArr);

            
            //Queryable.Average(arr.AsQueryable())
            //1,2,2,2,3
            Console.WriteLine();
        }

        public static int CalPoints(string[] operations)
        {
            var stack = new Stack<int>();
            int res = 0;
            foreach (var s in operations)
            {
                char item = s[0];
                if (char.IsDigit(item))
                {
                    stack.Push(item);
                }
                else if (item == '+')
                {
                    var first = stack.Pop();
                    var second = stack.Pop();
                    var sum = first + second;
                    stack.Push(second);
                    stack.Push(first);
                    stack.Push(sum);
                }
                else if (item == 'D')
                {
                    var peek = stack.Peek()* 2;
                    stack.Push(peek);
                }
                else
                {
                    stack.Pop();
                }
            }
            while (stack.Count > 0)
            {
                res += stack.Pop();
            }
            return res;
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var queue = new LinkedList<int>();
            var res = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var window = i - k + 1;

                //check if the index at queue[0] is part of the current window
                while (queue.Count > 0 && queue.First.Value < window)
                {
                    queue.RemoveFirst();
                }

                var currentVal = nums[i];
                //maintain decreasing order
                while (queue.Count > 0 && nums[queue.Last.Value] < currentVal)
                {
                    queue.RemoveLast();
                }

                queue.AddLast(i);

                //if the window size is valid, add the max element to the res
                if (i >= k - 1)
                {
                    res.Add(nums[queue.First.Value]);
                }
            }
            return res.ToArray();
        }

        public static string MinWindow(string s, string t)
        {
            Dictionary<char, int> first = new Dictionary<char, int>();
            Dictionary<char, int> second = new Dictionary<char, int>();
            int left = 0, res = int.MaxValue, right = 0;
            var arr = new int[2];
            //populate the dicts
            for (int i = 0; i < t.Length; i++)
            {
                if (first.ContainsKey(t[i])) first[t[i]]++;
                else first[t[i]] = 1;

                //second
                if (!second.ContainsKey(t[i])) second[t[i]] = 0;
            }

            int have = 0, need = first.Count();

            while (right < s.Length)
            {
                //check if the element is in t
                var element = s[right];
                if (t.Contains(element))
                {
                    second[element]++;
                    if (second[element] == first[element]) have++;


                    while (have == need)
                    {
                        res = res > (right - left + 1) ? (right - left + 1) : res;
                        arr = new int[] { right, left };
                        var item = s[left];
                        left++;
                        if (second.ContainsKey(item))
                        {
                            second[item]--;
                            if (second[item] < first[item])
                            {
                                have--;
                            }
                        }
                    }

                }
                right++;
            }
            return res == int.MaxValue ? "" : s.Substring(arr[1], (arr[0] - arr[1]) + 1);
        }

        public static int MinOperations(int[] nums, int x)
        {
            int target = nums.Sum() - x;
            int min = int.MaxValue, left = 0, right = 0, total = 0, n = nums.Length;


            while (right < nums.Length)
            {
                total += nums[right];

                while (total > target)
                {
                    total -= nums[left];
                    left++;
                }

                if (total == target)
                {
                    min = Math.Min(min, (n - (right - left + 1)));
                }
                right++;
            }

            return min == int.MaxValue ? -1 : min;
        }
                
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int start = 0, end = arr.Length - 1;

            while (end - start >= k)
            {
                if (Math.Abs(x - arr[end]) < Math.Abs(x - arr[start]))
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            var newArr = new List<int>();
            //Array.Copy(arr, left,newArr,0,k);
            for (int i = 0; i < k; i++)
            {
                newArr.Add(arr[start]);
                start++;
            }
            return newArr;
        }

        public static int MinFlips(string s)
        {
            int n = s.Length;
            s += s;
            string alt1 = "", alt2 = "";

            //build the alts
            for (int i = 0; i < s.Length; i++)
            {
                alt1 += (i % 2 == 0) ? "0" : "1";
                alt2 += (i % 2 == 0) ? "1" : "0";
            }

            int res = int.MaxValue;
            int diff1 = 0, diff2 = 0;
            int l = 0;

            for (int r = 0; r < s.Length; r++)
            {
                if (s[r] != alt1[r])
                {
                    diff1++;
                }

                if (s[r] != alt2[r])
                {
                    diff2++;
                }

                if ((r - l + 1) > n)
                {
                    if (s[l] != alt1[l])
                    {
                        diff1--;
                    }

                    if (s[l] != alt2[l])
                    {
                        diff2--;
                    }

                    l++;
                }

                if ((r - l + 1) == n)
                {
                    res = Math.Min(res, Math.Min(diff1, diff2));
                }
            }

            return res;
        }

        public static int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0, right = 0, total = 0, min = int.MaxValue;
            while (right < nums.Length)
            {
                total += nums[right];

                if (total >= target)
                {
                    min = Math.Min(min, (right - left + 1));

                    while (total >= target)
                    {
                        total -= nums[left];
                        left++;
                        if(total >= target) min = Math.Min(min, (right - left + 1));
                        
                    }
                }
                right++;
            }
            return min;
        }

        public static int MaxVowels(string s, int k)
        {
            int left = 0, right = 0, max = 0, count = 0;
            string vowels = "aeiou", sub = "";

            while (right < s.Length)
            {
                //add right
                var str = s[right];
                sub += str;

                //check vowel
                if (vowels.Contains(str))
                {
                    count++;
                    max = Math.Max(max, count);
                }
                

                //remove left
                if (right - left + 1 == k)
                {
                    sub = sub.Remove(0, 1);
                    if (vowels.Contains(s[left]))
                    {
                        count--;
                    }
                    left++;
                }
                right++;

            }
            return max;

        }

        public static int TotalFruit(int[] fruits)
        {
            Array.Sort(fruits);
            int count = 0, left = 0, right = 0, max = 0, curr = 0;
            while (right < fruits.Length)
            {
                //check baskets
                if (right == 0 || fruits[right] != fruits[right - 1]) count++;

                //check if you can pick
                if (count <= 2)
                {
                    curr++;
                }
                else
                {
                    curr--;
                    count--;

                }

                max = Math.Max(max, curr);
                right++;

            }
            return max;
        }

        public static int MaxFrequency(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0, right = 0, total = 0, res = 0;

            while (right < nums.Length)
            {
                int target = nums[right];
                total += target;
                int window = right - left + 1;

                while ((target * window) - total > k)
                {
                    total -= nums[left];
                    left++;
                }
                res = Math.Max(res, window);
                right++;
            }
            return res;
        }

        public static bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;
            var first = new int[26];
            var second = new int[26];

            for (int i = 0; i < s1.Length; i++)
            {
                first[s1[i] - 'a']++;
                second[s2[i] - 'a']++;
            }

            int matches = 0;
            for (int i = 0; i < 26; i++)
            {
                if (first[i] == second[i]) matches++;
            }

            for (int i = 0; i < (s2.Length - s1.Length); i++)
            {
                var right = s2[i + s1.Length] - 'a';
                var left = s2[i] - 'a';

                if (matches == 26) return true;

                second[right]++;
                if (first[right] == second[right]) ++matches;
                else if (second[right] == first[right] + 1) --matches;

                second[left]--;
                if (first[left] == second[left]) ++matches;
                else if (second[left] == first[left] - 1) --matches;
            }
            return matches == 26;
        }

        //public static bool CheckInclusion(string s1, string s2)
        //{
        //    if (s1.Length > s2.Length) return false;

        //    int k = s1.Length, left = 0;
        //    var first = new int[26];
        //    foreach (var item in s1)
        //    {
        //        first[item - 'a']++;
        //    }

        //    var substr = s2.Substring(0, k - 1);
        //    var second = new int[26];
        //    foreach (var item in substr)
        //    {
        //        second[item - 'a']++;
        //    }

        //    while (left < (s2.Length - k + 1))
        //    {
        //        var right = left + k - 1;
        //        //substr += s2[right];
        //        second[s2[right] - 'a']++;
        //        if (Enumerable.SequenceEqual(second, first)) return true;
        //        var temp = s2[left];
        //        second[s2[left]-'a']--;
        //        left++;
        //    }

        //    return false;


        //}
        public static int LengthOfLongestSubstring(string s)
        {
            var str = "";
            int max = 0, left = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (str.Contains(s[i]))
                {
                    while (str.Contains(s[i]))
                    {
                        str = str.Remove(0,1);
                    }
                }
                str += s[i];
                max = Math.Max(max, str.Length);
            }
            
            return max;
        }

        public static int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int res = 0, left = 0;
            double total = arr.Take(k-1).Sum();

            for (int i = 0; i < arr.Length - k + 1; i++)
            {
                int right = left + k - 1;
                total += arr[right];
                if (total / (double)k >= threshold) res++;
                total -= arr[left];
                left++;
            }

            return res;

        }
    }
}
