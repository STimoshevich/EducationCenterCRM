using EducationCenterCRM.DAL.Enums;
using System.Collections.Generic;

namespace EducationCenterCRM.DAL.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Program { get; set; }
        public string TopicTitle { get; set; }
        public Topic Topic { get; set; }
        public string ImageUrl { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public CourseLevel CourseLevel { get; set; }


    }
}
