namespace MailFunctionality
{
    public interface IAmMailSender
    {
        void SendMail(string subject, string fullPath, ParsingResult parsingResult);
    }
}