namespace Leetcode.MaximumScore.TopDown.Test;

public class MaximumScoreTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var solution = new Solution();
        var nums = new int[] { 1, 2, 3 };
        var multipliers = new int[] { 3, 2, 1 };
        var result = solution.MaximumScore(nums, multipliers);
        Assert.AreEqual(14, result);
    }

    [Test]
    public void Test2()
    {
        var solution = new Solution();
        var nums = new int[] { -5, -3, -3, -2, 7, 1 };
        var multipliers = new int[] { -10, -5, 3, 4, 6 };
        var result = solution.MaximumScore(nums, multipliers);
        Assert.AreEqual(102, result);
    }

}
