namespace Patterns{
public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public interface IProductA
{
    void DisplayInfo();
}

public interface IProductB
{
    void DisplayInfo();
}

public class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();
    }
}

public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA2();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}

public class ConcreteProductA1 : IProductA
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductA1 info.");
    }
}

public class ConcreteProductB1 : IProductB
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductB1 info.");
    }
}

public class ConcreteProductA2 : IProductA
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductA2 info.");
    }
}

public class ConcreteProductB2 : IProductB
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductB2 info.");
    }
}
}
