// Use case: Apply the Chain of Responsibility pattern when you want to pass a request along a chain of handlers, allowing each handler to process or pass it on.
using System;
public interface IChainOfResponsibilityPattern { void RunExample(); }
public class ChainOfResponsibilityPattern : IChainOfResponsibilityPattern {
    public void RunExample() {
        Console.WriteLine("Chain of Responsibility Pattern Example:");
        Handler handler1 = new ConcreteHandlerA();
        Handler handler2 = new ConcreteHandlerB();
        handler1.SetNext(handler2);
        handler1.Handle("RequestA");
        handler1.Handle("RequestB");
    }
    abstract class Handler {
        protected Handler _next;
        public void SetNext(Handler next) { _next = next; }
        public abstract void Handle(string request);
    }
    class ConcreteHandlerA : Handler {
        public override void Handle(string request) {
            if (request == "RequestA") Console.WriteLine("Handled by A");
            else _next?.Handle(request);
        }
    }
    class ConcreteHandlerB : Handler {
        public override void Handle(string request) {
            if (request == "RequestB") Console.WriteLine("Handled by B");
            else _next?.Handle(request);
        }
    }
}
