using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Services
{
    public class DuplicatedTransactionService : IDuplicatedTransactionService
    {
        private readonly IOfxTransactionRepository _transactionRepository;

        public DuplicatedTransactionService(IOfxTransactionRepository transactionRepository) =>
            _transactionRepository = transactionRepository;

        public async Task FindAndDefineDuplicatedTransactionAsync(IEnumerable<OfxTransaction> ofxTransactions)
        {
            foreach (var transaction in ofxTransactions)
            {
                var id = await _transactionRepository.GetTransactionIdAsync(transaction);
                transaction.DefineDuplicatedTransactionOf(id);
            }
        }
    }
}