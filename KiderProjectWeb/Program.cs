using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace KiderProjectWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IAppointmentService, AppointmentManager>();
            builder.Services.AddScoped<IAppointmentDal, AppointmentDal>();
            builder.Services.AddScoped<IValidator<Appointment>, AppointmentValidation>();

            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IContactService,ContactManager>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();
            
            builder.Services.AddScoped<IFacilityDal, FacilityDal>();
            builder.Services.AddScoped<IFacilityService,FacilityManager>();
            builder.Services.AddScoped<IValidator<Facility>, FacilityValidation>();

            builder.Services.AddScoped<IGurdianNumberDal, GurdianNumberDal>();
            builder.Services.AddScoped<IGurdianNumberService, GurdianNumberManager>();
            builder.Services.AddScoped<IValidator<GurdianNumber>, GurdianNumberValidation>();

            builder.Services.AddScoped<IPositionDal, PositionDal>();
            builder.Services.AddScoped<IPositionService, PositionManager>();
            builder.Services.AddScoped<IValidator<Position>, PositionValidation>();

            builder.Services.AddScoped<ISchoolClassDal, SchoolClassDal>();
            builder.Services.AddScoped<ISchoolClassService, SchoolClassManager>();

            builder.Services.AddScoped<ISchoolClassTeacherDal, SchoolClassTeacherDal>();
            builder.Services.AddScoped<ISchoolClassTeacherService, SchoolClassTeacherManager>();

            builder.Services.AddScoped<ISlideDal, SlideDal>();
            builder.Services.AddScoped<ISlideService, SlideManager>();

            builder.Services.AddScoped<ITeacherCandidateDal, TeacherCandidateDal>();
            builder.Services.AddScoped<ITeacherCandidateService, TeacherCandidateManager>();

            builder.Services.AddScoped<ITeacherDal, TeacherDal>();
            builder.Services.AddScoped<ITeacherService, TeacherManager>();

            builder.Services.AddScoped<ITestmonialDal, TestmonialDal>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}
