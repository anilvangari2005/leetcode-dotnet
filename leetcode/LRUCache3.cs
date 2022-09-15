namespace Leetcode.LRUCache.OrderedDictionary;

using System.Collections.Specialized;

/// <summary>
/// Time Limit Exceeded
/// 
/// I do not recommend this implementation because of performance and non-generic collection
/// </summary>
public class LRUCache
{
    private int Capacity;

    private OrderedDictionary dict;

    public LRUCache(int capacity)
    {
        dict = new OrderedDictionary(capacity);
        this.Capacity = capacity;
    }

    public int Get(int key)
    {
        string keyStr = key.ToString();
        if (dict.Contains(keyStr))
        {
            int value = (int)(dict[keyStr] ?? 0);
            dict.Remove(keyStr);
            this.Add(keyStr, value);
            return value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        string keyStr = key.ToString();
        if (dict.Contains(keyStr))
        {
            dict.Remove(keyStr);
            this.Add(keyStr, value);
        }
        else
        {
            this.Add(keyStr, value);
        }
    }

    private void Add(string key, int value)
    {
        dict.Add(key, value);

        if (dict.Count > this.Capacity)
            dict.RemoveAt(0);
    }
}

public class LRUCacheTestDriver
{
    public static List<int?> Test(List<string> commands, List<List<int>> inputValues)
    {
        LRUCache? cache = null;
        var results = new List<int?>();
        for (var i = 0; i < commands.Count; i++)
        {
            if (commands[i] == "LRUCache")
            {
                cache = new LRUCache(inputValues[i][0]);
                results.Add(null);
            }
            else if (commands[i] == "put")
            {
                cache.Put(inputValues[i][0], inputValues[i][1]);
                results.Add(null);
            }
            else if (commands[i] == "get")
            {
                var value = cache.Get(inputValues[i][0]);
                results.Add(value);
            }
        }
        return results;
    }

}