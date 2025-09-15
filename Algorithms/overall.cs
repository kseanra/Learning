using System;
using System.Collections.Concurrent;
using System.Text.Json;

public class ProducerConsumer {
    private BlockingCollection<int> queue;
    
    public ProducerConsumer(int capacity) {
        this.queue = new BlockingCollection<int>(capacity);
    }
    
    public void Producer(){
        for(int i = 0; i < 20; i++) {
            this.queue.Add(i);
            Console.WriteLine($"Produced {i}");
        }
        this.queue.CompleteAdding();
    }
    
    public void Consumer() {
        foreach(var item in queue.GetConsumingEnumerable()){
            Console.WriteLine($"Consumer {item}");
        }
    }
}

public class LruCache {
    
    private int capacity;
    private Dictionary<int, LinkedListNode<(int key, int val)>> map;
    private LinkedList<(int key, int val)> list;
    
    public LruCache(int capacity){
        this.capacity = capacity;
        map = new Dictionary<int, LinkedListNode<(int, int)>>();
        list = new LinkedList<(int, int)>();
    }
    
    public int Get(int key){
        if(!map.ContainsKey(key)) return -1;
        var node = map[key];
        list.Remove(node);
        list.AddFirst(node);
        Console.WriteLine(JsonSerializer.Serialize(list.ToDictionary()));
        return node.Value.val;
    }
    
    public void Put(int key, int val){
        
        if(map.ContainsKey(key)){
            var node = map[key];
            list.Remove(node);
        }
        else if(map.Count == this.capacity) {
            var last = list.Last;
            map.Remove(last?.Value.key ?? 0);
            list.RemoveLast();
        }
        
        var newNode = new LinkedListNode<(int, int)>((key, val));
        list.AddFirst(newNode);
        map[key] = newNode; 
        //Console.WriteLine(string.Join(", ", map.Select(kvp => $"[{kvp.Key}: ({kvp.Value.Value.key}, {kvp.Value.Value.val})]")));
        Console.WriteLine(JsonSerializer.Serialize(list.ToDictionary()));
    }
    
}

public class FactorySingletonPattern {
    
    interface IFactorySingleton { void Run();}

    class FactorySingleton: IFactorySingleton {
        
        class Product {}
        
        class SingletonFactory() {
            
            private Product? _product;
            
            public Product GetInstance() {
                if(_product == null) 
                    _product = new Product();
                    
                return _product;
            }
        }
        
        public void Run() {
            Console.WriteLine("run sample");
        }
    }

}

public class ObserverMediatorPatter{
    interface IObserver { void Run();}
    
    class Observer : IObserver {
        public void Run() {
            Console.WriteLine("Run simple");
        }
    }
    
    class Mediator {
        private List<IObserver> _observers = new List<IObserver>();
        
        public void Reigister(IObserver observer) {
            _observers.Add(observer);
        }
        
        public void NotifiyAll() {
            foreach(var observer in _observers) {
                observer.Run();
            }
        }
    }
}



public class FacadeCommandPattern {
    interface ICommand { void Run();}
    
    class Facade { 
        public void Run () {
        Console.WriteLine("Do work");
    }}

    class FacadeCommand : ICommand {
        private Facade _facade;
        public FacadeCommand(Facade facade) {
            _facade = facade;
        }
        
        public void Run() {
            _facade.Run();
        }
    }
}



class Solution {
    
    
   static int[] TwoSum(int[] nums, int target) {
    
        var map = new Dictionary<int, int>();
        
        for(var i = 0 ; i < nums.Length; i++){
            
            var comp = target - nums[i];
            if(map.ContainsKey(comp))
                return new int[] { map[comp], i};
                
            if(!map.ContainsKey(comp)){
                map[nums[i]] = i;
            }
        }
        return Array.Empty<int>();
   }
   
   static int MaxSubArray(int[] nums){
    
        int current = nums[0], maxSofar = nums[0];
        
        for(var i = 0; i < nums.Length; i++) {
            
            current = Math.Max(nums[i], current + nums[i]);
            maxSofar = Math.Max(maxSofar, current);
        }
        
        return maxSofar;
   }
   
   static int BinarySearch(int[] nums, int target){
       int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target) 
                return mid;

