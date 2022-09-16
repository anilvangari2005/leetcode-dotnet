namespace Leetcode.NumIslands.DSU.Test;

public class NumIslandsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var solution = new Solution();
        var input = new char[][] {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '0', '0', '0'}

            };
        var result = solution.NumIslands(input);
        Assert.AreEqual(1, result);
    }

    [Test]
    public void Test2()
    {
        var solution = new Solution();
        var input = new char[][] {
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '1', '0', '0'},
                new char[] {'0', '0', '0', '1', '1'}

            };
        var result = solution.NumIslands(input);
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Test3()
    {
        var solution = new Solution();
        var input = new char[][] {
                new char[] {'1', '1', '1'},
                new char[] {'0', '1', '0'},
                new char[] {'1', '1', '1'}
            };
        var result = solution.NumIslands(input);
        Assert.AreEqual(1, result);
    }
}
