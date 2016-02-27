using System;
using System.Net;
using System.Net.Mail;

namespace MailFunctionality
{
    public class GmailSender: IAmMailSender
    {
        public void SendMail(string subject, string fullPath, ParsingResult parsingResult)
        {
            try
            {
                var mailFrom = new MailAddress("poppfc@gmail.com");
                var mailTo = new MailAddress("bojanpopovic83@gmail.com");
                var newmsg = new MailMessage(mailFrom, mailTo)
                {
                    Subject = subject,
                    Body = "Transaction number: " + parsingResult.TransactionNumber + ", number of repeating this transaction: " + parsingResult.NumberOfTransactions
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
    }
}