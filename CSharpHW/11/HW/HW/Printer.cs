using System;

namespace HW
{
    public class Printer
    {
        public virtual void Print(string str)
        {
            Console.WriteLine("Printer: " + str);
        }
    }
}