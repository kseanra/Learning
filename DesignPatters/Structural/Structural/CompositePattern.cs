// Use case: Apply the Composite pattern when you need to 
//treat individual objects and groups of objects uniformly, 
//such as building tree structures (e.g., file systems, UI components).
using System;
// Composite Pattern
public interface ICompositePattern { void RunExample(); }
public class CompositePattern : ICompositePattern {
    public void RunExample() {
        Console.WriteLine("Composite Pattern Example:");
        Component root = new Composite("Root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));
        Component branch = new Composite("Branch");
        branch.Add(new Leaf("Leaf C"));
        root.Add(branch);
        root.Display(1);
    }
    abstract class Component {
        protected string Name;
        public Component(string name) { Name = name; }
        public virtual void Add(Component c) { }
        public virtual void Display(int depth) { Console.WriteLine(new string('-', depth) + Name); }
    }
    class Leaf : Component {
        public Leaf(string name) : base(name) { }
    }
    class Composite : Component {
        private readonly System.Collections.Generic.List<Component> _children = new();
        public Composite(string name) : base(name) { }
        public override void Add(Component c) { _children.Add(c); }
        public override void Display(int depth) {
            Console.WriteLine(new string('-', depth) + Name);
            foreach (var child in _children) child.Display(depth + 2);
        }
    }
}
