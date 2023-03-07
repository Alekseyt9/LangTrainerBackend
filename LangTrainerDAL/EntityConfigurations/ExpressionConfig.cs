
using LangTrainerEntity.Entities;  
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class ExpressionConfig : IEntityTypeConfiguration<Expression>
    {
        public void Configure(EntityTypeBuilder<Expression> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).IsRequired();

            builder.HasOne<Language>(x => x.Language)
                .WithMany().HasForeignKey(x => x.LanguageId);
        }

    }
}
