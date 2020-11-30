using DeveloperChallenge.Domain.Enums;
using System;

namespace DeveloperChallenge.Domain.Enities
{
    public class OfxTransaction : Entity
    {
        protected OfxTransaction()
        {
        }

        public OfxTransaction(
            DateTime? transactionDate,
            OfxEntryType? entryType,
            decimal? value,
            string description,
            Guid ofxFileId)
        {
            TransactionDate = transactionDate;
            EntryType = entryType;
            Value = value;
            Description = description;
            OfxFileId = ofxFileId;
        }

        public DateTime? TransactionDate { get; }
        public OfxEntryType? EntryType { get; }
        public decimal? Value { get; }
        public string Description { get; }
        public Guid? DuplicationOfTransactionId { get; protected set; }
        public Guid OfxFileId { get; }

        public bool ValidTransaction =>
            TransactionDate.HasValue &&
            EntryType.HasValue &&
            Value.HasValue;

        public void DefineDuplicatedTransactionOf(Guid? transactionId) => DuplicationOfTransactionId = transactionId;
    }
}