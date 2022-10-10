using System;
using System.Text;
using System.Threading;
using System.Globalization;

namespace ATM
{
    public static class Utility
    {
        private static CultureInfo culture = new CultureInfo("en-AU");
        // "vi-Vn" did not work, had to switch currency to AUD

        public static string GetRawInput(string message) 
        {
            // return user's input to validation methods

            Console.Write($"Enter {message}: ");
            return Console.ReadLine();
        }

        public static string GetHiddenConsoleInput() 
        {
            // get hidden PIN input when logging in

            StringBuilder input = new StringBuilder();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    input.Append(key.KeyChar);
                }
            }
            return input.ToString();
        }

        public static decimal GetValidDecimalInput(string input)
        {
            // get user's input type until valid

            bool valid = false;
            string rawInput;
            decimal amount = 0;

            while (!valid)
            {
                rawInput = GetRawInput(input);
                valid = decimal.TryParse(rawInput, out amount);
                if (!valid)
                {
                    PrintMessage("Invalid input. Try again.", false);
                }
            }
            return amount;
        }

        public static Int64 GetValidIntInput(string input)
        {
            // get user's input type until valid

            bool valid = false;
            string rawInput;
            Int64 amount = 0;

            while (!valid)
            {
                rawInput = GetRawInput(input);
                valid = Int64.TryParse(rawInput, out amount);
                if (!valid)
                {
                    PrintMessage("Invalid input. Try again.", false);
                }
            }
            return amount;
        }

        public static void printDotAnimation(int timer = 10)
        {
            for (var x = 0; x < timer; x++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        public static string FormatAmount(decimal amount) 
        {
            // better money format at display

            return String.Format(culture, "{0:C2}", amount);
        }

        public static void PrintMessage(string msg, bool success)
        {
            // print colored messages, green for success and red for error

            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
