using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SchoolClassTeacherConfiguration : IEntityTypeConfiguration<SchoolClassTeacher>
    {
        public void Configure(EntityTypeBuilder<SchoolClassTeacher> builder)
        {
            builder.ToTable("SchoolClassTeachers");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            //builder.HasKey(sct => new { sct.TeacherId, sct.SchoolClassId });

            builder.HasOne(sct => sct.Teacher)
                .WithMany(t => t.SchoolClassTeachers)
                .HasForeignKey(sct => sct.TeacherId);

            builder.HasOne(sct => sct.SchoolClass)
                .WithMany(sc => sc.SchoolClassTeachers)
                .HasForeignKey(sct => sct.SchoolClassId);

            builder.HasIndex(x => new { x.SchoolClassId, x.TeacherId, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Name_Deleted");
        }
    }
}
