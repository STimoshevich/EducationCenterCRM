using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.ResponseModels
{
    public class GroupResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public GroupStatus Status { get; set; }
        public int? TeacherId { get; set; }
        public IEnumerable<StudentResponse> Students { get; set; }
    }
}
