using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class TopicNameSpecification : ISpecification<Course>
    {
        private readonly string searchString;

        public TopicNameSpecification(string searchString)
        {
            this.searchString = searchString;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
           return x=>x.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsSatisfied(Course item)
        {
            return item.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }
    }
}