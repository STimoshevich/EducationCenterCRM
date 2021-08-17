using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.DAL.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.RequestModels
{
    public class GroupRequest
    {
        [Required] 
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public GroupStatus Status { get; set; }
        public int? TeacherId { get; set; }
        public IEnumerable<StudentResponse> Students { get; set; }
    }
}
