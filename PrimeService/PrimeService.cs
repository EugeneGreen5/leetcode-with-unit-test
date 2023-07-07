using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

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

    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder mergedString = new StringBuilder(word1.Length + word2.Length);
        
        for(int i = 0; i < word1.Length && i < word2.Length; i++)
        {
            mergedString.Append(word1[i]);
            mergedString.Append(word2[i]);
        }
        
        if (word1.Length > word2.Length)
        {
            for (int i = word2.Length; i < word1.Length; i++)
            {
                mergedString.Append(word1[i]);
            }
        } else if (word1.Length < word2.Length) {
            for (int i = word1.Length; i < word2.Length; i++)
            {
                mergedString.Append(word2[i]);
            }
        }

        return mergedString.ToString();
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        int counter = 0;
        int previousValue = 0;
        int nextvalue;
        if (flowerbed.Length == 1) nextvalue = 0;
        else nextvalue = flowerbed[1];
        for(int i = 0; i < flowerbed.Length; i++)
        {
            
            if (previousValue == 0 && flowerbed[i] == 0 && nextvalue == 0) {
                counter++;
                flowerbed[i] = 1;
            }

            previousValue = flowerbed[i];
            if (i != (flowerbed.Length - 2) && i != (flowerbed.Length - 1)) nextvalue = flowerbed[i + 2];
            else nextvalue = 0;
        }
        if (counter == n) return true;
        return false;
    }


    private readonly char[] lowerCase = { 'a', 'e', 'i', 'o', 'u' };
    private readonly char[] upperCase = { 'A', 'E', 'I', 'O', 'U' };
    public string ReverseVowels(string s)
    {
        var result = new StringBuilder(s);
        char[] lowerCase = { 'a', 'e', 'i', 'o', 'u'};
        char[] upperCase = { 'A', 'E', 'I', 'O', 'U' };

        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (isVowels(result[i])) stack.Push(result[i]);
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (isVowels(result[i])) result[i] = stack.Pop();
        }

        return result.ToString();
    }

    public bool isVowels(char symbol) => 
        lowerCase.Contains(symbol) || upperCase.Contains(symbol);

    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var list = new List<bool>(candies.Length);
        int maxValue = candies[1];
        for (int i = 0; i < candies.Length; i++)
        {
            for (int j = 0; j < candies.Length; j++)
            {
                if (i != j && maxValue < candies[j]) maxValue = candies[j];
            }
            if (maxValue < candies[i] + extraCandies) list.Add(true);
            else list.Add(false);
        }

        return list;
    }

    public string GcdOfStrings(string str1, string str2)
    {

        StringBuilder string1 = new StringBuilder(str2);
        Regex regex;
        while (string1.Length > 0)
        {
            regex = new Regex(string1.ToString());
            if (Regex.IsMatch(str1, $@"\b({string1})\1\b")) return string1.ToString();
            else string1.Length--;
        }
        return "";
    }

    public string ReverseWords(string s)
    {
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
        return string.Join(" ", words);
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int myltiply = 1, counterZero = 0;

        for(int i = 0; i < nums.Length; i++) 
        {
            if (nums[i] == 0) 
            {
                counterZero++;
            } else
            {
                myltiply *= nums[i];
            }
        }

        if (counterZero > 1)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        } 
        else
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) nums[i] = myltiply;
                else if (counterZero == 1) nums[i] = 0;
                else nums[i] = myltiply / nums[i];
            }
        }

        return nums;

/*        int rightMyltiply;
        if (nums[0] == 0) rightMyltiply = 0;
        else rightMyltiply = nums.Aggregate((x, y) => x * y);
        int leftMyltiply = 1;
        int trash;
       
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue; // need new idea
            else
            {
                trash = nums[i];
                rightMyltiply /= nums[i];
                nums[i] = leftMyltiply * rightMyltiply;
                leftMyltiply *= trash;
            }
        }
        return nums;*/

    }
}
