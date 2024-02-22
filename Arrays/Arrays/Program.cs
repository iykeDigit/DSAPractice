// See https://aka.ms/new-console-template for more information

var str = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
var arr = new int[] { 1,1,1 };
//var res = QuickSortP(arr, 0, arr.Length-1);
var codec = new Codec();
var url = codec.Encode("https://leetcode.com/problems/design-tinyurl");
string haystack = "hello", needle = "ll";
var res = SubarraySum(arr, 2) ;
Console.WriteLine("Hello, World!");


static int StrStr(string haystack, string needle)
{
    if (haystack.Length < needle.Length) return -1;
    for (int i = 0; i < haystack.Length; i++)
    {
        if (needle[0] == haystack[i] && haystack.Substring(i).Length >= needle.Length)
        {
            var sub = haystack.Substring(i,needle.Length);
            if (sub == needle) return i;
        }
    }
    return -1;
}
static int SubarraySum(int[] nums, int k)
{
    var dict = new Dictionary<int, int>();
    int sum = 0, count = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        if (sum == k) count++;

        int diff = sum - k;
        count += dict.ContainsKey(diff) ? dict[diff] : 0;
        if (dict.ContainsKey(sum)) dict[sum]++;
        else dict[sum] = 1;
    }
    return count;
}

static int MinSwaps(string s)
{
    Stack<char> stack = new Stack<char>();
    int mismatch = 0;

    for (int i = 0; i < s.Length; i++)
    {
        char ch = s[i];
        if (ch == '[')
            stack.Push(ch);
        else
        {
            if (stack.Count > 0)
                stack.Pop();
            else
                mismatch++;
        }
    }

    return (mismatch + 1) / 2;
}

static int MaxProfit(int[] prices)
{
    int left = 0, right = 1, profit = 0;
    while (right < prices.Length)
    {
        if (prices[right] > prices[left])
        {
            profit += prices[right] - prices[left];
        }
        left++;
        right++;
    }
    return profit;
}

static int LeastBricks(IList<IList<int>> wall)
{
    var dict = new Dictionary<int, int>();
    int max = 0;
    foreach(var item in wall)
    {
        int total = 0;
        for(int i = 0; i < item.Count-1; i++)
        {
            total += item[i];
            if (!dict.ContainsKey(total))
            {
                dict[total] = i;
            }
            else
            {
                dict[total]++;
            }
            max = Math.Max(max, dict[total]);
        }

    }
    return wall.Count - max;
}

static void SortColors(int[] nums)
{
    int curr = 0, i = 0, j = nums.Length - 1;

    while (curr <= j)
    {
        if (nums[curr] == 0)
        {
            int temp = nums[curr];
            nums[curr++] = nums[i];
            nums[i++] = temp;
        }
        else if (nums[curr] == 2)
        {
            int temp = nums[curr];
            nums[curr] = nums[j];
            nums[j--] = temp;
        }
        else
        {
            curr++;
        }
    }

}

