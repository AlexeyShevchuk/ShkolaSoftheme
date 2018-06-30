using System;
using System.Globalization;

namespace HM2Conslole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            var aInput = Console.ReadLine();

            Console.Write("operation: ");
            var operation = Console.ReadLine();

            Console.Write("b = ");
            var bInput = Console.ReadLine();

            if (aInput == string.Empty || bInput == string.Empty)
            {
                return;
            }

            if (!double.TryParse(aInput, out var a) || !double.TryParse(bInput, out var b))
            {
                return;
            }

            try
            {
                Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "{0:f}", Calculator(a, b, operation)));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        public static double Calculator(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+": a += b;
                    break;
                case "-": a -= b;
                    break;
                case "*": a *= b;
                    break;
                case "/": a /= b;
                    break;
                default:
                    throw new InvalidOperationException("Operation not supported");
            }

            return a;
        }
    }
}