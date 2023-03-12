
using LangTrainerEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class SampleConfig : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.TranslateId).IsRequired();

            builder.HasOne(x => x.Translate)
                .WithMany(x => x.Samples).HasForeignKey(x => x.TranslateId);
        }

    }

}
