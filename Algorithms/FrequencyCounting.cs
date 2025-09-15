using System.Net.NetworkInformation;

namespace MyApp;

public class FrequencyCounting
{
    public static int[] TopKFrequentElements(int[] nums, int k)
    {
        // Count frequency
        var freq = new Dictionary<int, int>();
        foreach (int n in nums)
        {
            if (!freq.ContainsKey(n))
                freq[n] = 0;
            freq[n]++;
        }

        // Sort by frequency and take top K
        return freq.OrderByDescending(x => x.Value)
            .Take(k)
            .Select(x => x.Key)
            .ToArray();
    }

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (var word in strs)
        {
            // Sort characters as key
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if (!map.ContainsKey(key))
                map[key] = new List<string>();

            map[key].Add(word);
        }

        return map.Values.ToList<IList<string>>();
    }

    //Remove Duplicates (from Sorted Array)
    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[j] != nums[i])
            {
                i++;
                nums[i] = nums[j];
            }
        }
        return i + 1; // length of unique elements
    }

    public static int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>(nums);
        int longest = 0;
    
        foreach (int num in set)
        {
            // Only start from sequence beginning
            if (!set.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                longest = Math.Max(longest, length);
            }
        }

        return longest;
    }
    public static int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        int left = 0, maxLen = 0;
        var map = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            char r = s[right];
            if (!map.ContainsKey(r)) map[r] = 0;
            map[r]++;

            while (map.Count > k)
            {
                char l = s[left];
                map[l]--;
                if (map[l] == 0)
                {
                    map.Remove(l);
                    left++;
                }
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

    public static int MinCoinDP(int[] coins, int amount)
    {
        int max = amount + 1;
        int[] dp = new int[amount + 1];
        Array.Fill(dp, max);
        dp[0] = 0;

        foreach (var coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
               dp[i] = Math.Min(dp[i], dp[i - coin] + 1);

                Console.WriteLine($"Amount: {i}, Coin: {coin}, DP: {string.Join(",", dp)}");
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }

    public static int[] Sorting(int[] nums)
    {
        return nums.OrderBy(n => n).ToArray();
    }

    public static User[] Sorting2(User[] users)
    {
        Array.Sort(users, (x, y) => x?.Name?.CompareTo(y.Name) ?? 0);
        return users;
    }
}

public class User
{
    public string? Name { get; set; }
    public int Age { get; set; }
}