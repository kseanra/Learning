using System;
public interface IBuilderPattern {
    void RunExample();
}
public class BuilderPattern : IBuilderPattern {
    public void RunExample() {
        Console.WriteLine("Builder Pattern Example:");
        var builder = new CarBuilder();
        var director = new Director(builder);
        director.Construct();
        var product = builder.GetResult();
        Console.WriteLine($"Product: {product}");
    }
    interface ICarBuilder
    {
        void BuildEngine();
        void BuildWheels();
        void Paint(string color);
        string GetResult();
    }
    class CarBuilder : ICarBuilder {
        private string _result = "";
        public void BuildEngine() { _result += "Engine "; }
        public void BuildWheels() { _result += "Wheels "; }
        public void Paint(string color) { _result += $"Painted {color} "; }
        public string GetResult() => _result + "Built";
    }
    class Director {
        private readonly ICarBuilder _builder;
        public Director(ICarBuilder builder) { _builder = builder; }
        public void Construct() {
            _builder.BuildEngine();
            _builder.BuildWheels();
            _builder.Paint("Red");
        }
    }
}
