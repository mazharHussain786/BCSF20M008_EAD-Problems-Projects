using System;

// State Interface
interface IState
{
    void Handle();
}

// Concrete States
class ConcreteStateA : IState
{
    public void Handle()
    {
        Console.WriteLine("Handling in State A");
    }
}

class ConcreteStateB : IState
{
    public void Handle()
    {
        Console.WriteLine("Handling in State B");
    }
}

// Context
class Context
{
    private IState state;

    public Context(IState state)
    {
        this.state = state;
    }

    public void SetState(IState state)
    {
        this.state = state;
    }

    public void Request()
    {
        state.Handle();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("State Pattern Example 1:");

        IState stateA = new ConcreteStateA();
        Context context1 = new Context(stateA);
        context1.Request();

        Console.WriteLine("\nState Pattern Example 2:");

        IState stateB = new ConcreteStateB();
        Context context2 = new Context(stateB);
        context2.Request();
    }
}
