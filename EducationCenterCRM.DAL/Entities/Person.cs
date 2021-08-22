using System;
using System.ComponentModel.DataAnnotations;

namespace EducationCenterCRM.DAL.Entities
{
    public abstract class Person
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
