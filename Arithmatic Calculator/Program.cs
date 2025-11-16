using Arithmatic_Calculator;

class calculatorMain: CalculatorMethods
{
    static double result;
    public static void Main(string[] args)
    {
        CalculatorMethods cm = new CalculatorMethods();

        Console.WriteLine("Enter First Number: ");
        double firstNum = cm.GetInputNumber();

        string arthOperator = cm.GetOperator();

        Console.WriteLine("Enter Another Number: ");
        double nextNum = cm.GetInputNumber();

        cm.PerformOperation(firstNum, arthOperator, nextNum, result);

    }
}
