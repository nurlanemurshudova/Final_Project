
using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;
using Microsoft.OpenApi.Models;

namespace KiderProjectWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
            builder.Services.AddScoped<IAppointmentDal, AppointmentDal>();
            builder.Services.AddScoped<IValidator<Appointment>, AppointmentValidation>();

            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();

            builder.Services.AddScoped<IFacilityDal, FacilityDal>();
            builder.Services.AddScoped<IFacilityService, FacilityManager>();
            builder.Services.AddScoped<IValidator<Facility>, FacilityValidation>();

            builder.Services.AddScoped<IPositionDal, PositionDal>();
            builder.Services.AddScoped<IPositionService, PositionManager>();
            builder.Services.AddScoped<IValidator<Position>, PositionValidation>();

            builder.Services.AddScoped<ISchoolClassDal, SchoolClassDal>();
            builder.Services.AddScoped<ISchoolClassService, SchoolClassManager>();
            builder.Services.AddScoped<IValidator<SchoolClass>, SchoolClassValidation>();

            builder.Services.AddScoped<ISchoolClassTeacherDal, SchoolClassTeacherDal>();
            builder.Services.AddScoped<ISchoolClassTeacherService, SchoolClassTeacherManager>();

            builder.Services.AddScoped<ISlideDal, SlideDal>();
            builder.Services.AddScoped<ISlideService, SlideManager>();
            builder.Services.AddScoped<IValidator<Slide>, SlideValidation>();

            builder.Services.AddScoped<ITeacherCandidateDal, TeacherCandidateDal>();
            builder.Services.AddScoped<ITeacherCandidateService, TeacherCandidateManager>();
            builder.Services.AddScoped<IValidator<TeacherCandidate>, TeacherCandidateValidation>();

            builder.Services.AddScoped<ITeacherDal, TeacherDal>();
            builder.Services.AddScoped<ITeacherService, TeacherManager>();
            builder.Services.AddScoped<IValidator<Teacher>, TeacherValidation>();

            builder.Services.AddScoped<ITestmonialDal, TestmonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Form parametrelerini işlerken oluşan hatayı çözmek için aşağıdaki satırı ekleyin:
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
