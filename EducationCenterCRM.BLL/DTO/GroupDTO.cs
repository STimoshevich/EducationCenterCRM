using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class GroupDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public GroupStatus Status { get; set; }
        public int StudentCapacity { get; set; }
        public StudingType StudingType { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } 
        public string TeacherName { get; set; }
        public int? TeacherId { get; set; }
    }
}
