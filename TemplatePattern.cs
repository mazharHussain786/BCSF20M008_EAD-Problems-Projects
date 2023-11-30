using System;

abstract class AbstractClass
{
    public void TemplateMethod()
    {
        Console.WriteLine("Executing Template Method...");
        BaseOperation1();
        RequiredOperation1();
        BaseOperation2();
        Hook();
    }

    protected void BaseOperation1()
    {
        Console.WriteLine("AbstractClass: base operation 1");
    }

    protected abstract void RequiredOperation1();

    protected void BaseOperation2()
    {
        Console.WriteLine("AbstractClass: base operation 2");
    }

    protected virtual void Hook()
    {
        Console.WriteLine("AbstractClass: default hook operation");
    }
}

class ConcreteClass1 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass1: overridden required operation 1");
    }

    protected override void Hook()
    {
        Console.WriteLine("ConcreteClass1: overridden hook operation");
    }
}

class ConcreteClass2 : AbstractClass
{
    protected override void RequiredOperation1()
    {
        Console.WriteLine("ConcreteClass2: overridden required operation 1");
    }

    protected override void Hook()
    {
        Console.WriteLine("ConcreteClass2: overridden hook operation");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Template Method Pattern Example 1:");
        AbstractClass concrete1 = new ConcreteClass1();
        concrete1.TemplateMethod();

        Console.WriteLine("\nTemplate Method Pattern Example 2:");
        AbstractClass concrete2 = new ConcreteClass2();
        concrete2.TemplateMethod();
    }
}
