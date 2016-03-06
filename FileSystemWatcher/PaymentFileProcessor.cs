using MailFunctionality;

namespace FileSystemWatcher
{
    internal class PaymentFileProcessor
    {
        public void ProcessFileFrom(string path)
        {
            Functions.Parsing(path);
            Functions.SendMail("Info mail", path);
            Functions.CopyFile(path);
        }
    }
}