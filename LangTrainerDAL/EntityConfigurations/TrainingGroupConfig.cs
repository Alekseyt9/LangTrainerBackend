
using LangTrainerEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class TrainingGroupConfig : IEntityTypeConfiguration<TrainingGroup>
    {
        public void Configure(EntityTypeBuilder<TrainingGroup> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.TrainingGroups).HasForeignKey(x => x.UserId);
        }

    }
}
