using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres.GroupFilters
{
    public class GroupFilter : IFilter<Group>
    {
        public GroupStatus? GroupStatus { get; set; }
        public string CourseTitle { get; set; }

        private Func<IQueryable<Group>, IIncludableQueryable<Group, object>> includes { get; set; }



        public IEnumerable<ISpecification<Group>> GetSpecifications()
        {
            var specifications = new List<ISpecification<Group>>();

            if (GroupStatus.HasValue)
                specifications.Add(new StatusSpecification(GroupStatus));
            if (!string.IsNullOrEmpty(CourseTitle))
            {
                includes += x => x.Include(x => x.Course);
                specifications.Add(new CoursesSpecification(CourseTitle));
            }           

            return specifications;
        }

        public Func<IQueryable<Group>, IIncludableQueryable<Group, object>> GetIncludes()
        {
            return includes;
        }
    }
}
