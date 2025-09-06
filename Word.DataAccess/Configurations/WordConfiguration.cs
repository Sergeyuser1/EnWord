using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnWord.DataAccess.Entities;

namespace EnWord.DataAccess.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<WordEntity>
    {
        public void Configure(EntityTypeBuilder<WordEntity> builder)
        {
          builder.HasKey(x=> x.Id);

            builder.Property(b => b.enWriting).IsRequired();
            builder.Property(b => b.transcription).IsRequired();
            builder.Property(b => b.ruWriting).IsRequired();
            builder.Property(b => b.freqRepeat).IsRequired();

        }
    }
}
