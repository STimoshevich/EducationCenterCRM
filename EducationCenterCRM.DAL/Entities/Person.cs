using System;
using System.ComponentModel.DataAnnotations;

namespace EducationCenterCRM.DAL.Entities
{
    public abstract class Person
    {
        [Required]
        public int Id { get; set; }
        public string EducationCenterUserId { get; set; }
        public EducationCenterUser EducationCenterUser { get; set; }

    }
}
