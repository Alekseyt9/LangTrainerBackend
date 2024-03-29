﻿
using LangTrainerEntity.Entities;
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

            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.PartOfSpeechId).IsRequired();
            builder.Property(x => x.LanguageId).IsRequired();

            builder.HasOne(x => x.Language)
                .WithMany().HasForeignKey(x => x.LanguageId);
            builder.HasOne(x => x.Expression)
                .WithMany(x => x.Translates).HasForeignKey(x => x.ExpressionId);
            builder.HasOne(x => x.PartOfSpeech)
                .WithMany().HasForeignKey(x => x.PartOfSpeechId);
        }

    }

}
