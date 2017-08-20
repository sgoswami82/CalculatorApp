using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************   Let's calculate something   ************");
            Console.WriteLine();
            consoleManager();
        }

        public static void consoleManager()
        {
            string input;
            string error = string.Empty;
            double output;
            Console.WriteLine("Please enter an expression (only numbers and operators):");
            input = Console.ReadLine();
            Calculator calc = new Calculator();
            output = calc.Calculate(input, ref error);
            if (error != string.Empty)
                Console.WriteLine(error);
            else
                Console.WriteLine("Result: " + output.ToString());

            Console.WriteLine("Press any key to continue or ESC to exit.");

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            else
                consoleManager();
        }
    }
}
