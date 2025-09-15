public class LRUCache
{
    private int capacity;
    private Dictionary<int, LinkedListNode<(int key, int val)>> map;
    private LinkedList<(int key, int val)> list;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        this.map = new Dictionary<int, LinkedListNode<(int, int)>>();
        this.list = new LinkedList<(int, int)>();
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key)) return -1;
        var node = map[key];
        list.Remove(node);
        list.AddFirst(node);
        return node.Value.val;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
        {
            var node = map[key];
            list.Remove(node);
        }
        else if (map.Count == capacity)
        {
            var last = list.Last;
            map.Remove(last?.Value.key ?? 0);
            list.RemoveLast();
        }

        var newNode = new LinkedListNode<(int, int)>((key, value));
        list.AddFirst(newNode);
        map[key] = newNode;
    }
}
