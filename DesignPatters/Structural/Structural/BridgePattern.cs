// Use case: Apply the Bridge pattern when you want to separate abstraction from implementation, 
// allowing them to vary independently (e.g., different UI platforms with shared logic).
using System;
// Bridge Pattern
public interface IBridgePattern { void RunExample(); }
public class BridgePattern : IBridgePattern {
    public void RunExample() {
        Console.WriteLine("Bridge Pattern Example:");
        IImplementor implementor = new ConcreteImplementorA();
        Abstraction abstraction = new RefinedAbstraction(implementor);
        abstraction.Operation();
    }
    interface IImplementor { void OperationImpl(); }
    class ConcreteImplementorA : IImplementor { public void OperationImpl() => Console.WriteLine("ConcreteImplementorA Operation"); }
    class ConcreteImplementorB : IImplementor { public void OperationImpl() => Console.WriteLine("ConcreteImplementorB Operation"); }
    abstract class Abstraction {
        protected IImplementor _implementor;
        public Abstraction(IImplementor implementor) { _implementor = implementor; }
        public virtual void Operation() { _implementor.OperationImpl(); }
    }
    class RefinedAbstraction : Abstraction {
        public RefinedAbstraction(IImplementor implementor) : base(implementor) { }
        public override void Operation() { base.Operation(); }
    }
}
