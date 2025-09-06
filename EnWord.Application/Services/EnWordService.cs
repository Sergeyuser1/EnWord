using EnWord.Core.Models;
using EnWord.DataAccess.Repositories;

namespace EnWord.Application.Services
{
    public class EnWordService : IEnWordService
    {
        private readonly IWordRepository _wordsRepository;
        public EnWordService(IWordRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public async Task<List<Word>> GetAllWords()
        {
            return await _wordsRepository.Get();
        }

        public async Task<Guid> CreateWord(Word word)
        {
            return await _wordsRepository.Create(word.enWriting, word.transcription, word.ruWriting, word.freqRepeat);
        }

        public async Task<Guid> UpdateWord(Guid id, Word word)
        {
            return await _wordsRepository.Update(id, word);
        }

        public async Task<Guid> DeleteWord(Guid id)
        {
            return await _wordsRepository.Delete(id);
        }
    }
}
