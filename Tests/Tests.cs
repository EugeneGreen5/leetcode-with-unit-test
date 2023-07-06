namespace Tests;


[TestFixture]
public class Tests
{
    private PrimeService.PrimeService _primeService;

    [SetUp]
    public void Setup()
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

    [TestCase(new int[] { 0, 0, 1, 0, 0 }, 1, true)]
    [TestCase(new int[]{1, 0, 0, 0, 1}, 1, true)]
    [TestCase(new int[]{1, 0, 0, 0, 1}, 2, false)]
    [TestCase(new int[]{0, 0, 1, 0, 1}, 1, true)]
    public void TestCanPlace(int[] array,int n, bool result)
    {
        var resultFind = _primeService.CanPlaceFlowers(array, n);
        Assert.AreEqual(resultFind, result);
    }


    [TestCase(new int[] { 2, 3, 5, 1, 3 }, 3, new List<bool>() { true, true, true, false, true })]
    public void TestKidsWithCandies(int[] array, int n, List<bool> result)
    {
        var resultFind = _primeService.KidsWithCandies(array, n);
        Assert.AreEqual(resultFind, result);
    }
}