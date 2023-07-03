namespace PrimeService;

public class PrimeService
{
    public bool isPrime(int candidate)
    {
        if (candidate < 2)
            return false;
        throw new NotImplementedException("Please create a test first.");
    }

    public int MajorityElement(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        int maxValue = int.MinValue;
        int maxKey = int.MinValue;
        bool flag = true;
        foreach (var i in nums)
        {
            if (dict.ContainsKey(i))
            {
                dict[i]++;
                if (maxValue < dict[i])
                {
                    maxValue = dict[i];
                    maxKey = i;
                }
            }
            else
            {
                dict[i] = 1;
                if (flag)
                {
                    maxValue = dict[i];
                    maxKey = i;
                    flag = false;
                }
            }
        }

        return maxKey;
    }

    public void Rotate(int[] nums, int k)
    {
        k = nums.Length % k;
        int counter = 0;
        while (counter != k)
        {
            int lastElemt = nums.Last();
            int size = nums.Length - 1;
            for (int i = size; i > 0; i--)
            {
                nums[i] = nums[i - 1];
            }
            counter++;
            nums[0] = lastElemt;
        }
    }

    public int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int minValue = int.MaxValue;

        foreach(int i in prices)
        {
            if (i < minValue) minValue = i;
            else if (i - minValue > maxProfit) maxProfit = i - minValue;
        }

        return maxProfit;
        
    }

    public int LengthOfLastWorld(string s)
    {
        string[] words = s.Split(' ' , StringSplitOptions.RemoveEmptyEntries); ;

        return words[words.Length-1].Length;
    }
}
