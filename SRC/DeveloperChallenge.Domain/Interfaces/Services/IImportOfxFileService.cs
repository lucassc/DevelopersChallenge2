using DeveloperChallenge.Domain.Enities;
using System.IO;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Interfaces.Services
{
    public interface IImportOfxFileService
    {
        Task<OfxFile> ImportOfxFileAsync(Stream stream);
    }
}