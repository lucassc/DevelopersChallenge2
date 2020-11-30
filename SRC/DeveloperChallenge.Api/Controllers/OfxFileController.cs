using DeveloperChallenge.Domain.Interfaces.Repositories;
using DeveloperChallenge.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeveloperChallenge.Api.Controllers
{
    [ApiController]
    [Route("v1/ofx-files")]
    public class OfxFileController : BaseController
    {
        private readonly IImportOfxFileService _importOfxFileService;
        private readonly IOfxFileRepository _ofxFileRepository;

        public OfxFileController(IImportOfxFileService importOfxFileService,
                                 IOfxFileRepository ofxFileRepository)
        {
            _importOfxFileService = importOfxFileService;
            _ofxFileRepository = ofxFileRepository;
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadOfxFile([FromForm] IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var ofxfile = await _importOfxFileService.ImportOfxFileAsync(stream);

            return Created($"{RequestUri}/v1/ofx-files/{ofxfile.Id}", ofxfile);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(Guid id)
        {
            var ofxFile = await _ofxFileRepository.GetAsync(id);
            return Ok(ofxFile);
        }
    }
}