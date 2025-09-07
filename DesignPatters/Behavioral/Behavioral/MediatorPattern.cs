// Use case: Apply the Mediator pattern when you want to reduce coupling between components by having them communicate through a central mediator.
using System;
public interface IMediatorPattern { void RunExample(); }
public class MediatorPattern : IMediatorPattern {
    public void RunExample() {
        Console.WriteLine("Mediator Pattern Example:");
        var mediator = new ConcreteMediator();
        var colleagueA = new ConcreteColleagueA(mediator);
        var colleagueB = new ConcreteColleagueB(mediator);
        mediator.ColleagueA = colleagueA;
        mediator.ColleagueB = colleagueB;
        colleagueA.Send("Hello from A");
        colleagueB.Send("Hello from B");
    }
    abstract class Colleague {
        protected IMediator _mediator;
        public Colleague(IMediator mediator) { _mediator = mediator; }
    }
    interface IMediator {
        void Send(string message, Colleague colleague);
    }
    class ConcreteMediator : IMediator {
        public ConcreteColleagueA ColleagueA { get; set; }
        public ConcreteColleagueB ColleagueB { get; set; }
        public void Send(string message, Colleague colleague) {
            if (colleague == ColleagueA) ColleagueB.Receive(message);
            else ColleagueA.Receive(message);
        }
    }
    class ConcreteColleagueA : Colleague {
        public ConcreteColleagueA(IMediator mediator) : base(mediator) { }
        public void Send(string message) { _mediator.Send(message, this); }
        public void Receive(string message) { Console.WriteLine($"ColleagueA received: {message}"); }
    }
    class ConcreteColleagueB : Colleague {
        public ConcreteColleagueB(IMediator mediator) : base(mediator) { }
        public void Send(string message) { _mediator.Send(message, this); }
        public void Receive(string message) { Console.WriteLine($"ColleagueB received: {message}"); }
    }
}
