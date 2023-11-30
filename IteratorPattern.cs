using System;
using System.Collections;
using System.Collections.Generic;

// Concrete Aggregate
class MyCollection : IEnumerable<int>
{
    private List<int> items = new List<int>();

    public void Add(int item)
    {
        items.Add(item);
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new MyIterator(items);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Custom Iterator
    private class MyIterator : IEnumerator<int>
    {
        private List<int> collection;
        private int index = -1;

        public MyIterator(List<int> collection)
        {
            this.collection = collection;
        }

        public int Current => collection[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;
            return index < collection.Count;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose() { }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iterator Pattern Example 1:");

        MyCollection collection = new MyCollection();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);

        // Using the custom iterator to iterate through the collection
        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nIterator Pattern Example 2:");

        // Example of using the built-in iterator (List<T>)
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Using the built-in iterator to iterate through the list
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
