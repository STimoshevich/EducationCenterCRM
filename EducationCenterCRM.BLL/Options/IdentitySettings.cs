using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Options
{
    public class IdentitySettings
    {
       public List<string> AdminEmails { get; set; } = new List<string>();
        public List<string> ManagerEmails { get; set; } = new List<string>();
    }
}
