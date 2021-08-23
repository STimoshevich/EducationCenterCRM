using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.RequestModels
{
    public class CourseRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public int TopicId { get; set; }
    }
}
