using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Interfaces.Repositories
{
    public interface IOfxTransactionRepository
    {
        Task<Guid?> GetTransactionIdAsync(OfxTransaction ofxTransaction);

        Task<IEnumerable<OfxTransaction>> GetAsync(DateTime? date, OfxEntryType? entryType);

        Task<OfxTransaction> GetAsync(Guid id);
    }
}