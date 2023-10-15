using System;
using System.Collections.Generic;


class Calculator
{

   static void DrawBox(string text, int left, int top, int width, int height)
    {
        Console.SetCursorPosition(left, top);
        Console.Write("┌" + new string('─', width - 2) + "┐");

        for (int i = 1; i < height - 1; i++)
        {
            Console.SetCursorPosition(left, top + i);
            Console.Write("│" + new string(' ', width - 2) + "│");
        }

        Console.SetCursorPosition(left, top + height - 1);
        Console.Write("└" + new string('─', width - 2) + "┘");

        int textLeft = left + (width - text.Length) / 2;
        int textTop = top + (height - 1) / 2;
        Console.SetCursorPosition(textLeft, textTop);
        Console.Write(text);
    }




    static int Priority(char op)
    {

        if (op == '+' || op == '-')
        {
            return 1;
        }
        else if (op == '*' || op == '/')
        {
            return 2;
        }
        else
        {
            return 0;
        }

    }

    static double GetResult(char op, double a, double b, string expression)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                    throw new DivideByZeroException("Division by zero");
                return a / b;
            default:
                throw new ArgumentException("Expression :" + expression + "\n" + "Invalid operator: " + op);
        }
    }

    static double Final_Result(string expression)
    {
        Stack<double> values = new();
        Stack<char> operators = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (char.IsWhiteSpace(c))
                continue;

            if (c == '(')
            {
                operators.Push(c);
            }
            else if (char.IsDigit(c) || (c == '.' && i + 1 < expression.Length && char.IsDigit(expression[i + 1])))
            {
                string number = c.ToString();
                while (i + 1 < expression.Length && (char.IsDigit(expression[i + 1]) || expression[i + 1] == '.'))
                {
                    i++;
                    number += expression[i];
                }
                values.Push(double.Parse(number));
            }
            else if (c == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    double b = values.Pop();
                    double a = values.Pop();
                    char op = operators.Pop();
                    values.Push(GetResult(op, a, b, expression));
                }
                operators.Pop(); // Pop the '('
            }
            else
            {
                while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(c))
                {
                    if (values.Count > 1)
                    {
                        double b = values.Pop();
                        double a = values.Pop();
                        char op = operators.Pop();
                        values.Push(GetResult(op, a, b, expression));
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid expression : {expression}");
                    }
                }
                operators.Push(c);
            }
        }
        while (operators.Count > 0 && values.Count > 0)
        {
            if (values.Count > 1)
            {
                double b = values.Pop();
                double a = values.Pop();
                char op = operators.Pop();
                values.Push(GetResult(op, a, b, expression));
            }
            else
            {
                throw new ArgumentException($"Invalid expression : {expression}");
            }
        }
        if (values.Count != 1 || operators.Count != 0)
            throw new ArgumentException("Invalid expression");


        return values.Pop();
    }

    static void Main(string[] args)
    {
        string text = "Sample inputs to Calulator app!";
        int boxWidth = text.Length + 4;
        int boxHeight = 4;

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        DrawBox(text, (Console.WindowWidth - boxWidth) / 2, (Console.WindowHeight - boxHeight) / 2, boxWidth, boxHeight);


        int count = 0;
        FileStream f1 = new FileStream("Expressions.txt", mode: FileMode.Open);
        StreamReader sw = new StreamReader(f1);
        string? MyExpression = sw.ReadLine();
        while (MyExpression != null)
        {
            try
            {
                
                Console.WriteLine("\n"+ ++count + ") : \n");
                object Result = Final_Result(MyExpression);
                Console.WriteLine($"Expression is  \" {MyExpression} \" \nResult is : {Result}");
                Console.WriteLine("-------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            MyExpression = sw.ReadLine();
        }
        Console.WriteLine("-------------------------------------");
    }
}