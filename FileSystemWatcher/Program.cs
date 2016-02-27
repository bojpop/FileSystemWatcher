using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileSystemWatcher;
using MailFunctionality;

namespace DirectoryMonitoring
{
    class Program
    {
        private static readonly DirectoryWatcher DirectoryWatcher = new DirectoryWatcher();

        public static void Main(string[] args)
        {
            
            const string watchedFolderPath = @"D:\Programming\Stepa\Parsing";

            var watcher = new System.IO.FileSystemWatcher
            {
                Path = watchedFolderPath,
                EnableRaisingEvents = true,
                Filter = "*.*"
            };

            watcher.Created += watcher_Created;

            while (true) ;
        }

        private static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            DirectoryWatcher.NewFileCreatedAt(e.FullPath);
        }
    }
}
