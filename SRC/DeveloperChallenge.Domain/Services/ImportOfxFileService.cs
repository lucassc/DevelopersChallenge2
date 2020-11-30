using DeveloperChallenge.Domain.Enities;
using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Domain.Interfaces.Services;
using DeveloperChallenge.Domain.OfxFileReaders;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DeveloperChallenge.Domain.Services
{
    public class ImportOfxFileService : IImportOfxFileService
    {
        private readonly IDuplicatedTransactionService _duplicatedTransactionService;
        private readonly IOfxFileRepository _ofxFileRepository;

        public ImportOfxFileService(IDuplicatedTransactionService duplicatedTransactionService,
                                    IOfxFileRepository ofxFileRepository)
        {
            _duplicatedTransactionService = duplicatedTransactionService;
            _ofxFileRepository = ofxFileRepository;
        }

        public async Task<OfxFile> ImportOfxFileAsync(Stream stream)
        {
            var fileLines = GetFileLines(stream);

            var ofxFileReader = new OfxFileReader(fileLines);

            var ofxFile = ofxFileReader.GetOfxFile();

            await _duplicatedTransactionService.FindAndDefineDuplicatedTransactionAsync(ofxFile.Transactions);
            await _ofxFileRepository.AddAsync(ofxFile);

            return ofxFile;
        }

        private List<string> GetFileLines(Stream stream)
        {
            using var streamReader = new StreamReader(stream);
            var fileLines = new List<string>();
            while (!streamReader.EndOfStream)
            {
                fileLines.Add(streamReader.ReadLine().Trim());
            }

            return fileLines;
        }
    }
}