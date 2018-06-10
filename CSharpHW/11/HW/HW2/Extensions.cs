using System;
using HW;

namespace HW2
{
    static class Extensions
    {
        public static void Print(this Printer printer, string[] text)
        {
            foreach (var str in text)
            {
                printer.Print(str);
            }
        }

        public static void Print(this ColourPrinter colourPrinter, string[] text, ConsoleColor[] colors)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i > colors.Length - 1)
                {
                    colourPrinter.Print(text[i], colors[0]);
                }
                else
                {
                    colourPrinter.Print(text[i], colors[i]);
                }
            }
        }

        public static void Print(this PhotoPrinter photoPrinter, Photo[] photos)
        {
            foreach (var photo in photos)
            {
                photoPrinter.Print(photo);
            }
        }
    }
}