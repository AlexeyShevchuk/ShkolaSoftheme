using System;

namespace HW
{
    public class ColourPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.WriteLine("ColourPrinter override: " + str);
        }

        public void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("ColourPrinter: " + text);
            Console.ResetColor();
        }
    }
}