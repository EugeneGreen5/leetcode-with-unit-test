using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
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
        bool flagString1, flagString2;
        while (string1.Length > 0)
        {

            if (string1.Length == str1.Length)
                if (string1.Equals(str1)) flagString1 = true;
                else flagString1 = false;
            else
                flagString1 = new Regex($"^({string1})({string1})*({string1})$").IsMatch(str1);

            if (string1.Length == str2.Length)
                if (string1.Equals(str2)) flagString2 = true;
                else flagString2 = false;
            else
                flagString2 = new Regex($"^({string1})({string1})*({string1})$").IsMatch(str2);


            if (flagString1 && flagString2
                && str1.Length % string1.Length == 0
                && str2.Length % string1.Length == 0) return string1.ToString();

            string1.Length--;
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

    public bool IncreasingTriplet(int[] nums)
    {
        int minIndex = 0;
        int minValue = nums[0];
        int maxIndex = -1;
        int maxValue = int.MinValue;
        int counter = 1;

/*        for(int i = 0; i < nums.Length; i++)
        {
            if ()
        }*/

        return false;

/*        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                {
                    for(int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[j] < nums[k]) return true;
                    }
                }
            }
        }

        return false;*/
    }

    public bool IsSubsequence(string s, string t)
    {
        
        while (s.Length > 0)
        {
            if (t.Contains(s.First()))
            {
                t = t.Remove(0, t.IndexOf(s.First()) + 1).ToString();
                s = s.Remove(0, 1).ToString();
            }
            else return false;
        }

        return true;
    }

    public double FindMaxAverage(int[] nums, int k)
    {
        double sum = nums.Take(k).Sum();
        double result = sum / k;
        int previousValue = nums.First();

        for(int i = k; i < nums.Length; i++)
        {
            sum += nums[i] - nums[i - k];
            if (sum / k > result) result = sum / k;
        }

        return result;
    }


    public bool UniqueOccurrences(int[] arr)
    {
        var dictionary = new Dictionary<int, int>();

        foreach (var element in arr)
        {
            if (dictionary.ContainsKey(element)) dictionary[element]++;
            else dictionary[element] = 1;
        }

        int[] arrayValues = dictionary.Values.ToArray();
        HashSet<int> setValue = arrayValues.ToHashSet<int>();

        if (setValue.Count() == arrayValues.Length) return true;

        return false;
    }

    public string RemoveStars(string s)
    {
        var stack = new Stack<char>();
        StringBuilder result = new StringBuilder();

        foreach(var element in s)
        {
            if (element != '*') stack.Push(element);
            else
            {
                stack.Pop();
            }
        }

        var newStack = new Stack<char>();

        while (stack.Count != 0) {
            newStack.Push(stack.Pop());
        }

        while (newStack.Count != 0)
        {
            result.Append(newStack.Pop());
        }

        return result.ToString();

    }

    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();
        int lastElement;
        foreach(var element in asteroids)
        {
            if (stack.Count == 0) stack.Push(element);
            else
            {
                lastElement = stack.Peek();
                if (lastElement > 0 && element < 0) CheckElement(stack, element);
                else stack.Push(element);
            }
        }
        return stack.Reverse().ToArray();
    }

    public void CheckElement(Stack<int> stack, int element)
    {
        int lastElement = stack.Peek();
        if (lastElement > 0 && element < 0)
        {
            if (Math.Abs(lastElement) < Math.Abs(element))
            {
                stack.Pop();
                if (stack.Count == 0) stack.Push(element);
                else CheckElement(stack, element);
            }
            else if (Math.Abs(stack.Peek()) == Math.Abs(element)) stack.Pop();
        } else stack.Push(element);

    }

    /*public string DecodeString(string s)
    {
        StringBuilder input = new StringBuilder(s);
        StringBuilder currentString = new StringBuilder();

        var stack = new Stack<char>();

        while (input.Length > 0)
        {
            if ()
        }
    }*/

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public string DecodeString(string s)
    {
        StringBuilder newString = new StringBuilder();

        Stack<char> stack = new Stack<char>();




        return s;
    }

    public int LargestAltitude(int[] gain)
    {
        int[] newGain = new int[gain.Length + 1];
        newGain[0] = 0;
        int max = 0;

        for(int i = 0; i < gain.Length; i++)
        {
            newGain[i + 1] = newGain[i] + gain[i];
            
            if (newGain[i+1] > max) max = newGain[i+1];
        }

        return max;

    }

    public int PivotIndex(int[] nums)
    {
        int result = -1;
        int leftSum = 0, rightSum = nums.Sum() - nums[0];
        if (leftSum == rightSum) result = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            leftSum += nums[i-1];
            rightSum -= nums[i];
            if (leftSum == rightSum) return i;
        }

        return result;
    }

    public int MaxVowels(string s, int k)
    {
        int maxVowels = 0;
        int currentVowels = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if (i < k)
            {
                if (isVowels(s[i])) currentVowels++;
                continue;
            }
            if (isVowels(s[i])) currentVowels++;
            if (isVowels(s[i - k])) currentVowels--;
            if (maxVowels < currentVowels) maxVowels = currentVowels;
        }

        return maxVowels;
    }

    public void MoveZeroes(int[] nums)
    {
        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                int temp = nums[k];
                nums[k] = nums[i];
                nums[i] = temp;
                k++;
            }
        }
    }

    public int MaxArea(int[] height)
    {
        int l = 0;
        int r = height.Length - 1;
        int currentArea, maxArea = 0;

        while (l < r)
        {
            currentArea = (r - l) * Math.Min(height[l], height[r]);
            
            if (currentArea > maxArea) maxArea = currentArea;
            if (height[l] > height[r]) r--;
            else l++;
        }

        return maxArea;

    }

    public int MaxOperations(int[] nums, int k)
    {
        Array.Sort(nums);
        int result = 0;
        int l = 0, r = nums.Length - 1;
        int sum;
        while (l < r)
        {
            sum = nums[l] + nums[r];
            if (sum == k)
            {
                result += 1;
                l++;
                r--;
            }
            else if (sum > k) r--;
            else l++;
        }

        return result;

    }

    public ListNode DeleteMiddle(ListNode head)
    {
        int length = 0, iterator = 0;
        ListNode currentNode = head;

        while (currentNode is not null)
        {
            length++;
            currentNode = currentNode.next;
        }
        if (length == 1) return null;
        int element = length / 2;

        currentNode = head;
        while (element != iterator + 1)
        {
            iterator++;
            currentNode = currentNode.next;
        }

        currentNode.next = currentNode.next.next;
        return head;
    }

    public static ListNode OddEvenList(ListNode head)
    {
        int iterator = 1;
        ListNode nextNode;
        ListNode currentOdd = head, currentEven, headEven, currentNode = head;
        if (head is null) return null;
        else if (head.next is not null)
        {
            currentEven = head.next;
            headEven = head.next;
        }
        else return head;

        while (currentNode.next.next is not null)
        {
            nextNode = currentNode.next;
            if (iterator % 2 == 1)
            {
                currentOdd.next = currentNode.next.next;
                currentOdd = currentOdd.next;
            }
            else
            {
                currentEven.next = currentNode.next.next;
                currentEven = currentEven.next;
            }
            iterator++;
            currentNode = nextNode;

        }
        if (iterator % 2 == 0)
        {
            currentOdd.next = currentNode.next;
            currentEven.next = null;
        }

        currentOdd.next = headEven;

        return head;
    }

    public static IList<IList<int>> FindDifferenceA(int[] nums1, int[] nums2) =>
        new[] {
            nums1.Except(nums2).ToArray(),
            nums2.Except(nums1).ToArray(),
        };

    public static ListNode ReverseList(ListNode head)
    {
        ListNode newHead, previousNode = head, currentNode = head, nextNode;

        if (head is null) return null;
        else if (head.next is null) return head;

        currentNode = head.next;
        previousNode.next = null;

        while(currentNode.next != null) 
        {
            nextNode = currentNode.next;
            currentNode.next = previousNode;
            previousNode = currentNode;
            currentNode = nextNode;
        }
        currentNode.next = previousNode;

        return currentNode;
    }

    public static int PairSum(ListNode head)
    {
        ListNode currentNode = head;
        int iterator = 0;
        var listWithSum = new List<int>();

        if (head is null) return 0;

        while (currentNode != null)
        {
            listWithSum.Add(currentNode.val);
            currentNode = currentNode.next;
        }

        int sum = 0, currentSum = 0;
        for(int i = 0; i < listWithSum.Count / 2; i++)
        {
            currentSum = listWithSum[i] + listWithSum[listWithSum.Count - 1 - i];
            if (currentSum > sum) sum = currentSum;
        }

        return sum;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public int MaxDepth(TreeNode root)
    {
        var list = new List<int>();
        var stackNodes = new Stack<TreeNode>();
        var stackValue = new Stack<int>();

        int currentValue, maxDepth = 0;
        TreeNode currentNode;

        stackNodes.Push(root);
        stackValue.Push(1);

        while (stackNodes.Count != 0)
        {
            currentNode = stackNodes.Pop();
            currentValue = stackValue.Pop();
            if (currentNode.right is not null)
            {
                stackNodes.Push(currentNode.right);
                stackValue.Push(currentValue + 1);
            }
            if (currentNode.left is not null)
            {
                stackNodes.Push(currentNode.left);
                stackValue.Push(currentValue + 1);
            }

            if (currentValue > maxDepth) maxDepth = currentValue;
        }
        return maxDepth;
    }

    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        IList<int> list1 = FindAllLeaves(root1);
        IList<int> list2 = FindAllLeaves(root2);

        if (list1.Count != list2.Count) return false;

        for(int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i]) return false;
        }

        return true;
    }

    public IList<int> FindAllLeaves(TreeNode root)
    {
        var list = new List<int>();
        TreeNode currentNode;
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while(stack.Count != 0)
        {
            currentNode = stack.Pop();
            if (currentNode.right is not null)
            {
                stack.Push(currentNode.right);
            }
            if (currentNode.left is not null)
            {
                stack.Push(currentNode.left);
            }
            if (currentNode.right is null && currentNode.left is null)
            {
                list.Add(currentNode.val);
            }
        }

        return list;
    }

    public class RecentCounter
    {
        private Queue<int> queue;
        public RecentCounter()
        {
            queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            ;
            queue.Enqueue(t);
            while (t - queue.Peek() > 3000)
            {
                queue.Dequeue();
            }

            return queue.Count();
        }
        }
    }

}
