using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;

namespace EducationCenterCRM.BLL.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string LinkToProfile { get; set; }

        public EducationCenterUser User { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
