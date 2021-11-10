using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres.GroupFilters
{
    public class CoursesSpecification : ISpecification<Group>
    {
        private string courseTitle;

        public CoursesSpecification(string courseTitle)
        {
            this.courseTitle = courseTitle;
        }

        public Expression<Func<Group, bool>> ApplyFilter()
        {
            return x=>x.Course.Title == courseTitle;
        }

        public bool IsSatisfied(Group item)
        {
           return item.Course.Title == courseTitle;
        }
    }
}
