using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    public class CourseFilter : IFilter<Course>
    {
        public string[] TopicNames { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
        public CourseLevel? Level { get; set; }
        public int? DurationWeeksFrom { get; set; }
        public int? DurationWeeksTo { get; set; }
        private Func<IQueryable<Course>, IIncludableQueryable<Course, object>> includes { get; set; }

        public Func<IQueryable<Course>, IIncludableQueryable<Course, object>> GetIncludes()
        {
            return includes;
        }

        public IEnumerable<ISpecification<Course>> GetSpecifications()
        {
            var specifications = new List<ISpecification<Course>>();

            if (PriceFrom.HasValue)
                specifications.Add(new PriceFromSpecification(PriceFrom.Value));
            if (PriceTo.HasValue)
                specifications.Add(new PriceToSpecification(PriceTo.Value));
            if (Level.HasValue)
                specifications.Add(new LevelSpecification(Level.Value));
            if (DurationWeeksFrom.HasValue)
                specifications.Add(new DurationWeeksFromSpecification(DurationWeeksFrom.Value));
            if (DurationWeeksTo.HasValue)
                specifications.Add(new DurationWeeksToSpecification(DurationWeeksTo.Value));
            if (TopicNames is not null)
                specifications.Add(new TopicNamesSpecification(TopicNames));

            return specifications;
        }
    }
}
