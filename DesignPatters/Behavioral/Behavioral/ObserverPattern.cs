// Use case: Apply the Observer pattern when you want to notify multiple objects about state changes, such as event handling systems.
using System;
public interface IObserverPattern { void RunExample(); }
public class ObserverPattern : IObserverPattern {
    public void RunExample() {
        Console.WriteLine("Observer Pattern Example:");
        var subject = new Subject();
        subject.Attach(new ConcreteObserver("A"));
        subject.Attach(new ConcreteObserver("B"));
        subject.State = "New State";
        subject.Notify();
    }
    interface IObserver { void Update(string state); }
    class ConcreteObserver : IObserver {
        private readonly string _name;
        public ConcreteObserver(string name) { _name = name; }
        public void Update(string state) { Console.WriteLine($"Observer {_name} received: {state}"); }
    }
    class Subject {
        private readonly System.Collections.Generic.List<IObserver> _observers = new();
        public string State { get; set; }
        public void Attach(IObserver observer) { _observers.Add(observer); }
        public void Notify() { foreach (var o in _observers) o.Update(State); }
    }
}
