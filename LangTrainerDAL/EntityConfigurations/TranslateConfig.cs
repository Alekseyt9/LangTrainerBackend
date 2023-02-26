﻿
using LangTrainerEntity.Entities.Lang;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{

    internal class TranslateConfig : IEntityTypeConfiguration<Translate>
    {
        public void Configure(EntityTypeBuilder<Translate> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Data).IsRequired();
        }

    }

}