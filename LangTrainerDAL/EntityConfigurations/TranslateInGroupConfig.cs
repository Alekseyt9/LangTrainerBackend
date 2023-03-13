
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

            builder.Property(x => x.GroupId).IsRequired();
            builder.Property(x => x.TrainingInfoId).IsRequired();
            builder.Property(x => x.TranslateId).IsRequired();
            builder.Property(x => x.AddTime).IsRequired();

            builder.HasOne(x => x.Translate)
                .WithMany().HasForeignKey(x => x.TranslateId);
            builder.HasOne(x => x.Group)
                .WithMany(x => x.Translates).HasForeignKey(x => x.GroupId);
            builder.HasOne(x => x.TrainingInfo)
                .WithMany().HasForeignKey(x => x.TrainingInfoId);
        }

    }
}
