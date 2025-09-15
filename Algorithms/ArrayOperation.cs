using System.Text.Json;
using System.Text.Json.Serialization;
namespace MyApp;

public class ArrayOperation
{
    //Problem:
    // Given an array nums, rotate it to the right by k steps, in-place.
    //Step by step:
    // 
    // Rotate by 1 → [1, 2, 3, 4, 5, 6,7]
    // Rotate by 1 → [7, 1, 2, 3, 4, 5, 6]
    // 
    // Rotate by 2 → [6, 7, 1, 2, 3, 4, 5]
    // 
    // Rotate by 3 → [5, 6, 7, 1, 2, 3, 4]

    // Repeat K times
    // Take the last value and put it in the front
    public int[] ArrayRotateBruteForce(int[] nums, int k)
    {
        var lastIndex = nums.Length - 1;
        IEnumerable<int> result = nums;
        for (int i = 0; i < k; i++)
        {
            var lastValue = result.Skip(lastIndex);
            var tmp = result.Take(lastIndex);
            result = lastValue.Concat(tmp);
        }

        return result.ToArray();
    }

    //nums = [1,2,3,4,5,6,7], k=3
    // 
    // Reverse all → [7,6,5,4,3,2,1]
    // 
    // Reverse first k=3 → [5,6,7,4,3,2,1]
    // 
    // Reverse rest → [5,6,7,1,2,3,4]
    public int[] ArrayRotateBrute(int[] nums, int k)
    {
        int n = nums.Length;

        //3. What if k > n?
        // 
        // Suppose n = 7, k = 10.
        // 
        // Rotating 10 steps = rotating 10 - 7 = 3 steps, because every extra full cycle of n steps brings the array back to the same place.
        k = k % n;

        Array.Reverse(nums);
        Reverse(0, k - 1, nums);
        Reverse(k, n - 1, nums);

        return nums;
    }

    private int[] Reverse(int left, int right, int[] nums)
    {
        while (left < right)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }

        return nums;
    }
    
    private int[] MovePosition(int[] nums, int from, int to)
    {
        if (from == to) return nums;

        int temp = nums[from];
        if (from < to)
        {
            for (int i = from; i < to; i++)
            {
                nums[i] = nums[i + 1];
            }
        }
        else
        {
            for (int i = from; i > to; i--)
            {
                nums[i] = nums[i - 1];
            }
        }

        nums[to] = temp;
        return nums;
    }
    
}