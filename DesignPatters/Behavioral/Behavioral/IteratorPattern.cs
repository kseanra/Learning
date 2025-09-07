// Use case: Apply the Iterator pattern when you need to traverse a collection without exposing its underlying representation.
using System;
public interface IIteratorPattern { void RunExample(); }
public class IteratorPattern : IIteratorPattern {
    public void RunExample() {
        Console.WriteLine("Iterator Pattern Example:");
        Aggregate aggregate = new Aggregate();
        aggregate.Add("A");
        aggregate.Add("B");
        IIterator iterator = aggregate.CreateIterator();
        while (iterator.HasNext()) Console.WriteLine(iterator.Next());
    }
    interface IIterator {
        bool HasNext();
        string Next();
    }
    class Aggregate {
        private readonly System.Collections.Generic.List<string> _items = new();
        public void Add(string item) { _items.Add(item); }
        public IIterator CreateIterator() => new ConcreteIterator(_items);
    }
    class ConcreteIterator : IIterator {
        private readonly System.Collections.Generic.List<string> _items;
        private int _index = 0;
        public ConcreteIterator(System.Collections.Generic.List<string> items) { _items = items; }
        public bool HasNext() => _index < _items.Count;
        public string Next() => _items[_index++];
    }
}
