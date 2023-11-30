using System;

// Strategy Interface
interface IStrategy
{
    void Execute();
}

// Concrete Strategies
class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Concrete Strategy A");
    }
}

class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Concrete Strategy B");
    }
}

// Context
class Context
{
    private IStrategy strategy;

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Strategy Pattern Example 1:");

        IStrategy strategyA = new ConcreteStrategyA();
        Context context1 = new Context(strategyA);
        context1.ExecuteStrategy();

        Console.WriteLine("\nStrategy Pattern Example 2:");

        IStrategy strategyB = new ConcreteStrategyB();
        Context context2 = new Context(strategyB);
        context2.ExecuteStrategy();
    }
}
