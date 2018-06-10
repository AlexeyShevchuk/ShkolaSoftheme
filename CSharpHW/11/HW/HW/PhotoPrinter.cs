using System;

namespace HW
{
    public class PhotoPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.WriteLine("PhotoPrinter override: " + str);
        }

        public void Print(Photo photo)
        {
            Console.WriteLine("PhotoPrinter photo: " + photo.ToString());
        }

    }
}