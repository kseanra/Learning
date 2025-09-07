// Use case: Apply the Interpreter pattern when you need to evaluate sentences in a language, such as parsing expressions or commands.
using System;
public interface IInterpreterPattern { void RunExample(); }
public class InterpreterPattern : IInterpreterPattern {
    public void RunExample() {
        Console.WriteLine("Interpreter Pattern Example:");
        Context context = new Context("42");
        IExpression expression = new NumberExpression();
        Console.WriteLine($"Interpreted: {expression.Interpret(context)}");
    }
    class Context {
        public string Input;
        public Context(string input) { Input = input; }
    }
    interface IExpression { int Interpret(Context context); }
    class NumberExpression : IExpression {
        public int Interpret(Context context) => int.TryParse(context.Input, out var result) ? result : 0;
    }
}
