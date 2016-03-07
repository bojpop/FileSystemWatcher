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
        /*private static IAmDirectoryWatcher _directoryWatcher;

        private Program(IAmDirectoryWatcher directoryWatcher)
        {
            _directoryWatcher = directoryWatcher;
        }*/
        public static readonly DirectoryWatcher _directoryWatcher = new DirectoryWatcher(new PaymentFileProcessor(new GmailSender(),
                                                                                                                  new PaymentFileParser(),
                                                                                                                  new PaymentFileArchiver()));

        public static void Main(string[] args)
        {
            
            const string watchedFolderPath = @"D:\Programming\Stepa\Parsing";

            var watcher = new System.IO.FileSystemWatcher
            {
                Path = watchedFolderPath,
                EnableRaisingEvents = true,
                Filter = "*.*"
            };
            //Program program = new Program(_directoryWatcher);
            watcher.Created += watcher_Created;

            while (true) ;
        }

        public static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            _directoryWatcher.NewFileCreatedAt(e.FullPath);
        }
    }
}
