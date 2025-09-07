using System;
public interface IAbstractFactoryPattern {
    void RunExample();
}
public class AbstractFactoryPattern : IAbstractFactoryPattern {
    public void RunExample() {
        Console.WriteLine("Abstract Factory Pattern Example:");
        IGUIFactory factory = new WinFactory();
        IButton button = factory.CreateButton();
        Console.WriteLine($"Button: {button.Paint()}");
    }
    interface IButton { string Paint(); }
    class WinButton : IButton { public string Paint() => "Windows Button"; }
    interface IGUIFactory { IButton CreateButton(); }
    class WinFactory : IGUIFactory { public IButton CreateButton() => new WinButton(); }
}
