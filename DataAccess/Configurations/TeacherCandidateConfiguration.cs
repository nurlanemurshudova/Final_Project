using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeacherCandidateConfiguration : IEntityTypeConfiguration<TeacherCandidate>
    {
        public void Configure(EntityTypeBuilder<TeacherCandidate> builder)
        {
            builder.ToTable("TeacherCandidates");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Education)
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Experience)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.IsContacted)
                .HasDefaultValue(0);

            builder.Property(x => x.BirthDate)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => new { x.Email, x.Deleted })
                .IsUnique();

        }
    }
}
