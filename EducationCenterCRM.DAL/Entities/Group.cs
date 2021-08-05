using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationCenterCRM.DAL.Entities
{
    public class Group
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5,ErrorMessage = "Lenght should be less than 20 and more than 5")]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public GroupStatus Status { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
    }
}