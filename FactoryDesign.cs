namespace Patterns
{
    public interface IProduct
{
    void DisplayInfo();
}

public class ConcreteProductA : IProduct
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductA info.");
    }
}

public class ConcreteProductB : IProduct
{
    public void DisplayInfo()
    {
        Console.WriteLine("ConcreteProductB info.");
    }
}

public class SimpleFactory
{
    public IProduct CreateProduct(string type)
    {
        switch (type)
        {
            case "A":
                return new ConcreteProductA();
            case "B":
                return new ConcreteProductB();
            default:
                throw new ArgumentException("Invalid product type");
        }
    }
}
public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

}