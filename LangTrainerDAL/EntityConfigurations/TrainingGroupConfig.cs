
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

            builder.HasOne(x => x.User)
                .WithMany().HasForeignKey(x => x.UserId);
        }

    }
}
