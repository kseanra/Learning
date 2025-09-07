// Use case: Combining Factory Method and Singleton for controlled instance creation
using System;
public interface IFactorySingletonPattern { void RunExample(); }
public class FactorySingletonPattern : IFactorySingletonPattern
{
    public void RunExample()
    {
        Console.WriteLine("Factory Method + Singleton Pattern Example:");
        var factory = new SingletonFactory();
        var instance1 = factory.GetInstance();
        var instance2 = factory.GetInstance();
        Console.WriteLine($"Same instance: {ReferenceEquals(instance1, instance2)}");
    }
    class Product { }
    class SingletonFactory
    {
        private Product _instance;
        public Product GetInstance()
        {
            if (_instance == null) _instance = new Product();
            return _instance;
        }
    }
}

