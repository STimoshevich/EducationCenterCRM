using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class TitleContainsSpecification : ISpecification<Course>
    {
        private readonly string searchString;

        public TitleContainsSpecification(string searchString)
        {
            this.searchString = searchString;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
           return x=>x.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }

        public bool IsSatisfied(Course course)
        {
            return course.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }
    }
}