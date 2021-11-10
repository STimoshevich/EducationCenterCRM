using EducationCenterCRM.DAL.Entities;
using System.Collections.Generic;

namespace EducationCenter.UnitTests
{
    public class CourseGenerator
    {
        public static List<Course> Get()
        {

            return new List<Course>()
            {
                 new Course()
                 {
                 Id = 1,
                 Title = "first_student_title",
                 Description = "first_student_description"
                 },
                 new Course()
                 {
                 Id = 2,
                 Title = "second_student_title",
                 Description = "second_student_description"
                 },
                  new Course()
                 {
                 Id = 3,
                 Title = "third_student_title",
                 Description = "third_student_description"
                 }
             };


        }
    }
}
