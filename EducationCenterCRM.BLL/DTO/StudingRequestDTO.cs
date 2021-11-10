using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;

namespace EducationCenterCRM.BLL.DTO
{
    public class StudingRequestDTO
    {

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string StudentId { get; set; }
        public string StudentFullName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Comments { get; set; }

        public StudingType StudingType { get; set; }

        public StudingRequestStatus Status { get; set; }



    }
}
