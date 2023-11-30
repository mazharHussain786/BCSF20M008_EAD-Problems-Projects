using System;
using System.Collections.Generic;

class Mediator
{
    private List<Colleague> colleagues = new List<Colleague>();

    public void AddColleague(Colleague colleague)
    {
        colleagues.Add(colleague);
    }

    public void Notify(Colleague sender, string eventInfo)
    {
        foreach (var colleague in colleagues)
        {
            if (colleague != sender)
                colleague.ReceiveEvent(eventInfo);
        }
    }
}

abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void SendEvent(string eventInfo);
    public abstract void ReceiveEvent(string eventInfo);
}

class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator) { }

    public override void SendEvent(string eventInfo)
    {
        Console.WriteLine("ConcreteColleague1 sends event: " + eventInfo);
        mediator.Notify(this, eventInfo);
    }

    public override void ReceiveEvent(string eventInfo)
    {
        Console.WriteLine("ConcreteColleague1 receives event: " + eventInfo);
    }
}

class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator) { }

    public override void SendEvent(string eventInfo)
    {
        Console.WriteLine("ConcreteColleague2 sends event: " + eventInfo);
        mediator.Notify(this, eventInfo);
    }

    public override void ReceiveEvent(string eventInfo)
    {
        Console.WriteLine("ConcreteColleague2 receives event: " + eventInfo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mediator Pattern Example 1:");

        Mediator mediator = new Mediator();

        Colleague colleague1 = new ConcreteColleague1(mediator);
        Colleague colleague2 = new ConcreteColleague2(mediator);

        mediator.AddColleague(colleague1);
        mediator.AddColleague(colleague2);

        colleague1.SendEvent("Event from colleague 1 to others");
        colleague2.SendEvent("Event from colleague 2 to others");

        Console.WriteLine("\nMediator Pattern Example 2:");

        Mediator mediator2 = new Mediator();

        Colleague colleague3 = new ConcreteColleague1(mediator2);
        Colleague colleague4 = new ConcreteColleague2(mediator2);

        mediator2.AddColleague(colleague3);
        mediator2.AddColleague(colleague4);

        colleague3.SendEvent("Another event from colleague 1");
        colleague4.SendEvent("Another event from colleague 2");
    }
}
