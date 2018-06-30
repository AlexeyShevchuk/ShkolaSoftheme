using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Alex";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name);
            Console.ResetColor();;

            Console.ReadKey();
        }
    }
}
