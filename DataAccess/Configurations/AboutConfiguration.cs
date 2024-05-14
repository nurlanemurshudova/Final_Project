﻿using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.DefaultValues;

namespace DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
                 .HasMaxLength(2000)
                 .IsRequired();
        }
    }
}
