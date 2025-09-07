// Use case: Apply the Template Method pattern when you want to define the skeleton of an algorithm, deferring some steps to subclasses.
using System;
public interface ITemplateMethodPattern { void RunExample(); }
public class TemplateMethodPattern : ITemplateMethodPattern {
    public void RunExample() {
        Console.WriteLine("Template Method Pattern Example:");
        AbstractClass instance = new ConcreteClass();
        instance.TemplateMethod();
    }
    abstract class AbstractClass {
        public void TemplateMethod() {
            StepOne();
            StepTwo();
        }
        protected abstract void StepOne();
        protected abstract void StepTwo();
    }
    class ConcreteClass : AbstractClass {
        protected override void StepOne() { Console.WriteLine("Step One"); }
        protected override void StepTwo() { Console.WriteLine("Step Two"); }
    }
}
