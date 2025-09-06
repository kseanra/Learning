namespace MyApp;

// //Two sum problem
//Given an array of integers nums and an integer target,
//return indices of the two numbers such that they add up to target.
public class TwoSumProblem
{
    int[] numbers = {};
    private int target = 0;

    public TwoSumProblem(int[] numbers, int target) 
    {
        this.numbers = numbers;
        this.target = target;
    }

    public IEnumerable<int[]> BruteForceSolution()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == this.target)
                {
                    yield return new int[] { i, j };
                }
            }
        }
    }

    public IEnumerable<int[]> HashMap()
    {
        var nums = new Dictionary<int, int>();
        
        for (int i = 0; i < this.numbers.Length; i++)
        {
            var complement = target - this.numbers[i];
            if (nums.Count() > 0 && nums.ContainsKey(complement))
            {
                yield return new int[] { nums[complement], i };
            }
            else
            {
                nums[this.numbers[i]] = i;
            }
            
        }
    }
}