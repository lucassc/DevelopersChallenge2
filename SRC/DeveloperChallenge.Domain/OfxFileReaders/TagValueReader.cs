using DeveloperChallenge.Domain.Constants;
using DeveloperChallenge.Domain.Enums;
using System.Collections.Generic;

namespace DeveloperChallenge.Domain.OfxFileReaders
{
    public static class TagValueReader
    {
        public static string GetValue(IEnumerable<string> lines, OfxTag ofxTag)
        {
            var startTag = OfxTagDescriptions.GetOpenTag(ofxTag);
            var endTag = OfxTagDescriptions.GetCloseTag(ofxTag);

            foreach (var line in lines)
            {
                if (line.Contains(startTag))
                {
                    var value = line.Remove(0, startTag.Length);
                    if (value.Contains(endTag))
                    {
                        value = value.Remove(value.IndexOf(endTag), endTag.Length);
                    }

                    return value;
                }
            }

            return null;
        }

        public static IEnumerable<IEnumerable<string>> SplitTransactions(IEnumerable<string> fileLines)
        {
            var transactionTagOpen = OfxTagDescriptions.GetOpenTag(OfxTag.TransactionDelimiter);
            var transactionTagClose = OfxTagDescriptions.GetCloseTag(OfxTag.TransactionDelimiter);
            var transactions = new List<List<string>>();

            var isTransactionSection = false;
            List<string> transactionLines = null;
            foreach (var line in fileLines)
            {
                if (line.Contains(transactionTagOpen))
                {
                    isTransactionSection = true;
                }

                if (line.Contains(transactionTagClose))
                {
                    isTransactionSection = false;
                }

                if (isTransactionSection)
                {
                    if (transactionLines is null)
                    {
                        transactionLines = new List<string>();
                        transactions.Add(transactionLines);
                    }
                    transactionLines.Add(line);
                }
                else
                {
                    if (transactionLines != null)
                    {
                        transactionLines.RemoveFirstTag();
                        transactionLines = null;
                    }
                }
            }

            return transactions;
        }

        private static void RemoveFirstTag(this List<string> lines) => lines.RemoveAt(0);
    }
}