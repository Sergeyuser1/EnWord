using EnWord.Core.Models;

namespace EnWord.Application.Services
{
    public interface IEnWordService
    {
        Task<Guid> CreateWord(Word word);
        Task<Guid> DeleteWord(Guid id);
        Task<List<Word>> GetAllWords();
        Task<Guid> UpdateWord(Guid id, Word word);
    }
}