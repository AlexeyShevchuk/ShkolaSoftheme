using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Task
{
    class StrReplace
    {
        private readonly string _oldStr;
        private readonly string _newStr;
        private FilenameExtension[] _filenameExtensions;

        public StrReplace(string oldStr, string newStr)
        {
            _oldStr = oldStr;
            _newStr = newStr;
        }

        private IEnumerable<FileInfo> GetFilesByExtension(DirectoryInfo dir)
        {
            var filesRes = new FileInfo[0];

            foreach (var fExtension in _filenameExtensions)
            {
                var filesOneExtension = dir.GetFiles("*." + fExtension);
                var filesBuff = new FileInfo[filesRes.Length + filesOneExtension.Length];

                filesRes.CopyTo(filesBuff, 0);
                filesOneExtension.CopyTo(filesBuff, filesRes.Length);
                filesRes = filesBuff;
            }

            return filesRes;
        }

        private void RecursStrReplace(DirectoryInfo dir)
        {
            Parallel.ForEach(dir.GetDirectories(), RecursStrReplace);

            string str;
            var logFile = string.Empty;
            var files = GetFilesByExtension(dir);

            Parallel.ForEach(files, new ParallelOptions(), x =>
            {
                var strLine = string.Empty;

                using (var streamReader = File.OpenText(x.FullName))
                {
                    while ((str = streamReader.ReadLine()) != null)
                    {
                        if (str.Contains(_oldStr))
                        {
                            logFile += "File name: " + x.Name + " | " + "Old string: " + str;
                            str = str.Replace(_oldStr, _newStr);
                            logFile += " | " + "New string: " + str + "\n";
                        }

                        strLine += str + "\n";
                    }
                }

                File.WriteAllText(x.FullName, strLine);

                lock (this)
                {
                    File.AppendAllText("log.txt", logFile);
                }
            });
        }

        public void FileStrReplace(string path, params FilenameExtension[] filenameExtensions)
        {
            _filenameExtensions = filenameExtensions;
            var dirs = new DirectoryInfo(path);
            RecursStrReplace(dirs);
        }

        public void ShowLog()
        {
            Console.WriteLine("Log file");

            using (var streamReader = File.OpenText("log.txt"))
            {
                string str;

                while ((str = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
