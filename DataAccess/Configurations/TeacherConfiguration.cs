using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.InstagramUrl)
                .HasMaxLength(250);

            builder.Property(t => t.FacebookUrl)
                .HasMaxLength(250);

            builder.Property(t => t.TwitterUrl)
                .HasMaxLength(250);

            builder.Property(t => t.PhotoUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Experience)
                .IsRequired();

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Teachers)
                .HasForeignKey(x => x.PositionId);

            builder.Property(x => x.IsHomePage)
               .HasDefaultValue(false)
              .IsRequired();

        }
    }




}
