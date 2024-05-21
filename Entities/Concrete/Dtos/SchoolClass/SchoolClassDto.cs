namespace Entities.Concrete.Dtos
{
    public class SchoolClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChildAge { get; set; }
        public bool IsHomePage { get; set; }
        public string Time { get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public string TeacherName { get; set; }
    }
}
