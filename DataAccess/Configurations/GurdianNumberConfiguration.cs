using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GurdianNumberConfiguration : IEntityTypeConfiguration<GurdianNumber>
    {
        public void Configure(EntityTypeBuilder<GurdianNumber> builder)
        {
            builder.ToTable("GurdianNumbers");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Number)
                .IsUnique();

            builder.HasIndex(x => new { x.Number, x.Deleted })
                .IsUnique();

            builder.HasOne(x => x.Appointment)
                .WithMany(x => x.GurdianNumbers)
                .HasForeignKey(x => x.AppontmentId);
        }
    }
}
