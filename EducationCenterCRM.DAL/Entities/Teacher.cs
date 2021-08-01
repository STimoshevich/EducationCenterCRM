using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Entities
{
    public class Teacher : Person
    {
        public string Bio { get; set; }
        public string LinkToProfile { get; set; }
        public List<Group> Groups { get; set; }
    }
}
