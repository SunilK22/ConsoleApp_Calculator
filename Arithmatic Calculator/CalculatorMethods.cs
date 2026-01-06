using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmatic_Calculator
{
    internal class CalculatorMethods
    {
        private const string DivideByZeroError = "Cannot divide by 0";

        public double GetInputNumber()
        {
            string num = Console.ReadLine();
            if (double.TryParse(num, out double value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Invalid Input: " + num);
                HandleKeyPress();

                return 0;
            }
        }

        public string GetOperator()
        {
            Console.WriteLine("Select Operator (+, -, *, /, %)");
            string op = Console.ReadLine();

            if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%")
            {
                return op;

            }
            else
            {
                Console.WriteLine("Invalid Operator Provided.");
                HandleKeyPress();
                return "";
            }

        }

        public void PerformOperation(double firstNum, string op, double nextNum, double result)
        {
            bool hasError = false;

            switch (op)
            {
                case "+":
                    result = firstNum + nextNum;
                    break;
                case "-":
                    result = firstNum - nextNum;
                    break;
                case "*":
                    result = firstNum * nextNum;
                    break;
                case "/":
                    if (nextNum == 0)
                    {
                        Console.WriteLine(DivideByZeroError);
                        hasError = true;
                    }
                    else
                    {
                        result = firstNum / nextNum;
                    }
                    break;
                case "%":
                    result = firstNum % nextNum;
                    break;
                default:
                    Console.WriteLine("Unknown operator.");
                    hasError = true;
                    break;
            }

            if (hasError)
            {
                HandleKeyPress();
                return;
            }

            Console.WriteLine("********* Calculated Result: " + result + " *********");
            Console.WriteLine("Press [Tab] to continue");
            ConsoleKeyInfo keyPressed = HandleKeyPress();
            ContinueOperation(firstNum, result, keyPressed);
        }

        private void ClearAll( ConsoleKeyInfo keyPressed)
        {
            LineBreak();

            if (keyPressed.Key == ConsoleKey.Backspace)
            {
                double result = 0;
                Console.WriteLine("Enter First Number: ");
                double firstNum = GetInputNumber();

                string op = GetOperator();

                Console.WriteLine("Enter Another Number: ");
                double nextNum = GetInputNumber();

                PerformOperation(firstNum, op, nextNum, result);
            }
            else if (keyPressed.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

            }

        }

        private void ContinueOperation(double firstNum, double result, ConsoleKeyInfo keyPressed)
        {
            LineBreak();

            if (keyPressed.Key == ConsoleKey.Tab)
            {
                firstNum = result;

                string op = GetOperator();

                Console.WriteLine("Enter Another Number: ");
                double nextNum = GetInputNumber();

                PerformOperation(firstNum, op, nextNum, result);
            }
            else if (keyPressed.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

            }

        }

        private ConsoleKeyInfo HandleKeyPress()
        {
            Console.WriteLine("Press [Backspace] to clear all result");
            Console.WriteLine("Press [Escape] to quit.");

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            Console.WriteLine("Key Pressed: " + keyPressed.Key);

            ClearAll(keyPressed);
            return keyPressed;
        }

        private void LineBreak()
        {
            Console.WriteLine("----------------------------------------------");
        }


    }
}
