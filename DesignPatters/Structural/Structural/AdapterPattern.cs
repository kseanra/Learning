// Use case: Apply the Adapter pattern when you need to make two incompatible interfaces work together, 
//such as integrating legacy code with new systems.
using System;
// Adapter Pattern
public interface IAdapterPattern { void RunExample(); }
public class AdapterPattern : IAdapterPattern {
    public void RunExample() {
        Console.WriteLine("Adapter Pattern Example:");
        ITarget target = new Adapter(new Adaptee());
        Console.WriteLine(target.Request());
    }
    interface ITarget { string Request(); }
    class Adaptee { public string SpecificRequest() => "Adaptee's Specific Request"; }
    class Adapter : ITarget {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee) { _adaptee = adaptee; }
        public string Request() => _adaptee.SpecificRequest();
    }
}
