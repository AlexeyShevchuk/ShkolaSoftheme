using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Extractor
{
    class ZipExtractor
    {
        public void Expract(string path)
        {
            var rootDir = new DirectoryInfo(path);
            DirectoryExpract(rootDir);
        }

        private void DirectoryExpract(object obj)
        {
            if (!(obj is DirectoryInfo rootDir)) return;

            foreach (var dir in rootDir.GetDirectories())
            {
                var thread = new Thread(DirectoryExpract);
                thread.Start(dir);
            }

            foreach (var zipArchive in rootDir.GetFiles())
            {
                var thread = new Thread(FileExpract);
                thread.Start(zipArchive);
            }
        }

        private void FileExpract(object obj)
        {
            try
            {
                if (!(obj is FileInfo file)) return;

                using (var archive = ZipFile.OpenRead(file.FullName))
                {
                    foreach (var entry in archive.Entries)
                    {
                        entry.ExtractToFile(file.DirectoryName + "\\" + entry.FullName);

                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + entry.FullName);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}