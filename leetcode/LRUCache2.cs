namespace Leetcode.LRUCache.LinkedListAndDictionary;

using System.Collections.Generic;

/// <summary>
/// Runtime: 1495 ms, faster than 5.24% of C# online submissions for LRU Cache.
/// Memory Usage: 143.1 MB, less than 17.60% of C# online submissions for LRU Cache.
/// 
/// Performance is not great using .NET in-built collection classes
/// </summary>
public class LRUCache
{
    private LinkedList<Tuple<int, int>> list;
    private int Capacity;

    private Dictionary<int, LinkedListNode<Tuple<int, int>>> dict;

    public LRUCache(int capacity)
    {
        list = new LinkedList<Tuple<int, int>>();
        dict = new Dictionary<int, LinkedListNode<Tuple<int, int>>>();
        this.Capacity = capacity;
    }

    public int Get(int key)
    {
        LinkedListNode<Tuple<int, int>>? node;
        if (dict.TryGetValue(key, out node))
        {
            var entry = node.Value;

            list.Remove(node);
            var newNode = new LinkedListNode<Tuple<int, int>>(entry);
            this.AddFirst(newNode);

            return entry.Item2;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<Tuple<int, int>>? node;
        if (dict.TryGetValue(key, out node))
        {
            var entry = node.Value;

            list.Remove(node);
            var newNode = new LinkedListNode<Tuple<int, int>>(entry);
            this.AddFirst(newNode);
        }
        else
        {
            var newNode = new LinkedListNode<Tuple<int, int>>(new Tuple<int, int>(key, value));
            this.AddFirst(newNode);
        }
    }

    private void AddFirst(LinkedListNode<Tuple<int, int>> node)
    {
        list.AddFirst(node);
        dict[node.Value.Item1] = node;

        if (list.Count > this.Capacity)
        {
            if (list.Last != null)
            {
                dict.Remove(list.Last.Value.Item1);
                list.RemoveLast();
            }
        }

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