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
            string num = ReadNumberLive();

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

        public char GetOperator()
        {
            Console.WriteLine("Select Operator (+, -, *, /, %)");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                char ch = key.KeyChar;

                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                {
                    Console.WriteLine(ch);
                    return ch;
                }

                Console.Beep();  // invalid input
            }

        }

        public void PerformOperation(double firstNum, char op, double nextNum, double result)
        {
            bool hasError = false;

            switch (op)
            {
                case '+':
                    result = firstNum + nextNum;
                    break;
                case '-':
                    result = firstNum - nextNum;
                    break;
                case '*':
                    result = firstNum * nextNum;
                    break;
                case '/':
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
                case '%':
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

        private void ClearAll(ConsoleKeyInfo keyPressed)
        {
            LineBreak();

            if (keyPressed.Key == ConsoleKey.Backspace)
            {
                double result = 0;
                Console.WriteLine("Enter First Number: ");
                double firstNum = GetInputNumber();

                char op = GetOperator();

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

                char op = GetOperator();

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


        private static string ReadNumberLive()
        {
            string input = "";

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input;
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b");
                    }
                    else
                    {
                        Console.Beep(); // nothing to delete
                    }
                    continue;
                }

                char ch = key.KeyChar;

                if (char.IsDigit(ch))
                {
                    input += ch;
                    Console.Write(ch);
                }
                else if (ch == '.' && !input.Contains('.'))
                {
                    input += ch;
                    Console.Write(ch);
                }
                else if (ch == '-' && input.Length == 0)
                {
                    input += ch;
                    Console.Write(ch);
                }
                else
                {
                    Console.Beep(); // invalid key
                }
            }
        }


        private void LineBreak()
        {
            Console.WriteLine("----------------------------------------------");
        }


    }
}
