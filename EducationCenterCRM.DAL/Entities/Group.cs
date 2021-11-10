using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EducationCenterCRM.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public GroupStatus Status { get; set; }
        [Required]
        public int StudentCapacity { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public StudingType  StudingType { get; set; }
        public Course Course { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }
}