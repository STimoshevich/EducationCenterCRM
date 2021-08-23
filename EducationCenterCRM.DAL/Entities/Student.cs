using EducationCenterCRM.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationCenterCRM.DAL.Entities
{
    public class Student : Person
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public StudentType Type { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

    }
}
