using System;
public interface ISingletonPattern {
    void RunExample();
}
public class SingletonPattern : ISingletonPattern {
    public void RunExample() {
        Console.WriteLine("Singleton Pattern Example:");
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;
        Console.WriteLine($"Same instance: {ReferenceEquals(instance1, instance2)}");
    }
    class Singleton {
        private static Singleton _instance;
        private static readonly object _lock = new object();
        public static Singleton Instance {
            get {
                if (_instance == null) {
                    lock (_lock) {
                        if (_instance == null) _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }
}
