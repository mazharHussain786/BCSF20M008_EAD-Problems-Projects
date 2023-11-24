using System;
using System.Collections.Generic;

// Adapter Design Pattern

// Target interface
interface ITarget
{
    void Request();
}

// Adaptee (the class to be adapted)
class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific Request");
    }
}

// Object Adapter
class ObjectAdapter : ITarget
{
    private Adaptee adaptee;

    public ObjectAdapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

// Class Adapter
class ClassAdapter : Adaptee, ITarget
{
    public void Request()
    {
        SpecificRequest();
    }
}

// Composite Design Pattern

// Component
interface IGraphic
{
    void Draw();
}

// Leaf
class Circle : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

// Leaf
class Square : IGraphic
{
    public void Draw()
    {
        Console.WriteLine("Drawing Square");
    }
}

// Composite
class CompositeGraphic : IGraphic
{
    private List<IGraphic> graphics = new List<IGraphic>();

    public void Add(IGraphic graphic)
    {
        graphics.Add(graphic);
    }

    public void Draw()
    {
        foreach (var graphic in graphics)
        {
            graphic.Draw();
        }
    }
}

// Proxy Design Pattern

// Subject interface
interface ISubject
{
    void Request();
}

// RealSubject
class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("Real Subject Request");
    }
}

// Proxy
class Proxy : ISubject
{
    private RealSubject? realSubject;

    public void Request()
    {
        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }

        Console.WriteLine("Proxy Request");
        realSubject.Request();
    }
}

// Flyweight Design Pattern

// Flyweight interface
interface IFlyweight
{
    void Operation();
}

// ConcreteFlyweight
class ConcreteFlyweight : IFlyweight
{
    private string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation()
    {
        Console.WriteLine($"Concrete Flyweight: {intrinsicState}");
    }
}

// FlyweightFactory
class FlyweightFactory
{
    private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new ConcreteFlyweight(key);
        }

        return flyweights[key];
    }
}

// Facade Design Pattern

// Subsystem components
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("Subsystem A operation");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("Subsystem B operation");
    }
}

class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("Subsystem C operation");
    }
}

// Facade
class Facade
{
    private SubsystemA subsystemA;
    private SubsystemB subsystemB;
    private SubsystemC subsystemC;

    public Facade()
    {
        subsystemA = new SubsystemA();
        subsystemB = new SubsystemB();
        subsystemC = new SubsystemC();
    }

    public void Operation()
    {
        Console.WriteLine("Facade operation:");
        subsystemA.OperationA();
        subsystemB.OperationB();
        subsystemC.OperationC();
    }
}

// Bridge Design Pattern

// Implementor interface
interface IImplementor
{
    void OperationImp();
}

// ConcreteImplementor
class ConcreteImplementorA : IImplementor
{
    public void OperationImp()
    {
        Console.WriteLine("Concrete Implementor A operation");
    }
}

class ConcreteImplementorB : IImplementor
{
    public void OperationImp()
    {
        Console.WriteLine("Concrete Implementor B operation");
    }
}

// Abstraction
abstract class Abstraction
{
    protected IImplementor implementor;

    public Abstraction(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public abstract void Operation();
}

// RefinedAbstraction
class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor) { }

    public override void Operation()
    {
        Console.WriteLine("Refined Abstraction operation");
        implementor.OperationImp();
    }
}

// Decorator Design Pattern

// Component
interface IComponent
{
    void Operation();
}

// ConcreteComponent
class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Concrete Component operation");
    }
}

// Decorator
abstract class Decorator : IComponent
{
    protected IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public abstract void Operation();
}

// ConcreteDecorator
class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }

    public override void Operation()
    {
        base.component.Operation();
        Console.WriteLine("Concrete Decorator operation");
    }

class MainProgram
{
    static void Main()
    {
        Console.WriteLine("Adapter Design Pattern Example:");
        Adaptee adaptee = new Adaptee();
        ITarget target1 = new ObjectAdapter(adaptee);
        target1.Request();

        ITarget target2 = new ClassAdapter();
        target2.Request();

        Console.WriteLine("\nComposite Design Pattern Example:");
        var circle = new Circle();
        var square = new Square();
        var compositeGraphic = new CompositeGraphic();
        compositeGraphic.Add(circle);
        compositeGraphic.Add(square);
        compositeGraphic.Draw();

        Console.WriteLine("\nProxy Design Pattern Example:");
        ISubject proxy = new Proxy();
        proxy.Request();

        Console.WriteLine("\nFlyweight Design Pattern Example:");
        FlyweightFactory factory = new FlyweightFactory();
        IFlyweight flyweight1 = factory.GetFlyweight("A");
        flyweight1.Operation();
        IFlyweight flyweight2 = factory.GetFlyweight("B");
        flyweight2.Operation();

        Console.WriteLine("\nFacade Design Pattern Example:");
        Facade facade = new Facade();
        facade.Operation();

        Console.WriteLine("\nBridge Design Pattern Example:");
        IImplementor implementorA = new ConcreteImplementorA();
        IImplementor implementorB = new ConcreteImplementorB();
        Abstraction abstractionA = new RefinedAbstraction(implementorA);
        abstractionA.Operation();
        Abstraction abstractionB = new RefinedAbstraction(implementorB);
        abstractionB.Operation();

        Console.WriteLine("\nDecorator Design Pattern Example:");
        IComponent component = new ConcreteComponent();
        IComponent decoratedComponent = new ConcreteDecorator(component);
        decoratedComponent.Operation();

        Console.ReadLine();
    }
}
}
