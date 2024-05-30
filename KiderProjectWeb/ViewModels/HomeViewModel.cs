using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Entities.Concrete.ViewModels;

namespace KiderProjectWeb.ViewModels
{
    public class HomeViewModel
    {
        public List<Slide> Slides { get; set; }
        public List<About> Abouts { get; set; }
        public List<TeacherDto> Teachers { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Facility> Facilities { get; set; }
        public List<SchoolClassVM> SchoolClasses { get; set;}
        public List<SchoolClassTeacherVM> ClassTeachers { get; set; }
    }
}
