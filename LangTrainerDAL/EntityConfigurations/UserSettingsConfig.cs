
using LangTrainerModel.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class UserSettingsConfig : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.Property(x => x.UserId);
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithMany().HasForeignKey(x => x.UserId);

            builder.Property(x => x.Data);
        }

    }
}
