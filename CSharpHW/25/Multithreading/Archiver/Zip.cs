using System;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace Archiver
{
    class Zip
    {
        public void Archive(string path)
        {
            var rootDir = new DirectoryInfo(path);
            DirectoryArchive(rootDir);
        }

        private void DirectoryArchive(object obj)
        {
            if (!(obj is DirectoryInfo rootDir)) return;

            foreach (var dir in rootDir.GetDirectories())
            {
                var thread = new Thread(DirectoryArchive);
                thread.Start(dir);
            }

            foreach (var file in rootDir.GetFiles())
            {
                var thread = new Thread(FileArchive);
                thread.Start(file);
            }
        }

        private void FileArchive(object obj)
        {
            try
            {
                if (!(obj is FileInfo file)) return;

                using (var archive = ZipFile.Open(file.FullName + ".zip", ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(file.FullName, Path.GetFileName(file.FullName));

                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + Path.GetFileName(file.FullName));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
