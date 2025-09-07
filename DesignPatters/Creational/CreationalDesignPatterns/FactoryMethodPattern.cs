using System;
public interface IFactoryMethodPattern {
    void RunExample();
}
public class FactoryMethodPattern : IFactoryMethodPattern {
    public void RunExample() {
        Console.WriteLine("Factory Method Pattern Example:");
        // Non-generic usage
        var creator = new CircleFactory();
        IShape shape = creator.FactoryMethod(); 
        Console.WriteLine($"Created: {shape.GetName()}");

        // Generic usage
        var genericShapeCreator = new GenericCreator<Circle>();
        var shape = genericShapeCreator.FactoryMethod();
        Console.WriteLine($"Created generic: {shape.GetName()}");
    }

    // Non-generic
    interface IShape { string GetName(); }
    class Circle : IShape { public string GetName() => "Circle"; }
    abstract class ShapeFactory { public abstract IShape FactoryMethod(); }
    class CircleFactory : ShapeFactory { public override IShape FactoryMethod() => new Circle(); }

    // Generic
    public abstract class GenericShapeCreator<T> where T : IShape, new() {
        public virtual T FactoryMethod() => new T();
    }
    public class GenericCreator<TProduct> : GenericShapeCreator<TProduct> where TProduct : IShape, new() { }
}
