using EnWord.Application.Services;
using EnWord.Contracts;
using EnWord.Core.Models;
using EnWord.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EnWord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnWordsController : ControllerBase
    {
        private readonly IEnWordService _enWordService;
        public EnWordsController(IEnWordService enWordService)
        {
            _enWordService = enWordService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WordsResponse>>> GetWords()
        {
            var words = await _enWordService.GetAllWords();

            var response = words.Select(w => new WordsResponse(w.Id, w.enWriting, w.transcription, w.ruWriting, w.freqRepeat));
            return Ok(response);
        }
    }
}
