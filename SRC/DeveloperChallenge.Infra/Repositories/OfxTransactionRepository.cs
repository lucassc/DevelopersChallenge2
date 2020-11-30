using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Enums;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperChallenge.Infra.Repositories
{
    public class OfxTransactionRepository : IOfxTransactionRepository
    {
        private readonly DbSet<OfxTransaction> _dbSet;

        public OfxTransactionRepository(SqlContext context) => _dbSet = context.Set<OfxTransaction>();

        public async Task<Guid?> GetTransactionIdAsync(OfxTransaction ofxTransaction)
        {
            var transaction =
                await _dbSet
                    .Where(t => t.TransactionDate == ofxTransaction.TransactionDate &&
                                t.Value == ofxTransaction.Value &&
                                t.Description == ofxTransaction.Description &&
                                t.EntryType == ofxTransaction.EntryType)
                    .FirstOrDefaultAsync();

            return transaction?.Id;
        }

        public async Task<IEnumerable<OfxTransaction>> GetAsync(DateTime? date, OfxEntryType? entryType)
        {
            return
                await _dbSet
                    .Where(t => t.DuplicationOfTransactionId == null &&
                                t.TransactionDate != null &&
                                (!date.HasValue || t.TransactionDate.Value.Date == date.Value.Date) &&
                                (!entryType.HasValue || t.EntryType.Value == entryType.Value))
                    .ToListAsync();
        }

        public async Task<OfxTransaction> GetAsync(Guid id)
        {
            return
                await _dbSet
                    .Where(t => t.Id == id)
                    .FirstOrDefaultAsync();
        }
    }
}