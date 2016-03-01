using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailFunctionality;

namespace FileSystemWatcher
{
    public class DirectoryWatcher : IAmDirectoryWatcher
    {
        private readonly IAmPaymentFileProcessor _paymentFileProcessor;

        public DirectoryWatcher(IAmPaymentFileProcessor paymentFileProcessor)
        {
            _paymentFileProcessor = paymentFileProcessor;
        }

        /*private readonly PaymentFileProcessor _paymentFileProcessor = new PaymentFileProcessor(
                                                                            new GmailSender(), 
                                                                            new PaymentFileParser(), 
                                                                            new PaymentFileArchiver());*/

        public void NewFileCreatedAt(string path)
        {
            Console.WriteLine("File : " + path + " is created.");
            _paymentFileProcessor.ProcessFileFrom(path);
        }
    }
}
