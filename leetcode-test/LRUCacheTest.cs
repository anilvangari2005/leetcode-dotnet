namespace Leetcode.LRUCache.Test;

using NUnit.Framework;
using Leetcode.LRUCache.DoubleLinkedListAndHashMap;
using Leetcode.LRUCache.LinkedListAndDictionary;
using Leetcode.LRUCache.OrderedDictionary;


public class LRUCacheTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var result = DoubleLinkedListAndHashMap.LRUCacheTestDriver.Test(
            new List<string> { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" },
            new List<List<int>> {
                new List<int> {2},
                new List<int> {1, 1},
                new List<int> {2, 2},
                new List<int> {1},
                new List<int> {3, 3},
                new List<int> {2},
                new List<int> {4, 4},
                new List<int> {1},
                new List<int> {3},
                new List<int> {4}}
        ).ToArray();
        Assert.AreEqual(new int?[] { null, null, null, 1, null, -1, null, -1, 3, 4 }, result);
    }

    [Test]
    public void Test2()
    {
        var result = LinkedListAndDictionary.LRUCacheTestDriver.Test(
            new List<string> { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" },
            new List<List<int>> {
                new List<int> {2},
                new List<int> {1, 1},
                new List<int> {2, 2},
                new List<int> {1},
                new List<int> {3, 3},
                new List<int> {2},
                new List<int> {4, 4},
                new List<int> {1},
                new List<int> {3},
                new List<int> {4}}
        ).ToArray();
        Assert.AreEqual(new int?[] { null, null, null, 1, null, -1, null, -1, 3, 4 }, result);
    }
    [Test]
    public void Test3()
    {
        var result = OrderedDictionary.LRUCacheTestDriver.Test(
            new List<string> { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" },
            new List<List<int>> {
                new List<int> {2},
                new List<int> {1, 1},
                new List<int> {2, 2},
                new List<int> {1},
                new List<int> {3, 3},
                new List<int> {2},
                new List<int> {4, 4},
                new List<int> {1},
                new List<int> {3},
                new List<int> {4}}
        ).ToArray();
        Assert.AreEqual(new int?[] { null, null, null, 1, null, -1, null, -1, 3, 4 }, result);
    }

}