// Use case: Apply the Strategy pattern when you want to define a family of algorithms, 
//encapsulate each one, and make them interchangeable.
using System;
public interface IStrategyPattern { void RunExample(); }
public class StrategyPattern : IStrategyPattern {
    public void RunExample() {
        Console.WriteLine("Strategy Pattern Example:");
        var context = new Context(new ConcreteStrategyA());
        context.Execute();
        context.SetStrategy(new ConcreteStrategyB());
        context.Execute();
    }
    interface IStrategy { void Algorithm(); }
    class ConcreteStrategyA : IStrategy { public void Algorithm() { Console.WriteLine("StrategyA Algorithm"); } }
    class ConcreteStrategyB : IStrategy { public void Algorithm() { Console.WriteLine("StrategyB Algorithm"); } }
    class Context {
        private IStrategy _strategy;
        public Context(IStrategy strategy) { _strategy = strategy; }
        public void SetStrategy(IStrategy strategy) { _strategy = strategy; }
        public void Execute() { _strategy.Algorithm(); }
    }
}
