using System;
using System.Collections.Generic;

// Visitor Interface
interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
    void Visit(Element element);
}

// Element Interface
interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete Elements
class ElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void OperationA()
    {
        Console.WriteLine("Operation A performed on Element A");
    }
}

class ElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void OperationB()
    {
        Console.WriteLine("Operation B performed on Element B");
    }
}

class Element : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Operation()
    {
        Console.WriteLine("Operation performed on Element");
    }
}

// Concrete Visitor
class ConcreteVisitor : IVisitor
{
    public void Visit(ElementA element)
    {
        element.OperationA();
    }

    public void Visit(ElementB element)
    {
        element.OperationB();
    }

    public void Visit(Element element)
    {
        element.Operation();
    }
}

// Object Structure
class ObjectStructure
{
    private List<IElement> elements = new List<IElement>();

    public void Attach(IElement element)
    {
        elements.Add(element);
    }

    public void Detach(IElement element)
    {
        elements.Remove(element);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Visitor Pattern Example 1:");

        List<IElement> elements = new List<IElement>
        {
            new ElementA(),
            new ElementB(),
            new Element()
        };

        IVisitor visitor = new ConcreteVisitor();

        foreach (var element in elements)
        {
            element.Accept(visitor);
        }

        Console.WriteLine("\nVisitor Pattern Example 2:");

        ObjectStructure structure = new ObjectStructure();
        structure.Attach(new Element());
        structure.Attach(new ElementA());
        structure.Attach(new ElementB());

        IVisitor visitor2 = new ConcreteVisitor();
        structure.Accept(visitor2);
    }
}
