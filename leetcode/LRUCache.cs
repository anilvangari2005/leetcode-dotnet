namespace Leetcode.LRUCache.DoubleLinkedListAndHashMap;

/// <summary>
/// Runtime: 842 ms, faster than 90.13% of C# online submissions for LRU Cache.
/// Memory Usage: 149.3 MB, less than 10.39% of C# online submissions for LRU Cache.
/// </summary>
public class LRUCache
{
    private DoubleLinkedList list;

    public LRUCache(int capacity)
    {
        list = new DoubleLinkedList();
        list.capacity = capacity;
    }

    public int Get(int key)
    {
        return list.Get(key);
    }

    public void Put(int key, int value)
    {
        list.Put(key, value);
    }
}

public class DoubleLinkedList
{
    public int capacity { get; set; }
    public LinkedListNode? Head { get; set; }
    public LinkedListNode? Tail { get; set; }

    private Dictionary<int, LinkedListNode> dict = new Dictionary<int, LinkedListNode>();
    private int count { get; set; }

    public DoubleLinkedList()
    {
    }

    public void RemoveLast()
    {
        if (this.Tail != null)
        {
            var key = this.Tail.Key;
            dict.Remove(key);
            var prev = this.Tail.Previous;

            if (prev != null)
            {
                prev.Next = null;
                this.Tail = prev;
            }
            count = count - 1;

            if (count == 0)
                this.Head = null;
        }
    }

    public int Get(int key)
    {
        LinkedListNode? node;
        if (dict.TryGetValue(key, out node))
        {
            int value = node.Value;
            this.Remove(node);
            this.AddFirst(key, value);
            return value;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        LinkedListNode? node;
        if (dict.TryGetValue(key, out node))
        {
            this.Remove(key);
            this.AddFirst(key, value);
        }
        else
        {
            this.AddFirst(key, value);
        }
    }

    public LinkedListNode AddFirst(int key, int value)
    {
        var node = new LinkedListNode();
        node.Key = key;
        node.Value = value;
        node.Next = this.Head;

        if (this.Head != null)
            this.Head.Previous = node;

        this.Head = node;

        dict[key] = node;
        count = count + 1;

        if (count == 1)
            this.Tail = this.Head;
        else if (count > capacity)
            this.RemoveLast();

        return node;
    }

    public void Remove(int key)
    {
        LinkedListNode? node;
        if (dict.TryGetValue(key, out node))
        {
            var prev = node.Previous;
            var next = node.Next;

            if (prev == null)
                this.Head = next;
            if (next == null)
                this.Tail = prev;
            if (next != null)
                next.Previous = prev;
            if (prev != null)
                prev.Next = next;

            dict.Remove(key);
            count = count - 1;
        }
    }

    public void Remove(LinkedListNode node)
    {
        if (node != null)
        {
            var prev = node.Previous;
            var next = node.Next;
            var key = node.Key;

            if (prev == null)
                this.Head = next;
            if (next == null)
                this.Tail = prev;
            if (next != null)
                next.Previous = prev;
            if (prev != null)
                prev.Next = next;

            dict.Remove(key);
            count = count - 1;
        }
    }
}

public class LinkedListNode
{
    public int Key { get; set; }
    public int Value { get; set; }
    public LinkedListNode? Previous { get; set; }
    public LinkedListNode? Next { get; set; }

    public LinkedListNode()
    {

    }

    public LinkedListNode(LinkedListNode previous, LinkedListNode next, int key, int value)
    {
        this.Previous = previous;
        this.Next = next;
        this.Key = key;
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