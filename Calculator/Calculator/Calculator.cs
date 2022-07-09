using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Calculator
    {
        public static double DoCalculation(double a, double b, string option)
        {
            double result = double.NaN;
            switch (option)
            {
                case "+":
                    result = a + b;
                    break;

                case "-":
                    result = a - b;
                    break;

                case "*":
                    result = a * b;
                    break;

                case "/":
                    if (b != 0)
                    {
                        result = a / b;
                    }
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}
