using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("------------------------------COMMAND-LINE CALCULATOR------------------------------");
            Console.WriteLine("This calculator will help you add, subtract, multiple, or divide between 2 numbers.");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            while (!endApp)
            {
                string input_a, input_b; 
                double result;

                Console.Write("\nEnter a: ");
                input_a = Console.ReadLine();

                double a_valid = 0;
                while (!double.TryParse(input_a, out a_valid))
                {
                    Console.Write("That is not a valid input. Please enter a number: ");
                    input_a = Console.ReadLine();
                }

                Console.Write("Enter b: ");
                input_b = Console.ReadLine();

                double b_valid = 0;
                while (!double.TryParse(input_b, out b_valid))
                {
                    Console.Write("That is not a valid input. Please enter a number: ");
                    input_b = Console.ReadLine();
                }

                Console.WriteLine("\nWhat would you like to do with the 2 numbers?");
                Console.WriteLine("\t+: Add");
                Console.WriteLine("\t-: Subtract");
                Console.WriteLine("\t*: Multiply");
                Console.WriteLine("\t/: Divide\n");
                Console.Write("Your option: ");
                string option = Console.ReadLine();
                
                try
                {
                    result = Calculator.DoCalculation(a_valid, b_valid, option);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Math ERROR");
                    }
                    else
                    {
                        Console.WriteLine($"The result to the equation is: {result}", result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exeception has occured in the process.\nView details: " + ex);
                }

                Console.Write("Press 'q' to quit the app, or press any other key to continue: ");
                if (Console.ReadLine() == "q")
                {
                    endApp = true;
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.WriteLine("Thank you for using the app!\nPress any key to close this console...");
                    Console.ReadKey();
                }
            }
            return;
        }
    }
}
