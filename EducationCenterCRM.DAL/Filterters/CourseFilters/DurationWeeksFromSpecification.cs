using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class DurationWeeksFromSpecification : ISpecification<Course>
    {
        private readonly int weeks;

        public DurationWeeksFromSpecification(int weeks)
        {
            this.weeks = weeks;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
           return x=>x.DurationWeeks >= weeks;
        }

        public bool IsSatisfied(Course item)
        {
           return item.DurationWeeks >= weeks;
        }
    }
}