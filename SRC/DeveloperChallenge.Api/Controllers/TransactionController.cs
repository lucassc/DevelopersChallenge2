using DeveloperChallenge.Domain.Enums;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeveloperChallenge.Api.Controllers
{
    [ApiController]
    [Route("v1/ofx-transactions")]
    public class TransactionController : BaseController
    {
        private readonly IOfxTransactionRepository _ofxTransactionRepository;

        public TransactionController(IOfxTransactionRepository ofxTransactionRepository) => _ofxTransactionRepository = ofxTransactionRepository;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(Guid id) => Ok(await _ofxTransactionRepository.GetAsync(id));

        [HttpGet("valid-transactions")]
        public async Task<IActionResult> GetValidTransactions([FromQuery] DateTime? date, [FromQuery] OfxEntryType? entryType) =>
            Ok(await _ofxTransactionRepository.GetAsync(date, entryType));
    }
}