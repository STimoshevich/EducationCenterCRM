using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationCenterCRM.DAL.Entities
{
    public class EducationCenterUser : IdentityUser
    {
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string PersonLastName { get; set; }
        [Required]
        public string PersonName { get; set; }
        public int PersonId;
        public Person Person { get; set; }
        
    }
}