#region MergeSort
static int[] MergeSort(int[] arr, int left, int right)
{
    if(left < right)
    {
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
    return arr;
}

static void Merge(int[] arr, int left, int mid, int right)
{
    //find the left of the left and right sub arrays
    int leftLength = mid - left + 1;
    int rightLength = right - mid;

    //create tmp arrays
    var tmpLeft = new int[leftLength];
    var tmpRight = new int[rightLength];

    //copy the sub arrays to tmp
    for(int a = 0; a < leftLength; a++)
    {
        tmpLeft[a] = arr[a + left];
    }

    for(int b = 0; b < rightLength; b++)
    {
        tmpRight[b] = arr[mid + 1 + b];
    }

    //initialize indexes
    int i = 0, j = 0, pointer = left;
    //merge subarrays into original
    while(i < leftLength && j < rightLength)
    {
        if (tmpLeft[i] <= tmpRight[j])
        {
            arr[pointer] = tmpLeft[i];
            i++;
        }
        else
        {
            arr[pointer] = tmpRight[j];
            j++;
        }
        pointer++;
    }

    //merge the remnant
    //if left
    while(i < leftLength)
    {
        arr[pointer] = tmpLeft[i];
        i++;
        pointer++;
    }

    //if right
    while (j < rightLength)
    {
        arr[pointer] = tmpRight[j];
        j++;
        pointer++;
    }
}

#endregion

static int[] QuickSort(int[] arr, int s, int e)
{
    //n log n
    if (e - s + 1 <= 1) return arr;

    int pivot = arr[e];
    int left = s;

    for(int i = s; i< e; i++)
    {
        if (arr[i] < pivot)
        {
            int tmp = arr[left];
            arr[left] = arr[i];
            arr[i] = tmp;
            left++;
        }
    }

    arr[e] = arr[left];
    arr[left] = pivot;

    //left
    QuickSort(arr, s, left - 1);

    //right
    QuickSort(arr, left + 1, e);

    return arr;
}

IList<IList<string>> GroupAnagrams(string[] strs)
{
    var groups = new Dictionary<string, IList<string>>();

    foreach (string s in strs)
    {
        char[] hash = new char[26];
        foreach (char c in s)
        {
            hash[c - 'a']++;
        }

        string key = new string(hash);
        if (!groups.ContainsKey(key))
        {
            groups[key] = new List<string>();
        }
        groups[key].Add(s);
    }
    return groups.Values.ToList();
}

static IList<IList<int>> Generate(int numRows)
{
    var itr = 1;
    var res = new List<IList<int>>();

    while(itr <= numRows)
    {
        var list = new List<int>();
        for(int i  = 0; i < itr; i++)
        {
            if(i == 0 || i == itr - 1)
            {
                list.Add(1);
            }
            else
            {
                list.Add(res[itr - 2][i - 1] + res[itr - 2][i]);
            }
        }
        res.Add(list);
        itr++;
    }
    return res;
}
static bool ContainsDuplicate(int[] nums)
{
    var set = new HashSet<int>();
    foreach (var item in nums)
    {
        if (!set.Add(item)) return true;
        else
        {
            set.Add(item);
        }
    }
    return false;
}

//Time O(26)
//Space O(26)
static bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length) return false;
    int[] first = new int[26], second = new int[26];
    for (int i = 0; i < s.Length; i++)
    {
        first[s[i] - 'a']++;
        second[t[i] - 'a']++;
    }

    for (int i = 0; i < first.Length; i++)
    {
        if (first[i] != second[i]) return false;
    }
    return true;
}

static string Decode(string messageFile)
{
    // Read the contents of the file
    string[] lines = File.ReadAllLines(messageFile);

    // Extract numbers from each line
    List<int> numbers = lines.Select(line => int.Parse(line.Split()[0])).ToList();

    // Extract corresponding words based on the pyramid structure
    List<string> words = lines.Where((line, index) => numbers.Contains(index + 1))
                              .Select(line => line.Split()[1])
                              .ToList();

    // Join the words into a string, convert to lowercase, remove punctuation and trim
    string decodedMessage = string.Join(" ", words)
                                .ToLower()
                                .Trim();

    // Remove punctuation
    // decodedMessage = Regex.Replace(decodedMessage, @"[^\w\s]", "");

    return decodedMessage;
}

public class Codec
{
    private Dictionary<int, string> map = new Dictionary<int, string>();
    private int i = 0;

    //Encode
    public string Encode(string longUrl)
    {
        map[i] = longUrl;
        return "http://tinyurl.com/" + i++;

    }

    // Decodes a shortened URL to its original URL.
    public string Decode(string shortUrl)
    {
        var res = shortUrl.Replace("http://tinyurl.com/", "");
        return map[int.Parse(shortUrl.Replace("http://tinyurl.com/", ""))];
    }
}
