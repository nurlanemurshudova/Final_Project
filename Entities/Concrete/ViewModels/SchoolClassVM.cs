using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ViewModels
{
    public class SchoolClassVM
    {
        public string Name { get; set; }
        public string ChildAge { get; set; }
        public bool IsHomePage { get; set; }
        public string Time { get; set; }
        public byte Capacity { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public List<SchoolClassTeacherVM> SchoolClassTeachers { get; set; }
    }
}
