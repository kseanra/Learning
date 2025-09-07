// Use case: Apply the Decorator pattern when you want to add responsibilities to objects dynamically, 
//such as adding features to UI elements or logging to services.
using System;
// Decorator Pattern
public interface IDecoratorPattern { void RunExample(); }
public class DecoratorPattern : IDecoratorPattern {
    public void RunExample() {
        Console.WriteLine("Decorator Pattern Example:");
        IComponent component = new ConcreteComponent();
        IComponent decorated = new ConcreteDecorator(component);
        decorated.Operation();
    }
    interface IComponent { void Operation(); }
    class ConcreteComponent : IComponent { public void Operation() => Console.WriteLine("ConcreteComponent Operation"); }
    class ConcreteDecorator : IComponent {
        private readonly IComponent _component;
        public ConcreteDecorator(IComponent component) { _component = component; }
        public void Operation() {
            Console.WriteLine("Decorator Before");
            _component.Operation();
            Console.WriteLine("Decorator After");
        }
    }
}
