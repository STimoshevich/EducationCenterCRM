using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Filteres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filterters.TeacherFilters
{
    public class CourseSpecification : ISpecification<Teacher>
    {
        private readonly int courseId;

        public CourseSpecification(int courseId)
        {
            this.courseId = courseId;
        }

        public Expression<Func<Teacher, bool>> ApplyFilter()
        {
            return x => x.Courses.Select(x => x.Id).Contains(courseId);
        }

        public bool IsSatisfied(Teacher item)
        {
            return item.Courses.Select(x=>x.Id).Contains(courseId);
        }
    }
}
