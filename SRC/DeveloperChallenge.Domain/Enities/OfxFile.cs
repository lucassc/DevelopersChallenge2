using System;
using System.Collections.Generic;

namespace DeveloperChallenge.Domain.Enities
{
    public class OfxFile : Entity
    {
        protected OfxFile()
        {
        }

        public OfxFile(
            string language,
            int? bankId,
            string trNuId,
            DateTime? intervalStart,
            DateTime? intervalEnd,
            DateTime? fileCreation)
        {
            Language = language;
            BankId = bankId;
            TrNuId = trNuId;
            IntervalStart = intervalStart;
            IntervalEnd = intervalEnd;
            FileCreation = fileCreation;
        }

        public string Language { get; }
        public int? BankId { get; }
        public string TrNuId { get; }
        public DateTime? IntervalStart { get; }
        public DateTime? IntervalEnd { get; }
        public DateTime? FileCreation { get; }
        public ICollection<OfxTransaction> Transactions { get; protected set; }

        public void DefineTransactions(ICollection<OfxTransaction> transactions)
        {
            Transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
        }
    }
}