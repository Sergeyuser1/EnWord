using EnWord.Core.Models;
using EnWord.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace EnWord.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly WordDbContext _context;
        public WordRepository(WordDbContext context)
        {
            _context = context;

        }
        public async Task<List<Word>> Get()
        {
            var wordEntities = await _context.Words
                .AsNoTracking()
                .ToListAsync();
            var words = wordEntities
                .Select(w => new Word(w.enWriting, w.transcription, w.ruWriting, w.freqRepeat))
                .ToList();
            return words;
        }
        public async Task<Guid> Create(string enWriting, string transcription, string ruWriting, int freqRepeat)
        {
            var wordEntity = new WordEntity
            {
                Id = Guid.NewGuid(),
                enWriting = enWriting,
                transcription = transcription,
                ruWriting = ruWriting,
                freqRepeat = freqRepeat
            };
            await _context.Words.AddAsync(wordEntity);
            await _context.SaveChangesAsync();
            return wordEntity.Id;
        }
        public async Task<Guid> Update(Guid id, Word word)
        {
            await _context.Words.Where(w => w.Id == id)
                  .ExecuteUpdateAsync(w => w
                      .SetProperty(p => p.enWriting, word.enWriting)
                      .SetProperty(p => p.transcription, word.transcription)
                      .SetProperty(p => p.ruWriting, word.ruWriting)
                      .SetProperty(p => p.freqRepeat, word.freqRepeat));
            return word.Id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Words.Where(w => w.Id == id)
                 .ExecuteDeleteAsync();
            return id;
        }
    }
}
