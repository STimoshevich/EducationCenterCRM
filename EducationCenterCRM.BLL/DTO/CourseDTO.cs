using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public string TopicTitle { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }    
        public CourseLevel CourseLevel { get; set; }

    }
}
