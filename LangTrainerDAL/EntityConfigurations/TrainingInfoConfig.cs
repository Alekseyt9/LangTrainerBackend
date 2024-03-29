﻿
using LangTrainerEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangTrainerDAL.EntityConfigurations
{
    internal class TrainingInfoConfig : IEntityTypeConfiguration<TrainingInfo>
    {
        public void Configure(EntityTypeBuilder<TrainingInfo> builder)
        {
            builder.Property(x => x.Id);
            builder.HasKey(x => x.Id);

        }
    }
}
