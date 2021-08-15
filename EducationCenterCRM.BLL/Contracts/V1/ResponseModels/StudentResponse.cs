using EducationCenterCRM.DAL.Entities.ValidationAttributes;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Contracts.V1.ResponseModels
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public StudentType Type { get; set; }
        public int? GroupId { get; set; }
    }
}
