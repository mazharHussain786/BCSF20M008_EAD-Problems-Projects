using System;

abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Console.WriteLine("ConcreteHandler1 handles request: " + request);
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine("ConcreteHandler2 handles request: " + request);
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Chain of Responsibility Pattern Example 1:");
        Handler handler1 = new ConcreteHandler1();
        Handler handler2 = new ConcreteHandler2();

        handler1.SetSuccessor(handler2);

        handler1.HandleRequest(5);
        handler1.HandleRequest(15);

        Console.WriteLine("\nChain of Responsibility Pattern Example 2:");
        Handler handler3 = new ConcreteHandler1();
        Handler handler4 = new ConcreteHandler2();

        handler3.SetSuccessor(handler4);

        handler3.HandleRequest(8);
        handler3.HandleRequest(25);
    }
}
