using Entities.Concrete.TableModels;
namespace Entities.Concrete.Dtos
{
    public class TeacherCandidateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsContacted { get; set; }
        public static TeacherCandidate ToTeacherCandidate(TeacherCandidateUpdateDto dto)
        {
            TeacherCandidate teacherCandidate = new TeacherCandidate()
            {
                Id  = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
                Experience = dto.Experience,
                Education = dto.Education,
                PhotoUrl = dto.PhotoUrl,
                IsContacted = dto.IsContacted,
            };
            return teacherCandidate;
        }
    }
}
