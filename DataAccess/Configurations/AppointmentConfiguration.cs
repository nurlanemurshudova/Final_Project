using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AppointmentConfiguration :IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.GurdianName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.ChildName)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.ChildAge)
                .IsRequired();

            builder.Property(x => x.GurdianEmail)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x=>x.FirstPhoneNumber)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(x=>x.SecondPhoneNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.GurdianEmail);

        }
    }
}
