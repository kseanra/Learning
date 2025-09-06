namespace MyApp;

//prefix sums and difference arrays are must-know patterns. They show up in HackerRank, LeetCode,
//and coding screens because they reduce repeated work from O(n) per query to O(1) per query after preprocessing.
public class PrefixSum
{
    private int[] _perfix;
    public PrefixSum(int[] nums)
    {
        // initial list of the value
        // So that it won't need to itlatire it again
        _perfix = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            _perfix[i + 1] = _perfix[i] + nums[i];
        }
    }

    //Problem:
    // Given an array nums, answer multiple queries of the form:
    // sum(i, j) = nums[i] + nums[i+1] + ... + nums[j].
    public int RangeSum(int left, int right)
    {
        return _perfix[right + 1] - _perfix[left];
    }

    //Problem:
    // Given an array nums, apply multiple range updates of the form:
    // “Add val to all elements from l to r.”
    public int[] ApplyRangeUpdates(int n, List<(int l, int r, int val)> updates)
    {
        int[] diff = new int[n + 1];

        foreach (var (l, r, val) in updates)
        {
            var idx = l;
            while (idx<= r)
            {
                diff[idx] += val;
                idx++;
            }
        }

        return diff;
    }
    
    //Difference Array (Efficient Range Updates)
    //Problem:
    // Given an array nums, apply multiple range updates of the form:
    // “Add val to all elements from l to r.”
    // idea is to work out the different value between left and right
    // sum the left and store the different in right (mostly will be nagitivate number)
    // the file result array could use just sum element nums[i] + nums[i+1] + ... + nums[j]
    public int[] ApplyRangeUpdates2(int n, List<(int l, int r, int val)> updates)
    {
        int[] diff = new int[n + 1];

        foreach (var (l, r, val) in updates)
        {
            diff[l] += val;
            
            // store the value for takeway in index i + 1
            if (r + 1 < diff.Length)
            {
                diff[r + 1] -= val;
            }
        }

        var result = new int[n];
        int running = 0;
        for (int i = 0; i < n; i++)
        {
            running += diff[i];
            result[i] += running;
        }

        return result;
    }
}