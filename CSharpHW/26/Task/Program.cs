using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var strReplace = new StrReplace("Some text", "Hello word!");

            strReplace.FileStrReplace(@"..\..\test", FilenameExtension.Txt, FilenameExtension.Dat, FilenameExtension.Cfg);

            strReplace.ShowLog();

            Console.ReadKey();
        }
    }
}
