using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static string Expression { get; set; } = null;
        public static string history { get; set; } = null;
        public static string Status {get;set;}=null;
        public static double a;


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
            Stack<double> values = new Stack<double>();
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







        public static void  Concat(string num)
        {
            if(Expression==null)
            {
                Expression = num;
                
            }
            else
            {
                Expression+= num;
            }

        }
        public Form1()
        {
            MessageBox.Show("Welcome Guys ", " Calulator ");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Concat("0");
            Box.Text = Expression;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Concat("1");
            Box.Text = Expression;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Concat("2");
            Box.Text = Expression;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Concat("3");
            Box.Text = Expression;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Concat("4");
            Box.Text = Expression;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Concat("5");
            Box.Text = Expression;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Concat("6");
            Box.Text = Expression;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Concat("7");
            Box.Text = Expression;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Concat("8");
            Box.Text = Expression;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Concat("9");
            Box.Text = Expression;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            try
            {
                 a = Final_Result(Expression);
            }
            catch(Exception ex)
            {
                Status = "Syntax Error";
                Box.Text = Status;
                return;
            }
            if (Expression!=null)
            {
                history = history+"    "+Expression + " = " + Convert.ToString(a) + "   ";
                Box.Text = Convert.ToString(a);
                textBox1.Text = history;
            }
            else
            {
                history = Expression + " = " + Convert.ToString(a) + "\n";
                textBox1.Text = history;
            }
        }

        private void Plus(object sender, EventArgs e)
        {
            Concat("+");
            Box.Text = Expression;
        }
        private void Minus(object sender, EventArgs e)
        {
            Concat("-");
            Box.Text = Expression;
        }
        private void Multiply(object sender, EventArgs e)
        {
            Concat("*");
            Box.Text = Expression;

        }
        private void Divide(object sender, EventArgs e)
        {
            Concat("/");
            Box.Text = Expression;
        }
        private void PopLast(object sender, EventArgs e)
        {
            if (Expression.Length>0)
            {

                Expression = Expression.Remove(Expression.Length - 1);
                Box.Text = Expression;
            }
        
        }
        private void ClearHistory(object sender, EventArgs e)
        {
            history = "";
           
            textBox1.Text = history;
        }
        private void Clear(object sender, EventArgs e)
        {
            Expression = "";
            Box.Text = Expression;
        }

        private void LeftBracket(object sender, EventArgs e)
        {
            Concat("(");
            Box.Text = Expression;
        }
        private void RightBracket(object sender, EventArgs e)
        {
            Concat(")");
            Box.Text = Expression;
        }

    }
}
