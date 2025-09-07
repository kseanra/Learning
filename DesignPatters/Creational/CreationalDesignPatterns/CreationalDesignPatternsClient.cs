using System;
public class CreationalDesignPatternsClient {
    private readonly IFactoryMethodPattern _factoryMethod;
    private readonly IAbstractFactoryPattern _abstractFactory;
    private readonly ISingletonPattern _singleton;
    private readonly IBuilderPattern _builder;
    private readonly IPrototypePattern _prototype;
    public CreationalDesignPatternsClient(
        IFactoryMethodPattern factoryMethod,
        IAbstractFactoryPattern abstractFactory,
        ISingletonPattern singleton,
        IBuilderPattern builder,
        IPrototypePattern prototype) {
        _factoryMethod = factoryMethod;
        _abstractFactory = abstractFactory;
        _singleton = singleton;
        _builder = builder;
        _prototype = prototype;
    }
    public void RunAllExamples() {
        Console.WriteLine("\n--- Running All Creational Design Patterns ---");
        _factoryMethod.RunExample();
        _abstractFactory.RunExample();
        _singleton.RunExample();
        _builder.RunExample();
        _prototype.RunExample();
    }
}
