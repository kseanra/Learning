// Use case: Apply the Memento pattern when you need to capture and restore an object's state, such as implementing undo functionality.
using System;
public interface IMementoPattern { void RunExample(); }
public class MementoPattern : IMementoPattern {
    public void RunExample() {
        Console.WriteLine("Memento Pattern Example:");
        var originator = new Originator();
        originator.State = "State1";
        var memento = originator.CreateMemento();
        originator.State = "State2";
        originator.SetMemento(memento);
        Console.WriteLine($"Restored State: {originator.State}");
    }
    class Originator {
        public string State { get; set; }
        public Memento CreateMemento() => new Memento(State);
        public void SetMemento(Memento memento) { State = memento.State; }
    }
    class Memento {
        public string State { get; }
        public Memento(string state) { State = state; }
    }
}
