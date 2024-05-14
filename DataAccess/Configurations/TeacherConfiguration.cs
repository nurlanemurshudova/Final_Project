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

            builder.Property(x => x.IsHomePage)
               .HasDefaultValue(false)
              .IsRequired();

            builder.HasMany(t => t.Positions)
                   .WithMany(p => p.Teachers)
                   .UsingEntity(j => j.ToTable("TeacherPositions"));

            builder.HasMany(t => t.SchoolClasses)
                   .WithMany(c => c.Teachers)
                   .UsingEntity(j => j.ToTable("SchoolClassTeachers"));
        }
    }





    /*

        public List<Position> Positions { get; set; }
        public List<SchoolClass> SchoolClasses { get; set;}
    */
}
