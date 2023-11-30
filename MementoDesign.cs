using System;

// Memento
class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

// Originator
class Originator
{
    public string State { get; set; }

    public Memento Save()
    {
        return new Memento(State);
    }

    public void Restore(Memento memento)
    {
        State = memento.State;
    }
}

// Caretaker
class Caretaker
{
    public Memento Memento { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Memento Pattern Example 1:");

        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        // Setting state in the originator and saving the state in the caretaker
        originator.State = "State 1";
        caretaker.Memento = originator.Save();

        // Changing state in the originator
        originator.State = "State 2";

        // Restoring previous state from the caretaker
        originator.Restore(caretaker.Memento);
        Console.WriteLine("Restored State: " + originator.State);

        Console.WriteLine("\nMemento Pattern Example 2:");

        Originator originator2 = new Originator();
        Caretaker caretaker2 = new Caretaker();

        // Setting state in the originator and saving the state in the caretaker
        originator2.State = "Hello";
        caretaker2.Memento = originator2.Save();

        // Changing state in the originator
        originator2.State = "Hello World";

        // Restoring previous state from the caretaker
        originator2.Restore(caretaker2.Memento);
        Console.WriteLine("Restored State: " + originator2.State);
    }
}
