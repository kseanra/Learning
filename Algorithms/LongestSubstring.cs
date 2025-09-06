using System.Text.RegularExpressions;

namespace MyApp;

//Problem:
// Given a string s, find the length of the longest substring without repeating characters.
public class LongestSubstring
{
    private string _input;
    public LongestSubstring(string input)
    {
        this._input = input;
    }

    public string LongestSubstringBruteForce()
    {
        var finalList = new List<string>();
        for (int i = 0; i < this._input.Length; i++)
        {
            var substrings = new List<string>();
            for (int j = i + 1; j < this._input.Length; j++)
            {
                substrings.Add(this._input.Substring( i , j - i ));
            }
            substrings.ForEach(x =>
                {
                    bool hasRepeat = false;
                    for (int j = 0; j < x.Length; j++)
                    {
                        var set = x.ToCharArray();
                        if (set.Where(y => y == x[j]).Count() > 1)
                        {
                            hasRepeat = true;
                            break;
                        }
                    }

                    if (!hasRepeat)
                    {
                        finalList.Add(x);
                    }
                }
            );
        }
        
        return finalList.OrderBy(w => w.Length).ToList().Last();
    }
    
    public string LongestSubstringBruteForce2()
    {
        var finalList = new List<string>();
        string mexLength = "";
        for (int i = 0; i < this._input.Length; i++)
        {
            for (int j = i + 1; j < this._input.Length; j++)
            {
                var substring = this._input.Substring(i, j - i);
                if(IsCharUniq(substring))
                    finalList.Add(substring);
            }
        }

        return finalList.OrderBy(w => w.Length).ToList().Last();
    }

    //Logic when value is "abcabcbb"
    //seen["a"] = 0; MaxLen : 1    left :   0  
    //seen["b"] = 1; MaxLen : 2             0
    //seen["c"] = 2;          3             0
    //seen["a"] = 3           3             1
    //seen["b"] = 4;          3             2
    //seen["c"] = 5;          3             3
    //seen["b"] = 6;          2             5
    
    //idea only litrate once
    // star from 1st
    // if has not seen it before, store the char, left remain
    // if seen it before, set the left = index + 1 (new count start point)
    //      calculate the maxlen (current index - last seen char + 1 ) compare with last maxlen
    public int LengthOfLongestSubstring()
    {
        Dictionary<char, int> seen = new Dictionary<char, int>();
        int left = 0, maxLen = 0;
        
        for (int right = 0; right < this._input.Length; right++)
        {
            char c = this._input[right];

            if (seen.ContainsKey(c) && seen[c] >= left)
            {
                left = seen[c] + 1;
            }

            seen[c] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

    private bool IsCharUniq(string substring)
    {
        HashSet<char> set = new HashSet<char>();
        foreach (var ch in substring)
        {
            if(!set.Add(ch)) return false;
        }

        return true;
    }
}