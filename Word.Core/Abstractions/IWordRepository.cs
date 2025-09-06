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
        Task<Guid> Create(Word word);
        Task<List<Word>> Get();
        Task<Guid> Update(Guid id, Word word);
        Task<Guid> Delete(Guid id);

    }
}
