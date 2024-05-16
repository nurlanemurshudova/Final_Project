﻿using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class SchoolClassUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChildAge { get; set; }
        public bool IsHomePage { get; set; }
        public string Time { get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public string[] TeacherNames { get; set; }
        public static SchoolClass ToSchoolClass(SchoolClassUpdateDto dto)
        {
            SchoolClass schoolClass = new SchoolClass()
            {
                Id = dto.Id,
                Name = dto.Name,
                ChildAge = dto.ChildAge,
                IsHomePage = dto.IsHomePage,
                Time = dto.Time,
                Capacity = dto.Capacity,
                Price = dto.Price,
                PhotoUrl = dto.PhotoUrl,

            };
            foreach (var teacherName in dto.TeacherNames)
            {
                Teacher teacher = new Teacher()
                {
                    Name = teacherName
                };
            }
            return schoolClass;
        }
    }
}
