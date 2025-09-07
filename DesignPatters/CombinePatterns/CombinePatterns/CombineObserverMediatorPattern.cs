// Use case: Combining Observer and Mediator for event-driven communication with central coordination
using System;
public interface IObserverMediatorPattern { void RunExample(); }
public class ObserverMediatorPattern : IObserverMediatorPattern {
    public void RunExample() {
        Console.WriteLine("Observer + Mediator Pattern Example:");
        var mediator = new Mediator();
        var observerA = new Observer("A");
        var observerB = new Observer("B");
        mediator.Register(observerA);
        mediator.Register(observerB);
        mediator.NotifyAll("Event Occurred");
    }
    interface IObserver { void Update(string message); }
    class Observer : IObserver {
        private readonly string _name;
        public Observer(string name) { _name = name; }
        public void Update(string message) { Console.WriteLine($"Observer {_name} received: {message}"); }
    }
    class Mediator {
        private readonly System.Collections.Generic.List<IObserver> _observers = new();
        public void Register(IObserver observer) { _observers.Add(observer); }
        public void NotifyAll(string message) { foreach (var o in _observers) o.Update(message); }
    }
}
