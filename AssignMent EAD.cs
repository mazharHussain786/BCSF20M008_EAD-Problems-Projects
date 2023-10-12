using System;
using System.Collections.Generic;


class Program
{
   //Question 1

    //a
        static public void Greeting(string greeting = "Hello", string name = " World ")
        {
            Console.WriteLine($"{greeting} , {name} !");
        }

    //b

    static double CalculateArea(double length = 1.0, double width = 1.0)
        {
            return length * width;
        }

    //c
        static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        static int AddNumbers(int a, int b, int c = 0)
        {
            return a + b + c;
        }
        static void Swap<T>(ref T a,ref T b)
        {
            (b, a) = (a, b);
        }


    //d
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public Book(string title, string author = "Unknown")
        {
            this.title = title;
            this.author = author;
        }
        public void display()
        {
            Console.WriteLine($"title : {title} , author : {author}");
        }
    }




    //Question 2

    //a

    public class MyList<T>
    {
        public List<T> list = new List<T>();

        public void addElements(T element)
        {
            list.Add(element);
        }
        public void removeElements(T element)
        {
            list.Remove(element);
        }
        public void Display()
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }


    //b
    


    //c
    static double Sum<T>(T[] list)
    {
        double sum = 0.0;

        foreach (var val in list)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double) || typeof(T)==typeof(float))
            {
                sum += Convert.ToDouble(val);
            }
            else
            {
                Console.WriteLine("Wrong Type");
                break;
            }
        }

        return sum;
    }



    //d

    static Dictionary<int, string> studentDatabase = new Dictionary<int, string>();

    static void addStudent(int id, string name)
    {
        bool flag = true;
        foreach (var item in studentDatabase)
        {
            if (id == item.Key)
            {
                flag = false;
                Console.WriteLine("Already Exist ID");
                break;
            }
        }
        if (flag)
        {

            studentDatabase.Add(id, name);
            
        }
    }
    static void retriveStudent(int id)
    {
        bool flag = true;
        foreach (var item in studentDatabase)
        {
            if (id == item.Key)
            {
                Console.WriteLine(item.Value);
                flag = false;
                break;
            }
        }
        if (flag)
        {
            Console.WriteLine($"Student with Id {id} does not exist !!");
        }
    }
    static void displayDatabase()
    {

        foreach (var item in studentDatabase)
        {
            Console.WriteLine($"Student ID : {item.Key} Student Name : {item.Value}");
        }

    }

    static void updateStudent(int id, string name)
    {
        bool flag = true;
        foreach (var item in studentDatabase)
        {
            if (id == item.Key)
            {
                studentDatabase[id] = name;
                flag = false;
                break;
            }
        }
        if (flag)
        {
            Console.WriteLine($"Student with Id {id} does not exist !!");
        }
    }



    static void Main(string[] args)
    {
       // Question 1

     //   a

        Greeting();
        Greeting("Hello", "Mazhar");

      //  b

        Console.WriteLine(CalculateArea());
        Console.WriteLine(CalculateArea(2.4,6.7));

       // c

     //   Question1c

        Console.WriteLine(AddNumbers(2, 3));
        Console.WriteLine(AddNumbers(2, 3, 4));

      //  d

       // Question 1d

        Book b1 = new Book("Math");
        b1.display();
        Book b2 = new Book("Islamiyat","Mazhar");
        b2.display();


      //  Question 2

       // a

      

        MyList<int> intObject = new MyList<int>();
        intObject.addElements(10);
        intObject.addElements(20);
        intObject.Display();
        intObject.removeElements(10);
        intObject.Display();

        MyList<double> doubleObject = new MyList<double>();
        doubleObject.addElements(10.9);
        doubleObject.addElements(20.9);
        doubleObject.Display();
        doubleObject.removeElements(10.9);
        doubleObject.Display();


    //    b

       


        int a = 2;
        int b = 3;
        Swap<int>(ref a, ref b);
        Console.WriteLine($"a : {a} b :{b}");

        string string_a = "Mazhar";
        string string_b = "Hussain";
        Swap<string>(ref string_a, ref string_b);
        Console.WriteLine($"a : {string_a} b :{string_b}");



     //   c

       

        int[] int_array = { 1, 2, 3, 4, 5 };
        Console.WriteLine(Sum(int_array));

        long[] long_array = { 3, 4, 5, 6, };
        Console.WriteLine(Sum(long_array));

        float[] float_array = { (float)1.1, (float)2.2, (float)3.3 };
        Console.WriteLine(Sum(float_array));

        double[] double_array = { 1.1, 2.2, 3.3 };
        Console.WriteLine(Sum(double_array));


     //   d




        addStudent(101, "Alice");
        addStudent(102, "Bob");
        addStudent(103, "Charlie");
        addStudent(104, "David");

        bool flag = true;


        while(flag)
        {
           Console.WriteLine("1. View the student database");
           Console.WriteLine("2. Search for a student by ID");
           Console.WriteLine("3. Update a student's name");
           Console.WriteLine("4.Exit the program");
           int Choice =Convert.ToInt32( Console.ReadLine());
           switch(Choice)
           {
               case 1:
                   {
                       displayDatabase();
                       break;
                   }
               case 2:
                   {
                       Console.WriteLine("Enter ID!");
                       int id = Convert.ToInt32(Console.ReadLine());
                       retriveStudent(id);
                       break;
                   }
               case 3:
                   {
                       Console.WriteLine("Enter ID!");
                       int id = Convert.ToInt32(Console.ReadLine());
                       Console.WriteLine("Enter Name!");
                       string name = Console.ReadLine();
                       updateStudent(id,name);
                       break;
                   }
               case 4:
                   {
                       flag = false;
                       break;
                   }

           }
        }











    }


}

