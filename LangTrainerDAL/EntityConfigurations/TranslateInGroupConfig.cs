
using LangTrainerEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class TranslateInGroupConfig : IEntityTypeConfiguration<TranslateInGroup>
    {
        public void Configure(EntityTypeBuilder<TranslateInGroup> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Translate)
                .WithMany().HasForeignKey(x => x.TranslateId);
            builder.HasOne(x => x.Group)
                .WithMany().HasForeignKey(x => x.GroupId);
            builder.HasOne(x => x.TrainingInfo)
                .WithMany().HasForeignKey(x => x.TrainingInfoId);
        }

    }
}
