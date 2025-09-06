using Microsoft.EntityFrameworkCore;
using EnWord.DataAccess.Entities;

namespace EnWord.DataAccess
{
    public class WordDbContext : DbContext
    {
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {

        }
        public DbSet<WordEntity> Words { get; set; }
    }
}
