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
        public string Bio { get; set; }
        [Required]
        public string LinkToProfile { get; set; }

    }
}
