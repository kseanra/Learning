
class Porgram
{
    static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IFactoryMethodPattern, FactoryMethodPattern>();
                services.AddTransient<IAbstractFactoryPattern, AbstractFactoryPattern>();
                services.AddTransient<ISingletonPattern, SingletonPattern>();
                services.AddTransient<IBuilderPattern, BuilderPattern>();
                services.AddTransient<IPrototypePattern, PrototypePattern>();
                services.AddTransient<CreationalDesignPatternsClient>();
            })
            .Build();

        // Resolve services and demonstrate usage
        var serviceProvider = host.Services;

        var factoryMethod = serviceProvider.GetService<IFactoryMethodPattern>();
        factoryMethod?.RunExample();

        var abstractFactory = serviceProvider.GetService<IAbstractFactoryPattern>();
        abstractFactory?.RunExample();

        var singleton = serviceProvider.GetService<ISingletonPattern>();
        singleton?.RunExample();

        var builder = serviceProvider.GetService<IBuilderPattern>();
        builder?.RunExample();

        var prototype = serviceProvider.GetService<IPrototypePattern>();
        prototype?.RunExample();

        var client = serviceProvider.GetService<CreationalDesignPatternsClient>();
        client?.RunAllExamples();
    }
}