using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperChallenge.Domain.OfxFileReaders
{
    public class OfxFileReader
    {
        private readonly IEnumerable<string> _lines;

        public OfxFileReader(IEnumerable<string> lines) => _lines = lines;

        public OfxFile GetOfxFile()
        {
            var language = GetValue(OfxTag.Languege);
            var trNuId = GetValue(OfxTag.TrNuId);
            var bankId = int.TryParse(GetValue(OfxTag.BankId), out var resultBankId)
                ? resultBankId
                : (int?)null;
            var intervalStart = OfxValuesParser.TryParse(GetValue(OfxTag.TransactionsIntervalStartDate), out DateTime resultIntervalStart)
                ? resultIntervalStart
                : (DateTime?)null;
            var intervalEnd = OfxValuesParser.TryParse(GetValue(OfxTag.TransactionsIntervalEndDate), out DateTime resultIntervalEnd)
                ? resultIntervalEnd
                : (DateTime?)null;
            var fileCreation = OfxValuesParser.TryParse(GetValue(OfxTag.FileGenerationDate), out DateTime resultFileCreation)
                ? resultFileCreation
                : (DateTime?)null;

            var ofxFile = new OfxFile(language, bankId, trNuId, intervalStart, intervalEnd, fileCreation);
            var transactions = GetTransactions(ofxFile.Id);
            ofxFile.DefineTransactions(transactions);

            return ofxFile;
        }

        private ICollection<OfxTransaction> GetTransactions(Guid ofxFileId)
        {
            var transactions = TagValueReader.SplitTransactions(_lines);

            return
                transactions
                    .Select(transactionLines => CreateOfxTransactionFrom(transactionLines, ofxFileId))
                    .ToList();
        }

        private OfxTransaction CreateOfxTransactionFrom(IEnumerable<string> transactionLines, Guid ofxFileId)
        {
            var transactionDate = OfxValuesParser.TryParse(GetValue(transactionLines, OfxTag.DepositDate), out DateTime resultTransactionDate)
                ? resultTransactionDate
                : (DateTime?)null;
            var entryType = OfxValuesParser.TryParse(GetValue(transactionLines, OfxTag.TransactionEntryType), out OfxEntryType resultEntryType)
                ? resultEntryType
                : (OfxEntryType?)null;
            var value = decimal.TryParse(GetValue(transactionLines, OfxTag.TransactionValue), out var resultValue)
                ? resultValue
                : (decimal?)null;
            var description = GetValue(transactionLines, OfxTag.TransactionDescription);

            return new OfxTransaction(transactionDate, entryType, value, description, ofxFileId);
        }

        private string GetValue(OfxTag ofxTag) => TagValueReader.GetValue(_lines, ofxTag);

        private string GetValue(IEnumerable<string> transactionLines, OfxTag ofxTag) => TagValueReader.GetValue(transactionLines, ofxTag);
    }
}