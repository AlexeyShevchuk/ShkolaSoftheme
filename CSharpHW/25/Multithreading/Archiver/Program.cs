using System;

namespace Archiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var archiver = new Zip();

            archiver.Archive(@"..\..\..\testArchiver");

            Console.ReadLine();
        }
    }
}
