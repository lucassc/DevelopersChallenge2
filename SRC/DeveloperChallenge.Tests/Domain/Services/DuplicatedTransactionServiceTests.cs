using AutoFixture;
using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeveloperChallenge.Tests.Domain.Services
{
    public class DuplicatedTransactionServiceTests
    {
        private readonly Fixture _fixture;
        private readonly Mock<IOfxTransactionRepository> _ofxTransactionRepository;
        private readonly DuplicatedTransactionService _service;

        public DuplicatedTransactionServiceTests()
        {
            _fixture = new Fixture();
            _ofxTransactionRepository = new Mock<IOfxTransactionRepository>(MockBehavior.Strict);

            _service = new DuplicatedTransactionService(_ofxTransactionRepository.Object);
        }

        [Fact(DisplayName = "When transaction duplicated should define id on Transaction")]
        public async Task WhenTransactionDuplicated_ShouldDefineIdOnTransaction()
        {
            var transactions = _fixture.CreateMany<OfxTransaction>(count: 1);
            var idReturned = _fixture.Create<Guid>();
            _ofxTransactionRepository
                .Setup(s => s.GetTransactionIdAsync(transactions.First()))
                .ReturnsAsync(idReturned);

            await _service.FindAndDefineDuplicatedTransactionAsync(transactions);

            transactions.First().DuplicationOfTransactionId.Should().Be(idReturned);
            _ofxTransactionRepository.VerifyAll();
        }

        [Fact(DisplayName = "Should validate all transactions")]
        public async Task ShouldValidateAllTransaction()
        {
            var transactions = _fixture.CreateMany<OfxTransaction>(count: 3);
            _ofxTransactionRepository
                .Setup(s => s.GetTransactionIdAsync(It.IsAny<OfxTransaction>()))
                .ReturnsAsync(() => _fixture.Create<Guid>());

            await _service.FindAndDefineDuplicatedTransactionAsync(transactions);

            _ofxTransactionRepository
                .Verify(s => s.GetTransactionIdAsync(It.IsAny<OfxTransaction>()), Times.Exactly(transactions.Count()));
        }
    }
}