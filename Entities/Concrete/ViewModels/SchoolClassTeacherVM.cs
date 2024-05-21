using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.ViewModels
{
    public class SchoolClassTeacherVM
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int SchoolClassId { get; set; }
        public string SchoolClassName { get; set; }
    }
}
