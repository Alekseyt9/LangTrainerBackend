
using LangTrainerEntity.Entities;
using LangTrainerModel.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique(true);

            builder.Property(x => x.Login).IsRequired();
            builder.HasIndex(x => x.Login).IsUnique(true);

            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PassSalt).IsRequired();

            /*
            builder.HasOne<UserSettings>(x => x.Settings)
                .WithMany().HasForeignKey(x => x.SettingsId);
            */
        }

    }
}
