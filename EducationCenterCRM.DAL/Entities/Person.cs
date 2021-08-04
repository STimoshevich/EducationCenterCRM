using EducationCenterCRM.DAL.Entities.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Entities
{
    public abstract class Person
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "Lenght should be less than 10")]
        public string Name { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "Lenght should be less than 10")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Age(18,80,"Age should be between 18 and 80")]
        public DateTime BirthDate { get; set; }
    }
}
