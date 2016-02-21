using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MailFunctionality;

namespace DirectoryMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Programming\Stepa\Parsing";

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = path;
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.*";

            watcher.Created += watcher_Created;

            while (true) ;
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : " + e.FullPath + " is created.");
            Functions.Parsing(e.FullPath);
            Functions.SendMail("Info mail", e.FullPath);
            Functions.CopyFile(e.FullPath);
        }
    }
}
