using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);

        Expression<Func<T, bool>> ApplyFilter();
    }
}
