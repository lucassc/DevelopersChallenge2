using DeveloperChallenge.Domain.Enities;
using System;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Interfaces.Repositories
{
    public interface IOfxFileRepository
    {
        Task AddAsync(OfxFile ofxFile);

        Task<OfxFile> GetAsync(Guid id);
    }
}