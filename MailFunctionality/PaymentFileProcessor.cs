namespace MailFunctionality
{
    public class PaymentFileProcessor : IAmPaymentFileProcessor
    {
        private readonly IAmPaymentFileParser _fileParser;
        private readonly IAmMailSender _mailSender;
        private readonly IAmPaymentFileArchiver _fileArchiver;

        public PaymentFileProcessor(IAmMailSender mailSender, IAmPaymentFileParser fileParser, IAmPaymentFileArchiver fileArchiver)
        {
            _mailSender = mailSender;
            _fileParser = fileParser;
            _fileArchiver = fileArchiver;
        }

        public void ProcessFileFrom(string path)
        {
            var parsingResult = _fileParser.ParseFileFrom(path);
            _mailSender.SendMail("Info mail", path, parsingResult);
            _fileArchiver.CopyFile(path);
        }
    }
}