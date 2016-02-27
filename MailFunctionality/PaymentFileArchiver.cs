using System;
using System.IO;

namespace MailFunctionality
{
    public class PaymentFileArchiver: IAmPaymentFileArchiver
    {
        private string _destFile = "";
        
        public void CopyFile(string fileName)
        {
            try
            {
                var onlyFileName = System.IO.Path.GetFileName(fileName);
                var targetPath = @"D:\Programming\Stepa\Archive";

                var sourceFile = fileName;
                _destFile = System.IO.Path.Combine(targetPath, onlyFileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // !!!To copy one file to another location and 
                // overwrite the destination file if it already exists.
                if (!System.IO.File.Exists(_destFile))
                {
                    File.Copy(sourceFile, _destFile, true);
                    Console.WriteLine("File successfully copied to archive");
                }
                else
                {
                    Console.WriteLine("File already exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}