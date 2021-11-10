using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class GroupListDTO
    {
        public List<GroupDTO> Groups { get; set; } = new List<GroupDTO>();
        public int GroupsAmount { get; set; }
    }
}
