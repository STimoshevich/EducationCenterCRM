using EducationCenterCRM.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    internal class PriceFromSpecification : ISpecification<Course>
    {
        private readonly double price;

        public PriceFromSpecification(double price)
        {
            this.price = price;
        }

        public Expression<Func<Course, bool>> ApplyFilter()
        {
            return x=>x.Price >= price;
        }

        public bool IsSatisfied(Course item)
        {
          return item.Price >= price;
        }
    }
}