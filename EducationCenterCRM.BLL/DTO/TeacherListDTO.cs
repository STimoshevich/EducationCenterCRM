using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class TeacherListDTO
    {
        public List<TeacherDTO> Teachers { get; set; } = new List<TeacherDTO>();
        public int TeachersAmount { get; set; }
    }
}
