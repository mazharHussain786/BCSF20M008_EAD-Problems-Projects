namespace Patterns{
public class Singleton
{
    private static Singleton? instance;

    private Singleton() { }

    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Singleton instance method called.");
    }
}
public class ThreadSafeSingleton
{
    private static ThreadSafeSingleton? instance;
    private static readonly object padlock = new object();

    private ThreadSafeSingleton() { }

    public static ThreadSafeSingleton GetInstance()
    {
        lock (padlock)
        {
            if (instance == null)
            {
                instance = new ThreadSafeSingleton();
            }
            return instance;
        }
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Thread-safe Singleton instance method called.");
    }
}

}
