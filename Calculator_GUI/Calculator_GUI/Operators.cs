using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_GUI
{
    internal class Operators
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }
    }
}
