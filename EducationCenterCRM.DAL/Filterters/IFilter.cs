using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres
{
    public interface IFilter<T>
    {
        IEnumerable<ISpecification<T>> GetSpecifications();
        Func<IQueryable<T>, IIncludableQueryable<T, object>> GetIncludes();
    }
}
