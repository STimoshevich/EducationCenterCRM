using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class ProgramSpecification : ISpecification<Course>
    {
        private readonly string searchString;

        public ProgramSpecification(string searchString)
        {
            this.searchString = searchString;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
          return x=>x.Program.Contains(searchString);
        }

        public bool IsSatisfied(Course item)
        {
            return item.Program.Contains(searchString);
        }
    }
}