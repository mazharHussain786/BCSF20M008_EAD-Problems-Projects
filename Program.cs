// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Assignment
{
 public class Program
{

    static string task1()
    {
        Console.WriteLine("Enter first name ");
        string? FirstName = Console.ReadLine();
        Console.WriteLine("Enter Last name");
        string? LastName = Console.ReadLine();
        return (FirstName + " " + LastName);
    }
    static string task2(string sentence)
    {
        if(sentence.Length<=5)
        {
            return sentence;
        }
        string lastFiveChar = sentence.Substring(sentence.Length - 5);
        return lastFiveChar;

    }
    static void task3()
    {
        Console.WriteLine(" City Name : ");
        string? City = Console.ReadLine();
        Console.WriteLine(" Temprature : ");
        double Temprature = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"The temparture of {City} is {Temprature}");
    }
    static void task4()
    {
        int[] arr = new int[5];
        for (int i = 0; i < 5; i++)
        {
            arr[i] = i;
        }
        foreach (var integer in arr)
        {
            Console.Write(integer + "  ");
        }
    }
    static void task5(string[] fruits)
    {
        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine(fruits[i]);
        }
    }
    static void task5b(string[] Colors)
    {
        int count = Colors.Length;
        foreach (var C in Colors)
        {
            Console.Write(C);
            count--;
            if (count != 0)
            {
                Console.Write(" , ");
            }
        }
        Console.WriteLine();
    }
    static void task6()
    {
        Random random = new Random();
        int[] Scores = new int[10];
        int i = 0;
        do
        {
            Scores[i] = random.Next(1, 100);
            i++;
        } while (i < 10);

        int sum = 0;

        i = 0;
        do
        {
            sum += Scores[i];
            i++;
        } while (i < 10);

        Console.WriteLine("Sum of array is "+ sum);


    }

    static void task7(int[] arr)
    {
        int maximum = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maximum)
            {
                maximum = arr[i];
            }

        }
        Console.WriteLine("Maximum Number : "+ maximum);
    }
    static void Swap(ref int a, ref int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
    }

    static void task8(int[] arr)
    {
        int EndIndex = arr.Length - 1;
        int StartIndex = 0;

        Console.WriteLine("Before Reverse \n");
        foreach (var entry in arr)
        {
            Console.Write(entry+" ");
        }

        foreach (var entry in arr)
        {
            if (StartIndex == EndIndex)
            {
                break;
            }
            Swap(ref arr[StartIndex], ref arr[EndIndex]);
            StartIndex++;
            EndIndex--;
        }
        Console.WriteLine("After Reverse \n");
        foreach (var entry in arr)
        {
            Console.Write(entry+" ");
        }
        Console.WriteLine();
    }
    static void task9()
    {
        int x = 42;
        // boxing
        object o1 = x;
        Console.WriteLine("Boxing "+ o1);

        // Unboxing

        int y = Convert.ToInt32((o1));

        Console.WriteLine("Unboxing "+ y);
    }
    static void task10()
    {
        double doubleValue = 3.1431;
        object o2 = doubleValue;
        Console.WriteLine("Boxing : "+ o2);

        double unBoxedValue = Convert.ToInt32(o2);
        Console.WriteLine("UnBoxing : "+ unBoxedValue);
    }

    static void task11a()
    {
        dynamic myVariable = 42;
        Console.WriteLine("myVariable : "+ myVariable);
        myVariable = "Hello Dynamic";
        Console.WriteLine(myVariable);
    }
    static void task11b()
    {
        dynamic myVariable = 15;
        Console.WriteLine(myVariable.GetType());
        myVariable = 2.44653;
        Console.Write(myVariable.GetType());
        myVariable = DateTime.Now;
        Console.WriteLine(myVariable.GetType());
        myVariable = "Pakistan";
        Console.WriteLine(myVariable.GetType());
    }
    static void LastTask(int [] arr)
    {
        for(int i=0 ;i<arr.Length ; i++)
        {
            object o1=arr[i];
            int x=Convert.ToInt32(o1);
            Console.WriteLine($"Boxing Value {o1} ...Integer Value {x} ...Power Value {x*x} ");
        }
        Console.WriteLine();
        List<object> mixedList=new List<object>();
        mixedList.Add(42);
        mixedList.Add(3.124);
        mixedList.Add('A');
        mixedList.Add("Pakistan");
        foreach(var item in mixedList)
        {
            Console.WriteLine($"Elemet {item}  Type : {item.GetType()}");
        }
        // Unboxing;
        int integer=Convert.ToInt32(mixedList[0]);
        double Do=Convert.ToDouble(mixedList[1]);
        Char a=Convert.ToChar(mixedList[2]);
        string? Mulk=Convert.ToString(mixedList[3]);
        Console.WriteLine($"Retrieved int value: {integer}");
        Console.WriteLine($"Retrieved double value: {Do}");
        Console.WriteLine($"Retrieved char value: {a}");
        Console.WriteLine($"Retrieved string value: {Mulk}");

    }

    static void Main(string[] args)
    {
        Console.WriteLine(task1());
        Console.WriteLine("---------------------------");
        Console.WriteLine(task2("I live in Pakistan"));
        Console.WriteLine("---------------------------");
        task3();
        Console.WriteLine("---------------------------");
        task4();
        string[] arr = { "Banana", "Apple", "Orange" };
        task5(arr);
        Console.WriteLine("---------------------------");
        string[] Colors = { "Red", "White", "Orange" };
        task5b(Colors);
        Console.WriteLine("---------------------------");
        task6();
        Console.WriteLine("---------------------------");
        int[] arrMax = { 2, 5, 6, 7, 1 };
        task7(arrMax);
        Console.WriteLine("---------------------------");
        task8(arrMax);
        Console.WriteLine("---------------------------");
        task9();
        Console.WriteLine("---------------------------");
        task10();
        Console.WriteLine("---------------------------");
        task11a();
        Console.WriteLine("---------------------------");
        task11b();
        Console.WriteLine("---------------------------");
        int [] arr3={1,34,6,7,10};
        LastTask(arr3);
        Console.WriteLine();
        Console.WriteLine("---------------End-----------------------");

    }
}
    
}

