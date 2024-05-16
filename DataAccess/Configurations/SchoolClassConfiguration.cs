using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.ToTable("SchoolClasses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ChildAge)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IsHomePage)
               .HasDefaultValue(false)
              .IsRequired();

            builder.Property(c => c.Time)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Capacity)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Price)
               .IsRequired()
               .HasPrecision(7, 2);

            builder.Property(c => c.PhotoUrl)
                .IsRequired()
                .HasMaxLength(250);

            // İlişkilendirme tanımı (Öğretmenler)
            //builder.HasMany(c => c.Teachers)
            //       .WithMany(t => t.SchoolClasses)
            //       .UsingEntity(j => j.ToTable("SchoolClassTeachers"));

        }
    }
}
