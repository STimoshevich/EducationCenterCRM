using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Entities
{
    public class Teacher : Person
    {
        
        [Required]
        [StringLength(100, ErrorMessage = "Lenght should be less than 100")]
        public string Bio { get; set; }
        public string LinkToProfile { get; set; }

    }
}
