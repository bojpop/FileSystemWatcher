using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace MailFunctionality
{
    public class Functions
    {
        private static string _destFile = "";
        public static string allText = "";
        public static string transactionNumber = "";
        public static int transactionNumCount = 0;

        public static void Parsing(string _fileName)
        {
            try
            {
                var reader = File.OpenText(_fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var charactersGroups = line.Split();

                    foreach (var characterGroup in charactersGroups)
                    {
                        if (ContainsTransactionNumber(characterGroup))
                        {
                            transactionNumber = GetTransactionNumberFrom(characterGroup);
                            transactionNumCount++;
                        }
                    }
                }
                Console.WriteLine("File parsed successfully");
            }
            catch (FileNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static bool ContainsTransactionNumber(string characterGroup)
        {
            return characterGroup.StartsWith("TN");
        }

        public static string GetTransactionNumberFrom(string item)
        {
            return item.Substring(3);
        }

        public static void SendMail(string subject, string fullPath)
        {
            try
            {
                var mailFrom = new MailAddress("poppfc@gmail.com");
                var mailTo = new MailAddress("bojanpopovic83@gmail.com");
                var newmsg = new MailMessage(mailFrom, mailTo)
                {
                    Subject = subject,
                    Body = "Transaction number: " + transactionNumber + ", number of repeating this transaction: " + transactionNumCount
                };

                //For File Attachment, more file can also be attached

                var att = new Attachment(fullPath);
                newmsg.Attachments.Add(att);

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("poppfc", "klovan321"),
                    EnableSsl = true
                };
                smtp.Send(newmsg);
                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CopyFile(string _fileName)
        {
            try
            {
                var onlyFileName = System.IO.Path.GetFileName(_fileName);
                var targetPath = @"D:\Programming\Stepa\Archive";

                var sourceFile = _fileName;
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
                    Console.WriteLine("File successfully copied");
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
