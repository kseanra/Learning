// Use case: Apply the State pattern when an object needs to change its behavior based on its internal state.
using System;
public interface IStatePattern { void RunExample(); }
public class StatePattern : IStatePattern {
    public void RunExample() {
        Console.WriteLine("State Pattern Example:");
        var context = new Context(new ConcreteStateA());
        context.Request();
        context.SetState(new ConcreteStateB());
        context.Request();
    }
    interface IState { void Handle(Context context); }
    class ConcreteStateA : IState { public void Handle(Context context) { Console.WriteLine("StateA handling"); } }
    class ConcreteStateB : IState { public void Handle(Context context) { Console.WriteLine("StateB handling"); } }
    class Context {
        private IState _state;
        public Context(IState state) { _state = state; }
        public void SetState(IState state) { _state = state; }
        public void Request() { _state.Handle(this); }
    }
}
