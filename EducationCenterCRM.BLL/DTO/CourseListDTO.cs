using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class CourseListDTO
    {
       public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
       public int CoursesAmount { get; set; }
    }
}
