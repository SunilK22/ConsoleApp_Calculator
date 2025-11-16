using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmatic_Calculator
{
    internal class CalculatorMethods
    {
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
                CalculatorMethods cm = new CalculatorMethods();

                Console.WriteLine("Press [Backspace] to clear all result");
                Console.WriteLine("Press [Escape] to quit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                Console.WriteLine("Key Pressed: " + keyPressed.Key);

                cm.ClearAll(0, keyPressed);
                return 0;
            }
        }

        public string GetOperator()
        {
            Console.WriteLine("Select Operator (+, -, *, /, %)");
            string arthOperator = Console.ReadLine();

            if (arthOperator == "+" || arthOperator == "-" || arthOperator == "*" || arthOperator == "/" || arthOperator == "%")
            {
                return arthOperator;

            }
            else
            {
                Console.WriteLine("Invalid Operator Provided.");
                Console.WriteLine("Press [Backspace] to clear all result");
                Console.WriteLine("Press [Escape] to quit");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                Console.WriteLine("Key Pressed: " + keyPressed.Key);

                CalculatorMethods cm = new CalculatorMethods();

                cm.ClearAll(0, keyPressed);
                return "";
            }

        }

        public void PerformOperation(double firstNum, string arthOperator, double nextNum, double result)
        {
            CalculatorMethods cm = new CalculatorMethods();
            string exception1 = "";

            if (arthOperator == "+")
            {
                result = firstNum + nextNum;
            }
            else if (arthOperator == "-")
            {
                result = firstNum - nextNum;

            }
            else if (arthOperator == "*")
            {
                result = firstNum * nextNum;

            }
            else if (arthOperator == "/" && nextNum == 0)
            {
                exception1 = "Can not divide by 0";
                Console.WriteLine(exception1);

            }
            else if (arthOperator == "/")
            {
                result = firstNum / nextNum;

            }
            else if (arthOperator == "%")
            {
                result = firstNum % nextNum;

            }

            if (exception1 == "Can not divide by 0")
            {
                Console.WriteLine("Press [Backspace] to clear all result");
                Console.WriteLine("Press [Escape] to quit.");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                Console.WriteLine("Key Pressed: " + keyPressed.Key);

                cm.ClearAll(result, keyPressed);

            }
            else
            {
                Console.WriteLine("********* Calulated Result: " + result + " *********");

                Console.WriteLine("Press [Backspace] to clear all result");
                Console.WriteLine("Press [Tab] to continue");
                Console.WriteLine("Press [Escape] to quit.");

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                Console.WriteLine("Key Pressed: " + keyPressed.Key);

                cm.ClearAll(result, keyPressed);
                cm.ContinueOperation(firstNum, result, keyPressed);
            }

        }

        public void ClearAll(double result, ConsoleKeyInfo keyPressed)
        {
            CalculatorMethods cm = new CalculatorMethods();

            if (keyPressed.Key == ConsoleKey.Backspace)
            {
                result = 0;
                Console.WriteLine("Enter First Number: ");
                double firstNum = cm.GetInputNumber();

                string arthOperator = cm.GetOperator();

                Console.WriteLine("Enter Another Number: ");
                double nextNum = cm.GetInputNumber();

                cm.PerformOperation(firstNum, arthOperator, nextNum, result);
            }
            else if (keyPressed.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

            }

        }

        public void ContinueOperation(double firstNum, double result, ConsoleKeyInfo keyPressed)
        {

            if (keyPressed.Key == ConsoleKey.Tab)
            {
                firstNum = result;

                CalculatorMethods cm = new CalculatorMethods();
                string arthOperator = cm.GetOperator();

                Console.WriteLine("Enter Another Number: ");
                double anotherNum = cm.GetInputNumber();

                cm.PerformOperation(firstNum, arthOperator, anotherNum, result);
            }
            else if (keyPressed.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

            }

        }



    }
}
