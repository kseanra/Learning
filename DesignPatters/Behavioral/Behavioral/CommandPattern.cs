// Use case: Apply the Command pattern when you want to encapsulate a request as an object, allowing for parameterization, queuing, and undo/redo operations.
using System;
public interface ICommandPattern { void RunExample(); }
public class CommandPattern : ICommandPattern {
    public void RunExample() {
        Console.WriteLine("Command Pattern Example:");
        var receiver = new Receiver();
        var command = new ConcreteCommand(receiver);
        var invoker = new Invoker(command);
        invoker.ExecuteCommand();
    }
    interface ICommand { void Execute(); }
    class ConcreteCommand : ICommand {
        private readonly Receiver _receiver;
        public ConcreteCommand(Receiver receiver) { _receiver = receiver; }
        public void Execute() { _receiver.Action(); }
    }
    class Receiver { public void Action() => Console.WriteLine("Receiver Action"); }
    class Invoker {
        private readonly ICommand _command;
        public Invoker(ICommand command) { _command = command; }
        public void ExecuteCommand() { _command.Execute(); }
    }
}
