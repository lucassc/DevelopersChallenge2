using DeveloperChallenge.Domain.Enums;
using System;

namespace DeveloperChallenge.Domain.Constants
{
    public static class OfxTagDescriptions
    {
        private const string FileGenerationDate = "DTSERVER";
        private const string TrNuId = "TRNUID";
        private const string Languege = "LANGUAGE";
        private const string BankId = "BANKID";
        private const string TransactionsIntervalStartDate = "DTSTART";
        private const string TransactionsIntervalEndDate = "DTEND";
        private const string TransactionDelimiter = "STMTTRN";
        private const string DepositDate = "DTPOSTED";
        private const string TransactionValue = "TRNAMT";
        private const string TransactionDescription = "MEMO";
        private const string TransactionEntryType = "TRNTYPE";

        public static string GetOpenTag(OfxTag ofxTag) => $"<{GetTag(ofxTag)}>";

        public static string GetCloseTag(OfxTag ofxTag) => $"</{GetTag(ofxTag)}>";

        private static string GetTag(OfxTag ofxTag) =>
            (ofxTag) switch
            {
                OfxTag.FileGenerationDate => FileGenerationDate,
                OfxTag.TrNuId => TrNuId,
                OfxTag.Languege => Languege,
                OfxTag.BankId => BankId,
                OfxTag.TransactionsIntervalStartDate => TransactionsIntervalStartDate,
                OfxTag.TransactionsIntervalEndDate => TransactionsIntervalEndDate,
                OfxTag.TransactionDelimiter => TransactionDelimiter,
                OfxTag.DepositDate => DepositDate,
                OfxTag.TransactionValue => TransactionValue,
                OfxTag.TransactionDescription => TransactionDescription,
                OfxTag.TransactionEntryType => TransactionEntryType,
                _ => throw new NotImplementedException(),
            };
    }
}