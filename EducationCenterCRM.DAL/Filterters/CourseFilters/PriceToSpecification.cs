using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres.CourseFilters
{
    public class PriceToSpecification : ISpecification<Course>
    {
        private readonly double priceTo;

        public PriceToSpecification(double priceTo)
        {
            this.priceTo = priceTo;
        }
        public Expression<Func<Course, bool>> ApplyFilter()
        {
            return x => x.Price <= priceTo;
        }

        public bool IsSatisfied(Course item)
        {
            return priceTo <= item.Price;
        }
    }
}
