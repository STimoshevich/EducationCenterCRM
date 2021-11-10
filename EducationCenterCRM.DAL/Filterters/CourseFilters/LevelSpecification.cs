using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class LevelSpecification : ISpecification<Course>
    {
        private readonly CourseLevel courseLevel;

        public LevelSpecification(CourseLevel courseLevel)
        {
            this.courseLevel = courseLevel;
        }

        public Expression<Func<Course, bool>> ApplyFilter()
        {
           return x=>x.CourseLevel == courseLevel;
        }

        public bool IsSatisfied(Course item)
        {
            return item.CourseLevel == courseLevel;
        }
    }
}