            // Left side is sorted
            if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            // Right side is sorted
            else
            {
                if (nums[mid] < target && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return -1;
   }
   
   static int[] TopKFrequent(int[] nums, int k){
        
        var freq = new Dictionary<int, int>();
        foreach(var n in nums){
            freq[n] = freq.GetValueOrDefault(n, 0) +1;
        }
        
        return freq.OrderByDescending(x => x.Value).Take(k).Select(x => x.Value).ToArray() ;   
   }
   
    static int CoinChange(int[] coins, int amount){
       int[] dp = new int[amount + 1];
       Array.Fill(dp, amount);
       dp[0] = 0;
       
       foreach(var coin  in coins){
         for(var i = coin; i < amount ; i++){
            dp[i] = Math.Min(dp[i], dp[i - coin] + 1 );
         }
       }
       
       return dp[amount] > amount ? -1 : dp[amount];
    }
    
    static int EraseOverlapIntervals(int[][] intervals){
        Array.Sort(intervals, (x,y) => x[1].CompareTo(y[1]));
        int count = 0, prevEnd = int.MinValue;
        
        foreach(var interval in intervals){
            if(interval[0] >= prevEnd){
                
                prevEnd =  interval[1];
                count++;
            }
        }
        
        return count;
    }
    
    static void ExpenseCheck(double[] expense, int days){
        
        Queue<double> windows = new Queue<double>();
        double sum = 0;
        
        for(int i = 0; i < expense.Length; i++){
            
            windows.Enqueue(expense[i]);
            sum += expense[i];
            
            if(windows.Count > days) {
                sum -= windows.Dequeue();
            }
            
            if(windows.Count == days) {
                double avg = sum / days;
                if(expense[i] > 2 * avg) {
                    Console.WriteLine($"Anomaly on day {i}: {expense[i]} > 2x {avg:F2}");
                }
                
            }
            
           
        }
    }
    
    static void BalanceBrackets(string inputs) {
        
        int balance = 0;
        
        for(int i = 0; i < inputs.Length; i++) {
            
            var chr = inputs[i];
            if(chr == '{') {
                balance++;
            }
            
            if(chr == '}')
            {
                balance--;
            }
            
            if(balance < 0){
                //Console.WriteLine($"Bracket balance is ${balance < 0}");
                break;
             }
        }
         Console.WriteLine($"Bracket balance is {balance == 0}");
    }
    
    static void SevenDaysExpenseAvg(double[] expense, int days){ 
        
        Queue<double> windows = new Queue<double>();
        double sum = 0;
        
        for(int i = 0 ; i < expense.Length; i++) {
            windows.Enqueue(expense[i]);
            sum += expense[i];
            
            if(windows.Count > days){
                sum -= windows.Dequeue();
            }
            
            if(windows.Count == days) {
                double avg = sum / days;
                Console.WriteLine($"Last {days} day avg: {avg}");
            }
            
        }
        
    }
    
    static void LongestPeriod(double[] expense, double budget){
        
        int left = 0, maxPeriod = 0;
        double sum = 0;
        
        for(int right = 0; right < expense.Length; right ++) {
            
            sum += expense[right];
            
            if(sum > budget) {
                sum -= expense[left];
                left++;
            }
            
            maxPeriod = Math.Max(maxPeriod, right - left + 1);
        }
        
       Console.WriteLine("Longest valid window length = " + maxPeriod);
    }
    
    static void longSubstringWithtouRepeating(string inputs){
        var map = new Dictionary<char, int>();
        
        int left = 0, maxLen = 0;
        
        for(int right = 0; right < inputs.Length; right++) {
            
            var chr = inputs[right];
            
            if(map.ContainsKey(chr) && map[chr] >= left){
                left = map[chr] + 1;
            }
            
            map[chr] = right;
            Math.Max(maxLen, right - left + 1 );
        }
        
         Console.WriteLine("Longest length without repeat = " + maxLen);
    }
    
    static void FindMaxSumOfSizeK(int[] nums, int k) {
        
        int  sum = 0, maxSum = 0;
        int[] tmp = new int[nums.Length + 1];
    
        for(int i = 0; i < k ; i++){
            
            sum += nums[i];
        }
        maxSum = sum;
        
        for(int right = k; right < tmp.Length; right++ ) {
            sum = sum + tmp[right] - tmp[right - k];
            maxSum = Math.Max(maxSum, sum);
        }
        
        Console.WriteLine("Longest length without repeat = " + maxSum);
    }
    
    static void PerfixSumOfRangeSumQuery(int[] nums, int start, int to) {
        
        int[] sums = new int[nums.Length + 1];
        
        for(var i = 0; i < nums.Length; i++) {
            sums[i + 1] = sums[i] + nums[i];    
        }    
        
        var result = sums[to + 1] - sums[start];
        
         Console.WriteLine($"Sum from {start} to {to} is {result}");
    }
    
    static void ApplyRangeUpdates(int n, List<(int l, int r, int val)> updates) {
        int[] diff = new int[n + 1];
        
        foreach( var ( l,  r,  val) in updates ){
            
            var idx = l;
            while(idx <= r){
                
                diff[idx] += val;
                idx++;
            }
        }

        Console.WriteLine(String.Join(",", diff.Take(n)));
    }
    
    static void ApplyRangeUpdates2(int n, List<(int l, int r, int val)> updates) {
        int[] diff = new int[n + 1];
        
        foreach( var ( l,  r,  val) in updates ){
                diff[l] += val;
                
                if(r + 1 < diff.Length)
                diff[r + 1] -= val;
        }
        
        var sum = 0;
        int[] result = new int[n];
        
        for(int i = 0; i < n; i++){
            sum += diff[i];
            result[i] = sum;
        }
        
        Console.WriteLine(String.Join(",", result));
    }
    
    static void Mainx(string[] args){
        
        
        Console.WriteLine(string.Join(",", TwoSum(new int[]{1,3,5,6,7} , 9 )));
        Console.WriteLine(MaxSubArray(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}));
        Console.WriteLine(BinarySearch(new int[]{1, 2, 3, 4, 5, 6, 7} , 7));
        
        int[][] arr = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 1, 3 },
            new int[] { 3, 4 },
            new int[] { 5, 6 }
        };
        Console.WriteLine(EraseOverlapIntervals(arr));
        
        var lruCache = new LruCache(3);
        
        var inputs = new int[]{ 3,5,6,6,3,66,7,7,8,9,9,3};
        
        foreach(var input in inputs){
             if(lruCache.Get(input) == -1) {
                lruCache.Put(input, input);
            }
        }
        
        double[] expenses = { 100, 120, 130, 600, 150, 160, 170, 180, 190 };
        
        ExpenseCheck(expenses, 3);
        
        SevenDaysExpenseAvg(expenses, 7);
        
        LongestPeriod(expenses, 500);
        
        var updates = new List<(int, int, int)> { (1, 3, 2), (2, 4, 3) };
        ApplyRangeUpdates(5, updates);
        ApplyRangeUpdates2(5, updates);
        
        BalanceBrackets("{{}}}");
        
 
    } 
}