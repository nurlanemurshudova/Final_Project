using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SchoolClassTeacherConfiguration : IEntityTypeConfiguration<SchoolClassTeacher>
    {
        public void Configure(EntityTypeBuilder<SchoolClassTeacher> builder)
        {

            builder.HasKey(sct => new { sct.TeacherId, sct.SchoolClassId });

            builder.HasOne(sct => sct.Teacher)
                .WithMany(t => t.SchoolClassTeachers)
                .HasForeignKey(sct => sct.TeacherId);

            builder.HasOne(sct => sct.SchoolClass)
                .WithMany(sc => sc.SchoolClassTeachers)
                .HasForeignKey(sct => sct.SchoolClassId);
        }
    }
}
