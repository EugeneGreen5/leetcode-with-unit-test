using System.Globalization;

namespace Tests;


[TestFixture]
public class Tests
{
    private PrimeService.PrimeService _primeService;

    [SetUp]
    public void Setup   ()
    {
        _primeService = new PrimeService.PrimeService();
    }

    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    public void Test1(int value)
    {
        var result = _primeService.isPrime(value);

        Assert.IsFalse(result, "1 should not be prime");
    }

    [TestCase(new int[] { 3, 2, 3 }, 3)]
    [TestCase(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    public void TestMajority(int[] array, int resultTrue)
    {
        var result = _primeService.MajorityElement(array);
        Assert.AreEqual(result, resultTrue);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    [TestCase(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
    public void TestRotate(int[] array, int k, int[] result)
    {
        _primeService.Rotate(array, k);
        Assert.AreEqual(array, result);
    }

    [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void TestMaxProfit(int[] prices, int result)
    {
        var resultMethod = _primeService.MaxProfit(prices);
        Assert.AreEqual(resultMethod, result);
    }

    [TestCase("Hello World", 5)]
    [TestCase("   fly me   to   the moon  ", 4)]
    [TestCase("luffy is still joyboy", 6)]
    public void TestLengthOfLastWord(string s, int result)
    {
        var resultFund = _primeService.LengthOfLastWorld(s);
        Assert.AreEqual(resultFund, result);
    }

    [TestCase("abc", "pqr", "apbqcr")]
    [TestCase("ab", "pqrs", "apbqrs")]
    [TestCase("abcd", "pq", "apbqcd")]
    public void TestMergeString(string word1, string word2, string result)
    {
        var resultFind = _primeService.MergeAlternately(word1, word2);
        Assert.AreEqual(resultFind, result);
    }

    [TestCase(new int[]{0, 0, 1, 0, 0}, 1, true)]
    [TestCase(new int[]{1, 0, 0, 0, 1}, 1, true)]
    [TestCase(new int[]{1, 0, 0, 0, 1}, 2, false)]
    [TestCase(new int[]{0, 0, 1, 0, 1}, 1, true)]
    public void TestCanPlace(int[] array,int n, bool result)
    {
        var resultFind = _primeService.CanPlaceFlowers(array, n);
        Assert.AreEqual(resultFind, result);
    }

    [TestCase("ABABAB", "ABAB", "AB")]
    [TestCase("ABCABC", "ABC", "ABC")]
    [TestCase("LEET", "CODE", "")]
    [TestCase("HELLOHELLOHELLO", "HELLO","HELLO")]
    public void TestGcdOfStrings(string str1, string str2, string result)
    {
        var resultFunc = _primeService.GcdOfStrings(str1, str2);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase("the sky is blue", "blue is sky the")]
    [TestCase("  hello world       ", "world hello")]
    [TestCase("a good   example", "example good a")]

    public void ReverseWords(string str1, string result)
    {
        var resultFunc = _primeService.ReverseWords(str1);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [TestCase(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    public void TestProductExceptSelf(int[] array, int[] result)
    {
        var resultFunc = _primeService.ProductExceptSelf(array);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, true)]
    [TestCase(new int[] { 5, 4, 3, 2, 1 }, false)]
    [TestCase(new int[] { 2, 1, 5, 0, 4, 6 }, true)]
    public void TestIncreasingTriplet(int[] array, bool result)
    {
        var resultFunc = _primeService.IncreasingTriplet(array);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase("abc", "ahbgdc", true)]
    [TestCase("axc", "ahbgdc", false)]
    public void TestIsSubsequence(string str1,string str2, bool result)
    {
        var resultFunc = _primeService.IsSubsequence(str1,str2);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { 1, 12, -5, -6, 50, 3 },4, 12.75000)]
    [TestCase(new int[] { 5 },1, 5.00000)]
    public void TestFindMaxAverage(int[] nums, int k, double result)
    {
        var resultFunc = _primeService.FindMaxAverage(nums, k);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { 1, 2, 2, 1, 1, 3 }, true)]
    [TestCase(new int[] { 1, 2 }, false)]
    [TestCase(new int[] { -3, 0, 1, -3, 1, 1, 1, -3, 10, 0 }, true)]
    public void TestUniqueOccurrences(int[] nums, bool result)
    {
        var resultFunc = _primeService.UniqueOccurrences(nums);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase("leet**cod*e", "lecoe")]
    [TestCase("erase*****", "")]
    public void TestRemoveStars(string s, string result)
    {
        var resultFunc = _primeService.RemoveStars(s);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { -2, -2, 1, -2 }, new int[] { -2, -2, -2 })]
    [TestCase(new int[] { 5, 10, -5 }, new int[] { 5, 10 })]
    [TestCase(new int[] { 8, -8 }, new int[] { })]
    [TestCase(new int[] { 10, 2, -5 }, new int[] { 10 })]
    public void TestAsteroidCollisions(int[] asteroids, int[] result)
    {
        var resultFunc = _primeService.AsteroidCollision(asteroids);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { -5, 1, 5, 0, -7 }, 1)]
    [TestCase(new int[] { -4, -3, -2, -1, 4, 3, 2 }, 0 )]
    public void TestLargestAltitude(int[] gain, int result)
    {
        var resultFunc = _primeService.LargestAltitude(gain);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase(new int[] { -1, -1, 0, 0, -1, -1 }, 2)]
    [TestCase(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [TestCase(new int[] { 1, 2, 3 }, -1)]
    [TestCase(new int[] { 2, 1, -1 }, 0)]
    public void TestPivotIndex(int[] gain, int result)
    {
        var resultFunc = _primeService.PivotIndex(gain);
        Assert.AreEqual(resultFunc, result);
    }

    [TestCase("tryhard", 4, 1)]
    [TestCase("abciiidef", 3, 3)]
    [TestCase("aeiou", 2, 2)]
    [TestCase("leetcode", 3, 2)]
    public void TestMaxVowels(string s,int k, int result)
    {
        var resultFunc = _primeService.MaxVowels(s,k);
        Assert.AreEqual(resultFunc, result);
    }


    [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },  49)]
    [TestCase(new int[] { 1, 1 },  1)]
    public void TestMaxArea(int[] height, int result)
    {
        var resultFunc = _primeService.MaxArea(height);
        Assert.AreEqual(resultFunc, result);
    }
}