
using LangTrainerModel.Entities.Lang;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class PartOfSpeechConfig : IEntityTypeConfiguration<PartOfSpeech>
    {
        public void Configure(EntityTypeBuilder<PartOfSpeech> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Language)
                .WithMany().HasForeignKey(x => x.LanguageId);

            builder
                .HasIndex(p => new { p.LanguageId, p.Name }).IsUnique();
        }

    }
}
