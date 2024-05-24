using Entities.Concrete.TableModels;

namespace KiderProjectWeb.ViewModels
{
    public class HomeViewModel
    {
        public List<About> Abouts { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }
}
