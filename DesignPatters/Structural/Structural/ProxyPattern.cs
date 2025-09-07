// Use case: Apply the Proxy pattern when you need to control access to an object, such as lazy loading, logging, or access control for resources.
using System;
// Proxy Pattern
public interface IProxyPattern { void RunExample(); }
public class ProxyPattern : IProxyPattern {
    public void RunExample() {
        Console.WriteLine("Proxy Pattern Example:");
        ISubject proxy = new Proxy();
        proxy.Request();
    }
    interface ISubject { void Request(); }
    class RealSubject : ISubject { public void Request() => Console.WriteLine("RealSubject Request"); }
    class Proxy : ISubject {
        private RealSubject _realSubject;
        public void Request() {
            if (_realSubject == null) _realSubject = new RealSubject();
            Console.WriteLine("Proxy delegating to RealSubject...");
            _realSubject.Request();
        }
    }
}
