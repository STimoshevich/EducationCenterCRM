using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class StudingRequestsListDTO
    {
        public List<StudingRequestDTO> Requests { get; set; }
        public int RequestsAmount { get; set; }

    }
}
