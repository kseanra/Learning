namespace MyApp;

//Problem:
// Given an array of integers and a number k, find the maximum sum of any contiguous subarray of size k.
public class MaximumSumSubarray
{
    private int[] _nums;
    private int _k;
    
    public MaximumSumSubarray(int[] nums, int k)
    {
        this._nums = nums;
        this._k = k;
    }

    public int MaxSumSubarrayOfSizeKBruteForce()
    {
        int maxSum = 0;
        for (int i = 0; i < this._nums.Length; i++)
        {
            var sum = 0;
            for (int j = 0; j < this._k; j++)
            {
                if(i + this._k < this._nums.Length)
                    sum += this._nums[i + j];
            }
            // Console.WriteLine(sum);
            maxSum = Math.Max(maxSum, sum);
        }

        return maxSum;
    }

    //1.inital the first two array 
    //2. + right num then - first left value, compare the max 
    //3. set the new left 
    public int MaxSumSubarrayOfSize()
    {
        int maxSum = 0, windowsSum = 0;

        for (int i = 0; i < _k; i++)
        {
            windowsSum += _nums[i];
        }

        maxSum = windowsSum;
        for (int i = _k; i < _nums.Length; i++)
        {
            windowsSum += _nums[i] - _nums[i - _k];
            maxSum = Math.Max(windowsSum, maxSum);
        }

        return maxSum;
    }
    
}