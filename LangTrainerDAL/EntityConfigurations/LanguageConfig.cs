
using LangTrainerEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique(true);
        }

    }

}
