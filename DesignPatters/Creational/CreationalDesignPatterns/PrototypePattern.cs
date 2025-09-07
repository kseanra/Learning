using System;
public interface IPrototypePattern {
    void RunExample();
}
public class PrototypePattern : IPrototypePattern {
    public void RunExample() {
        Console.WriteLine("Prototype Pattern Example:");
        Prototype prototype = new ConcretePrototype("Prototype1");
        Prototype clone = prototype.Clone();
        Console.WriteLine($"Cloned: {clone.Name}");
    }
    abstract class Prototype {
        public string Name { get; }
        public Prototype(string name) { Name = name; }
        public abstract Prototype Clone();
    }
    class ConcretePrototype : Prototype
    {
        public ConcretePrototype(string name) : base(name) { }
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
        
    }
}
