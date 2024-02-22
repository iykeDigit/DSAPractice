using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(5-'0');
            var str  = "leet**cod*e";
            var pushed = new int[] {3,5,7 };
            var temps = new int[] { 2, 1, 5, 6, 2, 3 };
           
           
            //var stockSpanner = new StockSpanner();
            //stockSpanner.Next(31); // return 1
            //stockSpanner.Next(41);  // return 1
            //stockSpanner.Next(48);  // return 1
            //stockSpanner.Next(59);  // return 2
            //stockSpanner.Next(79);  // return 1

            var res = LargestRectangleArea(temps);
            Console.WriteLine();
        }

        public static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length, max = 0;
            var stack = new Stack<int>();
            for (int i = 0; i <= n; i++)
            {
                var height = i < n ? heights[i] : 0;
                while (stack.Count != 0 && heights[stack.Peek()] > height)
                {
                    var currHeight = heights[stack.Pop()];
                    var prevIndex = stack.Count == 0 ? -1 : stack.Peek();
                    max = Math.Max(max, currHeight * (i - 1 - prevIndex));
                }
                stack.Push(i);
            }

            return max;
        }

        public static string DecodeString(string s)
        {
            var stack = new Stack<string>();
            var res = "";
            foreach(var item in s) 
            {
                if(item != ']') 
                {
                    stack.Push(item.ToString());
                }
                else
                {
                    var substr = "";
                    while(stack.Peek() != "[")
                    {
                        substr = stack.Pop() + substr;
                    }
                    stack.Pop();
                    var num = "";
                    while (stack.Any() && char.IsDigit(stack.Peek().ToCharArray()[0]))
                    {
                        num = stack.Pop() + num;
                    }
                    substr = String.Concat(Enumerable.Repeat(substr, int.Parse(num)));
                    
                    stack.Push(substr);
                }
            }
            while (stack.Any())
            {
                res = stack.Pop() + res;
            }
            return res;
        }

        public static string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            var parts = path.Split('/');
            foreach(var part in parts) 
            {
                if (part == "..")
                {
                    if (stack.Any()) stack.Pop();
                }
                else if (part != "." && part != "") stack.Push(part);
            }
            var res = new StringBuilder();
            while (stack.Count > 0)
            {
                res.Insert(0, stack.Pop());
                res.Insert(0, "/");
            }
            return res.Length == 0 ? "/" : res.ToString();
        }

        public static int CarFleet(int target, int[] position, int[] speed)
        {
            List<(int, int)> pair = new List<(int, int)>();
            for (int i = 0; i < position.Length; i++)
            {
                pair.Add((position[i], speed[i]));
            }
            pair.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            List<double> stack = new List<double>();
            foreach (var (p, s) in pair)
            {
                stack.Add((double)(target - p) / s);
                if (stack.Count >= 2 && stack[^1] <= stack[^2])
                {
                    stack.RemoveAt(stack.Count - 1);
                }
            }
            return stack.Count;
        }

        public class StockSpanner
        {
            private Stack<KeyValuePair<int, int>> stack;

            public StockSpanner()
            {
                stack = new Stack<KeyValuePair<int, int>>();
            }

            public int Next(int price)
            {
                var span = 1;
                while (stack.Count > 0)
                {
                    if (stack.Peek().Key > price) { break; }
                    else
                    {
                        var pop = stack.Pop().Value;
                        span += pop;
                    }
                }
                stack.Push(new KeyValuePair<int, int>(price, span));
                return span;
            }
        }




        static List<string> result = new List<string>();
        static int maxLen;

        public static int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];
            int hottest = 0;
            //iterate from behind
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                if (temperatures[i] >= hottest)
                {
                    hottest = temperatures[i];
                    continue;
                }

                else
                {
                    int days = 1;
                    while (temperatures[i] >= temperatures[days + i])
                    {
                        days += result[days + i];
                    }
                    result[i] = days;
                }
            }
            return result;
        }

        public static int[] Test()
        {
            var stack = new Stack<int>();
            return stack.ToArray();
        }
        public static IList<string> GenerateParenthesis(int n)
        {

            maxLen = n;
            GenerateAndCheck("", 0, 0);
            return result;
        }

        private static void GenerateAndCheck(string str, int opened, int closed)
        {
            if (opened == closed && opened == maxLen)
            {
                result.Add(str);
                return;
            }

            if (opened < maxLen)
                GenerateAndCheck(str + "(", opened + 1, closed);
            if (closed < opened)
                GenerateAndCheck(str + ")", opened, closed + 1);
        }

        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int push = 0, pop = 0;

            while (pop < popped.Length)
            {
                if (stack.Count > 0 && stack.Peek() == popped[pop])
                {
                    stack.Pop();
                    pop++;
                }
                else if (push < pushed.Length) stack.Push(pushed[push++]);
                else return false;
            }

            return true;
        }

        public static string RemoveStars(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '*') stack.Pop();
                else stack.Push(s[i]);
            }

            stack.Reverse();
            return string.Concat(stack.Reverse());
        }
    }
}
