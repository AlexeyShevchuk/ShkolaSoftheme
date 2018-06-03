using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM2Console
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

            if (!double.TryParse(aInput, out double a) || !double.TryParse(bInput, out double b))
            {
                return;
            }

            Console.WriteLine(string.Format("{0:f}", Calculator(a, b, operation)));
            Console.ReadKey();
        }
        public static double Calculator(double a, double b, string operation)
        {
            switch (operation)
            {
                case "+": a += b; break;
                case "-": a -= b; break;
                case "*": a *= b; break;
                case "/":
                    if (b == 0)
                    {
                        return 0;
                    }
                    a /= b;
                    break;
                default: return 0;
            }
            return a;
        }
    }
}