using System;
using System.Collections.Generic;

// Subject (Observable)
interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject (Concrete Observable)
class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private int state;

    public int State
    {
        get { return state; }
        set
        {
            state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

// Observer
interface IObserver
{
    void Update();
}

// Concrete Observer
class ConcreteObserver : IObserver
{
    private string name;
    private ConcreteSubject subject;

    public ConcreteObserver(string name, ConcreteSubject subject)
    {
        this.name = name;
        this.subject = subject;
    }

    public void Update()
    {
        Console.WriteLine($"Observer {name} updated with state: {subject.State}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Observer Pattern Example 1:");

        ConcreteSubject subject = new ConcreteSubject();
        ConcreteObserver observer1 = new ConcreteObserver("Observer 1", subject);
        ConcreteObserver observer2 = new ConcreteObserver("Observer 2", subject);

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.State = 10;

        Console.WriteLine("\nObserver Pattern Example 2:");

        ConcreteSubject subject2 = new ConcreteSubject();
        ConcreteObserver observer3 = new ConcreteObserver("Observer 3", subject2);
        ConcreteObserver observer4 = new ConcreteObserver("Observer 4", subject2);

        subject2.Attach(observer3);
        subject2.Attach(observer4);

        subject2.State = 20;
    }
}
