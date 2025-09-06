using System.IO.Compression;

namespace MyApp;

public class StringOperation
{
    private char[] _vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    public int PrintVowel(string input)
    {
        var count = 0;
        foreach (var ch in input.ToLower())
        {
            if (_vowels.Contains(ch))
            {
                count++;
                Console.WriteLine(ch);
            }
        }

        return count;
    }

    //Problem:
    // Given a string s, reverse the order of words.
    // 
    // Words are separated by spaces.
    // 
    // Remove extra spaces.
    //Input:  "  the sky   is blue  "
    // Output: "blue is sky the"
    public string ReverseWords(string input)
    {
        var words = input.Split(" ");
        var inputs = words.ToList().Where(y => y.Trim().Length > 0).Reverse();
        return string.Join(" ", inputs);
    }

    public string ReverseWords2(string input)
    {
        var chars = input.Trim().ToCharArray();
        var str = ReverseStringArray(chars , 0 , chars.Length - 1);

        var start = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == ' ' || (i == str.Length - 1))
            {
                ReverseStringArray(str, start, i == str.Length - 1 ? i : i - 1);
                start = i + 1;
            }
        }
        return new string(str);
    }
    public string ReverseWordsIII(string s)
    {
        char[] chars = s.Trim().ToCharArray();
        int start = 0;
    
        for (int end = 0; end <= chars.Length; end++)
        {
            // when we hit a space or end of string → reverse the word
            if (end == chars.Length || chars[end] == ' ')
            {
                Reverse(chars, start, end - 1);
                start = end + 1;
            }
        }

        return new string(chars);
    }

    private char[] ReverseStringArray(char[] input, int l, int r)
    {
        while (l < r)
        {
            (input[r], input[l]) = (input[l], input[r]);
            l++;
            r--;
        }

        return input;
    }
    
    private void Reverse(char[] arr, int left, int right)
    {
        while (left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }
}