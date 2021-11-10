using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Filteres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filterters.TeacherFilters
{
    public class TeacherFilter : IFilter<Teacher>
    {

        public int? courseId{ get; set; }

        private Func<IQueryable<Teacher>, IIncludableQueryable<Teacher, object>> includes { get; set; }


        public Func<IQueryable<Teacher>, IIncludableQueryable<Teacher, object>> GetIncludes()
        {
         return includes;
        }

        public IEnumerable<ISpecification<Teacher>> GetSpecifications()
        {
            var specifications = new List<ISpecification<Teacher>>();
            if (courseId.HasValue)
            {
                includes += x => x.Include(x => x.Courses);
                specifications.Add(new CourseSpecification(courseId.Value));
            }


            return specifications;
        }
    }
}
