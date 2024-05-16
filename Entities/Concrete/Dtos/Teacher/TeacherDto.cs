namespace Entities.Concrete.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int PositionId { get; set; }
        public string[] PositionName { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public byte Experience { get; set; }
    }
}
