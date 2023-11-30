using System;
using System.Collections.Generic;

// Context
class Context
{
    public Dictionary<string, int> Variables { get; private set; }

    public Context()
    {
        Variables = new Dictionary<string, int>();
    }

    public int GetVariableValue(string variableName)
    {
        if (Variables.TryGetValue(variableName, out int value))
        {
            return value;
        }
        throw new ArgumentException($"Variable {variableName} not found.");
    }

    public void SetVariableValue(string variableName, int value)
    {
        if (Variables.ContainsKey(variableName))
        {
            Variables[variableName] = value;
        }
        else
        {
            Variables.Add(variableName, value);
        }
    }
}

// Abstract Expression
interface IExpression
{
    int Interpret(Context context);
}

// Terminal Expression
class NumberExpression : IExpression
{
    private readonly int value;

    public NumberExpression(int value)
    {
        this.value = value;
    }

    public int Interpret(Context context)
    {
        return value;
    }
}

// Non-terminal Expression (Addition)
class AddExpression : IExpression
{
    private readonly IExpression left;
    private readonly IExpression right;

    public AddExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret(Context context)
    {
        return left.Interpret(context) + right.Interpret(context);
    }
}

// Second Example: Expression Parser

// Expression Parser
class ExpressionParser
{
    private readonly Context context;

    public ExpressionParser(Context context)
    {
        this.context = context;
    }

    public IExpression ParseExpression(string expression)
    {
        // For simplicity, let's assume the input expression is in a specific format (e.g., "5 + (2 + 3)")
        // In a real-world scenario, this would involve a more complex parsing logic

        IExpression expr = null;

        // Create the expression tree based on the parsed input expression
        expr = new AddExpression(
            new NumberExpression(5),
            new AddExpression(new NumberExpression(2), new NumberExpression(3))
        );

        return expr;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Interpreter Pattern Example 1: Simple Arithmetic Expression Interpreter");

        // Creating an expression: 5 + (2 + 3)
        IExpression expression1 = new AddExpression(
            new NumberExpression(5),
            new AddExpression(new NumberExpression(2), new NumberExpression(3))
        );

        Context context = new Context();
        int result1 = expression1.Interpret(context);
        Console.WriteLine("Result: " + result1);

        Console.WriteLine("\nInterpreter Pattern Example 2: Expression Parser");

        // Expression Parser example
        Context context2 = new Context();
        ExpressionParser parser = new ExpressionParser(context2);
        string inputExpression = "5 + (2 + 3)";
        IExpression parsedExpression = parser.ParseExpression(inputExpression);
        int result2 = parsedExpression.Interpret(context2);
        Console.WriteLine("Parsed Expression Result: " + result2);
    }
}
