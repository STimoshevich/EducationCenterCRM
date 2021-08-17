using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.RequestModels
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
