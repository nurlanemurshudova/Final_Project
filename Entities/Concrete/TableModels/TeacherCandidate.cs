using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class TeacherCandidate : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsContacted { get; set; }
    }
}
