using EnWord.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnWord.DataAccess.Repositories
{
    public interface IWordRepository
    {
        Task<Guid> Create(string enWriting, string transcription, string ruWriting, int freqRepeat);
        Task<List<Word>> Get();
        Task<Guid> Update(Guid id, Word word);
        Task<Guid> Delete(Guid id);

    }
}
