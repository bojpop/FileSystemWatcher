namespace MailFunctionality
{
    public interface IAmPaymentFileParser
    {
        ParsingResult ParseFileFrom(string path);
    }
}