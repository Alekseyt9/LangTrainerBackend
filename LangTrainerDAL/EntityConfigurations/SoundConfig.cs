
using LangTrainerEntity.Entities.Lang;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LangTrainerDAL.EntityConfigurations
{

    internal class SoundConfig : IEntityTypeConfiguration<Sound>
    {
        public void Configure(EntityTypeBuilder<Sound> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data).IsRequired();
        }

    }

}
