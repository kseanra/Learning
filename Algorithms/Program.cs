using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting app...");

            // Sum Problem
            Console.WriteLine("... Sum Problem");
            var twoSumProblem = new TwoSumProblem([2, 7, 11, 15], 9);
            var result = twoSumProblem.BruteForceSolution();
            result.ToList().ForEach(r => Console.WriteLine(string.Join(", ", r)));

            result = twoSumProblem.HashMap();
            result.ToList().ForEach(r => Console.WriteLine(string.Join(", ", r)));

            // find longest substring
            Console.WriteLine("... find longest substring");
            var findLongestSubstring = new LongestSubstring("abcabcbb");
            Console.WriteLine(findLongestSubstring.LengthOfLongestSubstring("abcabcbb"));


            //Maximum Sum Subarray of Size K
            Console.WriteLine("... Maximum Sum Subarray of Size K");
            var maximumSumSubarray = new MaximumSumSubarray([2, 1, 5, 1, 3, 2], 3);
            Console.WriteLine(maximumSumSubarray.MaxSumSubarrayOfSizeKBruteForce());
            Console.WriteLine(maximumSumSubarray.MaxSumSubarrayOfSize());

            //RangeSum
            Console.WriteLine("... RangeSum");
            var rangeSum = new PrefixSum(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(rangeSum.RangeSum(1, 3)); // 2+3+4 = 9
            Console.WriteLine(rangeSum.RangeSum(0, 4)); // 1+2+3+4+5 = 15.RangeSum(0, 4)); // 1+2+3+4+5 = 15

            Console.WriteLine("... ApplyRangeUpdates");
            var updates = new List<(int, int, int)> { (1, 3, 2), (2, 4, 3) };
            Console.WriteLine(string.Join(",", rangeSum.ApplyRangeUpdates(5, updates))); // 1+2+3+4+5 = 15
            Console.WriteLine(string.Join(",", rangeSum.ApplyRangeUpdates2(5, updates))); // 1+2+3+4+5 = 15

            //Balancing Brackets (Prefix Sum Trick)
            Console.WriteLine("...Balancing Brackets (Prefix Sum Trick)");
            var balancingBrackets = new BalancingBrackets();
            Console.WriteLine(balancingBrackets.IsBalanceBruteForce("()()"));   // true
            Console.WriteLine(balancingBrackets.IsBalanceBruteForce("(()"));    // false
            Console.WriteLine(balancingBrackets.IsBalanceBruteForce("())("));   // false

            //solution for the problem of In-place operations (rotate array, reverse words in a string)
            Console.WriteLine("...solution for the problem of In-place operations (rotate array, reverse words in a string)");
            var arrayOptions = new ArrayOperation();
            var arrayResult = arrayOptions.ArrayRotateBruteForce([1, 2, 3, 4, 5, 6, 7], 10);
            Console.WriteLine(JsonSerializer.Serialize(arrayResult));
            arrayResult = arrayOptions.ArrayRotateBrute([1, 2, 3, 4, 5, 6, 7], 10);
            Console.WriteLine(JsonSerializer.Serialize(arrayResult));

            //string and vowel
            Console.WriteLine("...string and vowel");
            var stringOpertation = new StringOperation();
            Console.WriteLine("Total vowels:" + stringOpertation.PrintVowel("Hello World! This is a test file."));

            Console.WriteLine(stringOpertation.ReverseWords("  the sky   is blue  "));
            Console.WriteLine(stringOpertation.ReverseWords2("  the sky   is blue  "));
            Console.WriteLine(stringOpertation.ReverseWordsIII("  the sky   is blue  "));

            var frequencyCounting1 = FrequencyCounting.LongestConsecutive(new int[] { 100, 4, 101, 102, 103, 104, 1, 3, 2 });
            Console.WriteLine(frequencyCounting1);
            var frequncyCounting2 =
                FrequencyCounting.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            Console.WriteLine(JsonSerializer.Serialize(frequncyCounting2));
            var abc = FrequencyCounting.LengthOfLongestSubstringKDistinct("hgjaguayuygdw", 3);
            Console.WriteLine(abc);

            var minCoin = FrequencyCounting.MinCoinDP(new int[] { 1, 2, 5 }, 11);
            Console.WriteLine(minCoin);
        }
    }
}