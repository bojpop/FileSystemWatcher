using System;
using System.IO;

namespace MailFunctionality
{
    public class PaymentFileParser : IAmPaymentFileParser
    {
        private string _transactionNumber = "";
        private int _transactionNumCount = 0;

        public ParsingResult ParseFileFrom(string path)
        {
            var parsingResult = new ParsingResult();

            try
            {
                var reader = File.OpenText(path);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var charactersGroups = line.Split();

                    foreach (var characterGroup in charactersGroups)
                    {
                        if (ContainsTransactionNumber(characterGroup))
                        {
                            _transactionNumber = GetTransactionNumberFrom(characterGroup);
                            _transactionNumCount++;
                        }
                    }
                }
                parsingResult.TransactionNumber = _transactionNumber;
                parsingResult.NumberOfTransactions = _transactionNumCount;
                Console.WriteLine("File parsed successfully");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return parsingResult;

        }
        private bool ContainsTransactionNumber(string characterGroup)
        {
            return characterGroup.StartsWith("TN");
        }

        private string GetTransactionNumberFrom(string item)
        {
            return item.Substring(3);
        }
    }
}