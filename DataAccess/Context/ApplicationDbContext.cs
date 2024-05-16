using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Localhost; Initial Catalog = KiderDb; Integrated Security= true;Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<GurdianNumber> GurdianNumbers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCandidate> TeacherCandidates { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<SchoolClassTeacher> SchoolClassTeachers { get; set; }
    }
}
