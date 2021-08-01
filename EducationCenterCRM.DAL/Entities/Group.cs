using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;

namespace EducationCenterCRM.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public GroupStatus Status { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}