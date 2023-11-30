using System;

// Command Interface
interface ICommand
{
    void Execute();
}

// Receiver
class Receiver
{
    public void Action()
    {
        Console.WriteLine("Receiver: Performing action");
    }
}

// Concrete Command
class ConcreteCommand : ICommand
{
    private Receiver receiver;

    public ConcreteCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }

    public void Execute()
    {
        receiver.Action();
    }
}

// Invoker
class Invoker
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteCommand()
    {
        command.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Command Pattern Example 1:");

        Receiver receiver = new Receiver();
        ICommand command = new ConcreteCommand(receiver);
        Invoker invoker = new Invoker();

        invoker.SetCommand(command);
        invoker.ExecuteCommand();

        Console.WriteLine("\nCommand Pattern Example 2:");

        Receiver receiver2 = new Receiver();
        ICommand command2 = new ConcreteCommand(receiver2);
        Invoker invoker2 = new Invoker();

        invoker2.SetCommand(command2);
        invoker2.ExecuteCommand();
    }
}
