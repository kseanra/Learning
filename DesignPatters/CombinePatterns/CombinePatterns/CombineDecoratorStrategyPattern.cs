// Use case: Combining Decorator and Strategy for dynamic behavior extension and 
//algorithm selection
using System;
public interface IDecoratorStrategyPattern { void RunExample(); }
public class DecoratorStrategyPattern : IDecoratorStrategyPattern {
    public void RunExample() {
        Console.WriteLine("Decorator + Strategy Pattern Example:");
        IComponent component = new ConcreteComponent();
        IComponent decorated = new LoggingDecorator(component);
        var context = new Context(decorated, new ConcreteStrategyA());
        context.Execute();
        context.SetStrategy(new ConcreteStrategyB());
        context.Execute();
    }
    interface IComponent { void Operation(); }
    class ConcreteComponent : IComponent { public void Operation() => Console.WriteLine("Component Operation"); }
    class LoggingDecorator : IComponent {
        private readonly IComponent _component;
        public LoggingDecorator(IComponent component) { _component = component; }
        public void Operation() {
            Console.WriteLine("Logging Before");
            _component.Operation();
            Console.WriteLine("Logging After");
        }
    }
    interface IStrategy { void Algorithm(); }
    class ConcreteStrategyA : IStrategy { public void Algorithm() { Console.WriteLine("StrategyA Algorithm"); } }
    class ConcreteStrategyB : IStrategy { public void Algorithm() { Console.WriteLine("StrategyB Algorithm"); } }
    class Context {
        private IComponent _component;
        private IStrategy _strategy;
        public Context(IComponent component, IStrategy strategy) { _component = component; _strategy = strategy; }
        public void SetStrategy(IStrategy strategy) { _strategy = strategy; }
        public void Execute() {
            _component.Operation();
            _strategy.Algorithm();
        }
    }
}
