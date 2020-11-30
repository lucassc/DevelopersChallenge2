using DeveloperChallenge.Domain.Enities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Interfaces.Services
{
    public interface IDuplicatedTransactionService
    {
        Task FindAndDefineDuplicatedTransactionAsync(IEnumerable<OfxTransaction> ofxTransactions);
    }
}