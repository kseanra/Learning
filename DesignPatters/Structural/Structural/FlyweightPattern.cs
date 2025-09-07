// Use case: Apply the Flyweight pattern when you need to efficiently share and reuse objects with common state, such as rendering many similar UI elements or game objects.
using System;
// Flyweight Pattern
public interface IFlyweightPattern { void RunExample(); }
public class FlyweightPattern : IFlyweightPattern {
    public void RunExample() {
        Console.WriteLine("Flyweight Pattern Example:");
        FlyweightFactory factory = new FlyweightFactory();
        IFlyweight flyweightA = factory.GetFlyweight("A");
        IFlyweight flyweightB = factory.GetFlyweight("B");
        flyweightA.Operation(1);
        flyweightB.Operation(2);
    }
    interface IFlyweight { void Operation(int extrinsicState); }
    class ConcreteFlyweight : IFlyweight {
        private readonly string _intrinsicState;
        public ConcreteFlyweight(string intrinsicState) { _intrinsicState = intrinsicState; }
        public void Operation(int extrinsicState) {
            Console.WriteLine($"Flyweight {_intrinsicState}, Extrinsic {extrinsicState}");
        }
    }
    class FlyweightFactory {
        private readonly System.Collections.Generic.Dictionary<string, IFlyweight> _flyweights = new();
        public IFlyweight GetFlyweight(string key) {
            if (!_flyweights.ContainsKey(key)) _flyweights[key] = new ConcreteFlyweight(key);
            return _flyweights[key];
        }
    }
}
