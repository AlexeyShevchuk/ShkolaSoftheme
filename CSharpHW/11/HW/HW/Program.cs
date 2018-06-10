using System;

namespace HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            printer.Print("Some text");

            ColourPrinter colourPrinter = new ColourPrinter();
            colourPrinter.Print("Some text2 from colourPrinter");

            printer = colourPrinter;
            printer.Print("Some text2 from printer");

            //printer.Print("Some text3 from printer", ConsoleColor.Yellow);
            colourPrinter.Print("Some text3 from colourPrinter", ConsoleColor.Yellow);

            PhotoPrinter photoPrinter = new PhotoPrinter();
            photoPrinter.Print("Some text4 from photoPrinter");

            printer = photoPrinter;
            printer.Print("Some text4 from printer");

            photoPrinter.Print(Photo.Photo2);

            Console.ReadKey();
        }
    }
}