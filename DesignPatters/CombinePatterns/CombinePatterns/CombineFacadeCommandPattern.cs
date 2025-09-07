// Use case: Combining Facade and Command for simplified subsystem access and encapsulated requests
using System;
public interface IFacadeCommandPattern { void RunExample(); }
public class FacadeCommandPattern : IFacadeCommandPattern {
    public void RunExample() {
        Console.WriteLine("Facade + Command Pattern Example:");
        var facade = new Facade();
        var command = new ConcreteCommand(facade);
        command.Execute();
    }
    interface ICommand { void Execute(); }
    class ConcreteCommand : ICommand {
        private readonly Facade _facade;
        public ConcreteCommand(Facade facade) { _facade = facade; }
        public void Execute() { _facade.Operation(); }
    }
    class Facade {
        public void Operation() { Console.WriteLine("Facade Operation Executed"); }
    }
}
