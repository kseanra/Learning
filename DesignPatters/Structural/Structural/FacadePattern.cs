// Use case: Apply the Facade pattern when you want to provide a simplified interface to a complex subsystem, such as hiding multiple APIs behind a single entry point.
using System;
// Facade Pattern
public interface IFacadePattern { void RunExample(); }
public class FacadePattern : IFacadePattern {
    public void RunExample() {
        Console.WriteLine("Facade Pattern Example:");
        Facade facade = new Facade();
        facade.Operation();
    }
    class SubsystemA { public void OperationA() => Console.WriteLine("SubsystemA Operation"); }
    class SubsystemB { public void OperationB() => Console.WriteLine("SubsystemB Operation"); }
    class Facade {
        private readonly SubsystemA _a = new();
        private readonly SubsystemB _b = new();
        public void Operation() {
            _a.OperationA();
            _b.OperationB();
        }
    }
}
