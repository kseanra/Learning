// Use case: Apply the Visitor pattern when you want to perform operations on elements of an object structure without changing their classes.
using System;
public interface IVisitorPattern { void RunExample(); }
public class VisitorPattern : IVisitorPattern {
    public void RunExample() {
        Console.WriteLine("Visitor Pattern Example:");
        var elements = new IElement[] { new ElementA(), new ElementB() };
        var visitor = new ConcreteVisitor();
        foreach (var e in elements) e.Accept(visitor);
    }
    interface IElement { void Accept(IVisitor visitor); }
    class ElementA : IElement { public void Accept(IVisitor visitor) { visitor.Visit(this); } }
    class ElementB : IElement { public void Accept(IVisitor visitor) { visitor.Visit(this); } }
    interface IVisitor {
        void Visit(ElementA element);
        void Visit(ElementB element);
    }
    class ConcreteVisitor : IVisitor {
        public void Visit(ElementA element) { Console.WriteLine("Visited ElementA"); }
        public void Visit(ElementB element) { Console.WriteLine("Visited ElementB"); }
    }
}
