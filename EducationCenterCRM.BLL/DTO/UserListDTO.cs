using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class UserListDTO
    {
        public List<UserDTO> users = new List<UserDTO>();
        public int usersAmount;
    }
}
