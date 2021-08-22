using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.RequestModels
{
    public class TopicRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}
