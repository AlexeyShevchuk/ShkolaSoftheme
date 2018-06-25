using System;

namespace Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var zipExtractor = new ZipExtractor();

            zipExtractor.Expract(@"..\..\..\testExtractor");

            Console.ReadLine();
        }
    }
}
