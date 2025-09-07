// Use case: Apply the State pattern when an object needs to change its behavior based on its internal state.
using System;
public interface IStatePattern { void RunExample(); }
public class StatePattern : IStatePattern {
    public void RunExample()
    {
        Console.WriteLine("State Pattern Example:");
        var context = new Context(new Red());
        context.Change();
        context.Change();
        context.Change();
    }
    interface ITrafficLightState { void Change(Context context); }
    class Red : ITrafficLightState {
        public void Change(Context context) {
            Console.WriteLine("Red -> Yellow");
            context.SetState(new Yellow());
        }
    }
    class Yellow : ITrafficLightState {
        public void Change(Context context) {
            Console.WriteLine("Yellow -> Green");   
            context.SetState(new Green());
        }
    }

    class Green : ITrafficLightState {
        public void Change(Context context) {
            Console.WriteLine("Green -> Red");
            context.SetState(new Red());//
        }
    }

    class Context
    {
        private ITrafficLightState _state;
        public Context(ITrafficLightState state) { _state = state; }
        public void SetState(IState state) { _state = state; }
        public void Request() { _state.Handle(this); }
    }
}
