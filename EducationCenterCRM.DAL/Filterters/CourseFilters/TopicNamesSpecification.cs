using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class TopicNamesSpecification : ISpecification<Course>
    {
        private readonly string[] topicNames;

        public TopicNamesSpecification(string[] topicNames)
        {
            this.topicNames = topicNames;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
            return x => topicNames.Contains(x.TopicTitle);
        }

        public bool IsSatisfied(Course item)
        {
            return topicNames.FirstOrDefault(x=>x == item.TopicTitle) is not null? true: false;
        }
    }
}