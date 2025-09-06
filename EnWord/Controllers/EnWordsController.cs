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

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWordService([FromBody] WordsRequest request)
        {
            if (string.IsNullOrEmpty(request.enWriting) || string.IsNullOrEmpty(request.transcription)
            || string.IsNullOrEmpty(request.ruWriting)) 
            { 
                Results.StatusCode(500);
                return BadRequest();
            }

            var word = new Word(
                request.enWriting,
                request.transcription,
                request.ruWriting,
                request.freqRepeat);

            var wordId = await _enWordService.CreateWord(word);
            return Ok(wordId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWordController(Guid id, [FromBody] WordsRequest request)
        {
            var bookId = await _enWordService.UpdateWord(id, new Word(request.enWriting, request.transcription, request.ruWriting, request.freqRepeat));
            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteWordController(Guid id)
        {
            var boolId = await _enWordService.DeleteWord(id);
            return Ok(boolId);
        }
    }
}
